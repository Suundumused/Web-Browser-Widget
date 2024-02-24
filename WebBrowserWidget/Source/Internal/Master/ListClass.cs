using WebBrowserWidget.Source.Internal.User_Interface.Master;
using WebBrowserWidget.Source.Public.Interfaces.Master;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.Master
{
    internal class ListClass : iListClass
    {
        public static void Init(dynamic Instance, List<string> Content, string title = "", string event_type = "navigate")
        {
            Thread MasterThread = new Thread(() => NewThreadList(Instance, Content, title, event_type));
            MasterThread.Start();
        }

        public static void NewThreadList(dynamic Instance, List<string> Content, string title, string event_type)
        {
            ListViewWindow ListView = new ListViewWindow(Instance, Content, title, event_type);

            if (Instance is BrowserUI) 
            {
                Instance.MineFavorites = ListView;
            }

            try
            {
                Application.Run(ListView);
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
            };
        }
    }
}
