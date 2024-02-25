using WebBrowserWidget.Source.Public.Utils;
namespace WebBrowserWidget.Source.Internal.User_Interface.Master.Content
{
    public partial class AddToListBTN : UserControl
    {
        private BrowserUI MyInstance { get; set; }
        private ListViewWindow MyParent { get; set; }

        public AddToListBTN(ListViewWindow Parent,  BrowserUI Instance)
        {
            MyInstance = Instance;
            MyParent = Parent;
            InitializeComponent();
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            try 
            {
                string documentTitle = "";

                MyInstance.Invoke(new System.Windows.Forms.MethodInvoker(delegate { documentTitle = MyInstance.webView21.CoreWebView2.DocumentTitle; }));

                if (documentTitle == " " || documentTitle == "")
                {
                    documentTitle = "Loading...";
                };

                if (Db_manager.AddColumnsAndRows(MyParent.minePath, (documentTitle, MyInstance.webView21.Source.ToString()), ("Title", "Url"))) 
                {
                    MyParent.AddPersonalBTN();
                };
            }
            catch { }
        }
    }
}
