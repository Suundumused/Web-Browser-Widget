using WebBrowserWidget.Source.Public.Interfaces.BrowserClass;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.BrowserClass
{
    internal class Browser : iBrowser
    {
        public static void Init(dynamic masterObject, string ?Deferral = null, dynamic? configs = null)
        {
            Form BrowserUI = new BrowserUI(masterObject, Deferral, configs);

            try 
            {
                Application.Run(BrowserUI);
            }
            catch (Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error, false);
                System.Environment.Exit(1);
            };
        }
    }
}
