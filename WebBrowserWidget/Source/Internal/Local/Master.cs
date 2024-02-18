using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.Local
{
    internal class Master
    {
        private NotifyIcon? Icon_x;
        private string? ico_path { get; set; }
        private ToolStripMenuItem ?AutoBoot;
        private ToolStripMenuItem ?Objects;

        public List<dynamic> ?Instances { get; set; }

        public void init() 
        {
            Instances = new List<dynamic>();

            string ?base_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (base_path != null && base_path != "")
            {
                ico_path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets", "ico", "16x.ico");
            }
            else 
            {
                ico_path = Path.Combine(AppContext.BaseDirectory, "Assets", "ico", "16x.ico");
            }
            SpawnTray(ico_path);
        }

        private void SpawnTray(string ico_path) 
        {
            Icon_x = new NotifyIcon();
            try
            {
                Icon_x.Icon = new Icon(ico_path);
            }
            catch{}
            Icon_x.MouseClick += List_Instances;
            Icon_x.Visible = true;
            
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem Instancer = new ToolStripMenuItem("New Window");
            Instancer.Click += New_Instance;
            contextMenu.Items.Add(Instancer);

            Objects = new ToolStripMenuItem("Instances");
            contextMenu.Items.Add(Objects);

            // Add menu items to the context menu
            ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Settings");
            //menuItem1.Click += MenuItem1_Click;
            contextMenu.Items.Add(menuItem1);

            AutoBoot = new ToolStripMenuItem("AutoBoot");
            AutoBoot.Click += setAutoBoot;
            menuItem1.DropDownItems.Add(AutoBoot);

            ToolStripMenuItem Clear = new ToolStripMenuItem("Clear history");
            Clear.Click += Clear_Historic;
            menuItem1.DropDownItems.Add(Clear);

            ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Exit");
            menuItem2.Click += Exit;
            contextMenu.Items.Add(menuItem2);

            // Assign the context menu to the NotifyIcon
            Icon_x.ContextMenuStrip = contextMenu;

            dynamic? data = AppSettings.ReadSettings();

            if (data.AutoBoot)
            {
                AutoBoot.CheckState = CheckState.Checked;
            }
            else
            {
                AutoBoot.CheckState = CheckState.Unchecked;
            }

            Application.Run();
        }

        private void Clear_Historic(object? sender, EventArgs e)
        {
            string h_path = Path.Combine(Program.basepath, "Data", "historic.csv");
            if (File.Exists(h_path))
            {
                File.Delete(h_path);
            }
        }

        private void List_Instances(object? sender, EventArgs e)
        {
            Objects.DropDownItems.Clear();

            int i = 0;
            foreach (var object_ in Instances)
            {
                if (object_ is null)
                {
                    Instances.RemoveAt(i);
                }
                else
                {
                    var my_browser = object_.webView21;
                    string URL = my_browser.Source.ToString();
                    string documentTitle = "";

                    try
                    {
                        if (URL.Contains("www."))
                        {
                            documentTitle = URL.Split("www.")[1].Split(".")[0];
                        }
                        else
                        {
                            documentTitle = URL.Split("://")[1].Split(".")[0];
                        }
                    }
                    catch 
                    {
                        documentTitle = "Loading...";
                    }
                    ToolStripMenuItem Item = new ToolStripMenuItem(documentTitle);
                    Item.Click += (sender, e) => browser_focus(sender, e, object_);
                    Objects.DropDownItems.Add(Item);
                }
                i++;
            }
        }

        private void browser_focus(object? sender, EventArgs e, dynamic index)
        {
            index.Invoke(new System.Windows.Forms.MethodInvoker(delegate { index.Activate(); }));
        }

        private void New_Instance(object sender, EventArgs e) 
        {
            SpawnActor.CreateInstance(this);
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setAutoBoot(object sender, EventArgs e)
        {
            dynamic? data = AppSettings.ReadSettings();

            if (data.AutoBoot)
            {
                data.AutoBoot = false;
                AutoBoot.CheckState = CheckState.Unchecked;
            }
            else
            {
                data.AutoBoot = true;
                AutoBoot.CheckState = CheckState.Checked;
            }
            AppSettings.WriteSettings(data);
        }
    }
}
