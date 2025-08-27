namespace WebBrowserWidget.Source.Public.Interfaces.Master;

public interface iListClass
{
    public static abstract void Init(dynamic Instance, List<string> Content, string title = "",
        string event_type = "navigate");

    public static abstract void NewThreadList(dynamic Instance, List<string> Content, string title, string event_type);
}