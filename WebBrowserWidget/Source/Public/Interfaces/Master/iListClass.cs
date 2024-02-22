namespace WebBrowserWidget.Source.Public.Interfaces.Master
{
    public interface iListClass
    {
        public abstract static void Init(dynamic Instance, string[] Content, string title = "", string event_type = "navigate");
        public abstract static void NewThreadList(dynamic Instance, string[] Content, string title, string event_type);
    }
}
