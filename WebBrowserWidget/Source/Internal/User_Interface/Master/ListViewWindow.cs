using WebBrowserWidget.Source.Internal.User_Interface.Master.Content;

namespace WebBrowserWidget.Source.Internal.User_Interface.Master
{
    public partial class ListViewWindow : Form
    {
        private dynamic myParent { get; set; }

        private string[] mineContent { get; set; }
        private string mineEventType { get; set; }

        public ListViewWindow(dynamic Instance, string[] Content, string title = "", string event_type = "navigate")
        {
            myParent = Instance;
            mineContent = Content;
            mineEventType = event_type;
            this.Text = title;
            InitializeComponent();
            BringToFront();
            Activate();
        }

        private void UpdateUI(object sender, EventArgs e)
        {
            foreach (string thing in mineContent)
            {
                panel1.Controls.Add(new UserClick(myParent, this, thing, mineEventType));
            }
        }
    }
}
