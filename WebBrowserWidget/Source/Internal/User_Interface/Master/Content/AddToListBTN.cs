using WebBrowserWidget.Source.Internal.User_Interface.BrowserClass;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.User_Interface.Master.Content;

public partial class AddToListBTN : UserControl
{
    public AddToListBTN(ListViewWindow Parent, BrowserUI Instance)
    {
        MyInstance = Instance;
        MyParent = Parent;
        InitializeComponent();
    }

    private BrowserUI MyInstance { get; }
    private ListViewWindow MyParent { get; }

    private void OnClick(object sender, MouseEventArgs e)
    {
        try
        {
            var documentTitle = "";

            MyInstance.Invoke(new MethodInvoker(delegate
            {
                documentTitle = MyInstance.webView21.CoreWebView2.DocumentTitle;
            }));

            if (documentTitle == " " || documentTitle == "") documentTitle = "Loading...";
            ;

            if (Db_manager.AddColumnsAndRows(MyParent.minePath, (documentTitle, MyInstance.webView21.Source.ToString()),
                    ("Title", "Url"))) MyParent.AddPersonalBTN();
            ;
        }
        catch
        {
        }
    }
}