namespace WebBrowserWidget.Source.Public.Interfaces.Master;

public interface iListClass
{
    static abstract void Init(dynamic Instance, List<string> Content, string title = "",
        string event_type = "navigate");

    static abstract void NewThreadList(dynamic Instance, List<string> Content, string title, string event_type);
}