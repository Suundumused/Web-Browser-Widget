using WebBrowserWidget.Source.Internal.User_Interface.BrowserClass;
using WebBrowserWidget.Source.Internal.User_Interface.Settings;
using WebBrowserWidget.Source.Public.Interfaces.SettingsClass;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.SettingsClass;

internal class Settings : iSettingsClass
{
    public static void Sets(dynamic? Parent)
    {
        Thread ThreadA = new(() => Init(Parent));
        ThreadA.Start();
    }

    private static void Init(dynamic? Parent)
    {
        Local_Settings mineSettings = new(Parent);

        if (Parent is BrowserUI) Parent.MineSettings = mineSettings;

        ;

        try
        {
            Application.Run(mineSettings);
        }
        catch (Exception ex)
        {
            MsgClass.Init(ex.Message, MessageBoxIcon.Error, false);
            Environment.Exit(1);
        }

        ;
    }
}