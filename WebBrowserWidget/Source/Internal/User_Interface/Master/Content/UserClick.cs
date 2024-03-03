using System.Runtime.InteropServices;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.User_Interface.Master.Content
{
    public partial class UserClick : UserControl
    {
        protected dynamic MineInstance { get; set; }
        protected dynamic MineParent { get; set; }

        protected string Mine_var { get; set; } = string.Empty;
        protected string Mine_event_type { get; set; } = string.Empty;

        public UserClick(dynamic Instance, dynamic parent, string variable = "", string event_type = "navigate")
        {
            MineParent = parent;
            MineInstance = Instance;
            Mine_var = variable.Replace(",", " - ");
            Mine_event_type = event_type;
            InitializeComponent();
            label1.Text = Mine_var;
        }

        private void event_click(object sender, MouseEventArgs e)
        {
            if (Mine_event_type == "navigate")
            {
                try
                {
                    MineInstance.Invoke(new System.Windows.Forms.MethodInvoker(delegate { MineInstance.webView21.CoreWebView2.Navigate(Mine_var.Split("- ")[1]); }));
                    MineParent.Close();
                }
                catch
                {
                    SpawnActor.CreateInstance(MineInstance, Deferral: Mine_var.Split("- ")[1]);
                    MineParent.Close();
                }
            }
        }

        private void Hover_Color(object sender, EventArgs e)
        {
            label1.BackColor = Color.DarkOrange;
        }

        private void Leave_Color(object sender, EventArgs e)
        {
            label1.BackColor = Color.Orange;
        }

        private void Click_Color(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.Olive;
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Top;
        }

        private void Clicked(object sender, MouseEventArgs e)
        {
            Db_manager.RemoveLineIndex(MineParent.minePath, MineParent.AllButtons.IndexOf(this));
            MineParent.AllButtons.Remove(this);
            this.Dispose();
        }
    }
}
