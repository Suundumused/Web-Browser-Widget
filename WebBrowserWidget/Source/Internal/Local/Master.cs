using System.IO;
using System.Reflection;
using WebBrowserWidget.Source.Internal.Customize;
using WebBrowserWidget.Source.Internal.Master;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.Local
{
    internal class Master
    {
        private NotifyIcon? Icon_x;

        private string ico_path { get; set; } = "";
        private string h_path { get; } = Path.Combine(Program.basepath, "User", "historic.csv");

        public bool OnFavorites { get; set; } = false;

        private ToolStripMenuItem ?AutoBoot;
        private ToolStripMenuItem ?Objects;

        public List<dynamic> Instances { get; set; } = [];

        public void init() 
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Instances = new List<dynamic>();

            string ?base_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                if (base_path != null && base_path != "")
                {
                    ico_path = Path.Combine(base_path, "Assets", "ico", "16x.ico");
                }
                else
                {
                    ico_path = Path.Combine(AppContext.BaseDirectory, "Assets", "ico", "16x.ico");
                }
                SpawnTray(ico_path);
            }
            catch (Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
        }

        private void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            Customize_Class.Save_Customs(Instances);
        }

        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            Customize_Class.Save_Customs(Instances);
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

            ToolStripMenuItem setsclear = new ToolStripMenuItem("Clear settings");
            setsclear.Click += Clear_Settings;
            menuItem1.DropDownItems.Add(setsclear);

            ToolStripMenuItem historic = new ToolStripMenuItem("Historic");
            historic.Click += History;
            contextMenu.Items.Add(historic);

            ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Exit");
            menuItem2.Click += Exit;
            contextMenu.Items.Add(menuItem2);

            // Assign the context menu to the NotifyIcon
            Icon_x.ContextMenuStrip = contextMenu;

            dynamic? data = AppSettings.ReadSettings();

            if ((bool)data["AutoBoot"])
            {
                AutoBoot.CheckState = CheckState.Checked;
            }
            else
            {
                AutoBoot.CheckState = CheckState.Unchecked;
            }

            Application.Run();
        }

        private void History(object? sender, EventArgs e)
        {
            if (!OnFavorites)
            {
                OnFavorites = true;
                ListClass.Init(this, db_manager.ReadCSV(h_path), "Historic", "navigate");
            };
        }

        private void Clear_Historic(object? sender, EventArgs e)
        {
            try
            {
                if (File.Exists(h_path))
                {
                    File.Delete(h_path);
                }
            }
            catch {}
        }

        private void Clear_Settings(object? sender, EventArgs e)
        {
            try
            {
                string h_path = Path.Combine(Program.basepath, "Settings", "User_Settings.json");
                if (File.Exists(h_path))
                {
                    File.Delete(h_path);
                }
            }
            catch { }
        }

        private void List_Instances(object? sender, EventArgs e)
        {
            Objects.DropDownItems.Clear();

            int i = 0;
            foreach (dynamic object_ in Instances)
            {
                if (object_ is null)
                {
                    Instances.RemoveAt(i);
                }
                else
                {
                    try
                    {
                        dynamic my_browser = object_.webView21;
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
                        Item.Click += (object? sender, EventArgs e) => browser_focus(sender, e, object_);
                        Objects.DropDownItems.Add(Item);
                    }
                    catch { }
                };
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

            if ((bool)data["AutoBoot"])
            {
                data["AutoBoot"] = false;
                AutoBoot.CheckState = CheckState.Unchecked;
            }
            else
            {
                data["AutoBoot"] = true;
                AutoBoot.CheckState = CheckState.Checked;
            }
            AppSettings.WriteSettings(data);
        }
    }
}
