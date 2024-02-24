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
                dynamic my_browser = MyInstance.webView21;
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
                if (Db_manager.AddColumnsAndRows(MyParent.minePath, (documentTitle, MyInstance.webView21.Source.ToString()), ("Title", "Url"))) 
                {
                    MyParent.AddPersonalBTN();
                };
            }
            catch { }
        }
    }
}
