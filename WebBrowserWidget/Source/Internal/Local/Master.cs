using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WebBrowserWidget.Source.Internal.Local
{
    internal class Master
    {
        private NotifyIcon? Icon_x;
        private string? ico_path { get; set; }
        private ToolStripMenuItem AutoBoot;

        public void init() 
        {
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
            Icon_x.Visible = true;

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem Instancer = new ToolStripMenuItem("New Window");
            Instancer.Click += New_Instance;
            contextMenu.Items.Add(Instancer);

            // Add menu items to the context menu
            ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Settings");
            //menuItem1.Click += MenuItem1_Click;
            contextMenu.Items.Add(menuItem1);

            AutoBoot = new ToolStripMenuItem("AutoBoot");
            AutoBoot.Click += setAutoBoot;
            menuItem1.DropDownItems.Add(AutoBoot);

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

        private void New_Instance(object sender, EventArgs e) 
        {
            Thread ThreadA = new Thread(() => Program.NewThread());
            ThreadA.SetApartmentState(ApartmentState.STA);
            ThreadA.Start();
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
