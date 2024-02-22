using WebBrowserWidget.Source.Internal.User_Interface.Master.Content;

namespace WebBrowserWidget.Source.Internal.User_Interface.Master
{
    public partial class ListViewWindow : Form
    {
        private dynamic myParent { get; set; }

        private List<string> mineContent { get; set; }
        private string mineEventType { get; set; }

        public ListViewWindow(dynamic Instance, List<string> Content, string title = "", string event_type = "navigate")
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
            foreach (string thing in mineContent.AsEnumerable().Reverse())
            {
                panel1.Controls.Add(new UserClick(myParent, this, thing, mineEventType));
            }
            panel1.ScrollControlIntoView(panel1.Controls[40]);
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            myParent.OnFavorites = false;
        }
    }
}
