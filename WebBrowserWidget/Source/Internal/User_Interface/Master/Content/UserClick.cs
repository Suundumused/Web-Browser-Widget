namespace WebBrowserWidget.Source.Internal.User_Interface.Master.Content
{
    public partial class UserClick : UserControl
    {
        protected dynamic mineInstance { get; set; }
        protected dynamic mineParent { get; set; }

        protected string mine_var { get; set; } = string.Empty;
        protected string mine_event_type { get; set; } = string.Empty;

        public UserClick(dynamic Instance, dynamic parent, string variable = "", string event_type = "navigate")
        {
            mineParent = parent;
            mineInstance = Instance;
            mine_var = variable;
            mine_event_type = event_type;
            InitializeComponent();
            label1.Text = mine_var;
        }

        private void event_click(object sender, MouseEventArgs e)
        {
            if (mine_event_type == "navigate")
            {
                try
                {
                    mineInstance.Invoke(new System.Windows.Forms.MethodInvoker(delegate { mineInstance.webView21.CoreWebView2.Navigate(mine_var); }));
                    mineParent.Close();
                }
                catch { }
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
    }
}
