using WebBrowserWidget.Source.Internal.User_Interface.BrowserClass;

namespace WebBrowserWidget.Source.Public.Interfaces.CustomsClass;

public interface iCustomsClass
{
    static abstract string Customize(BrowserUI? instance = null, string? myDeferral = null,
        dynamic? local_configs = null);
}