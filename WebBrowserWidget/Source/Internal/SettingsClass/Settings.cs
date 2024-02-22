using WebBrowserWidget.Source.Internal.User_Interface.Settings;
using WebBrowserWidget.Source.Public.Interfaces.SettingsClass;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.SettingsClass
{
    internal class Settings : iSettingsClass
    {
        public static void Sets(dynamic ?Parent)
        {
            Thread ThreadA = new Thread(() => Init(Parent));
            ThreadA.Start();
        }

        private static void Init(dynamic ?Parent) 
        {
            try
            {
                Application.Run(new Local_Settings(Parent));
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error, false);
                System.Environment.Exit(1);
            };
        }
    }
}
