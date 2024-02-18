namespace WebBrowserWidget.Source.Public.Utils
{
    public static class MsgClass
    {
        public static void Init(string text = "", MessageBoxIcon type = MessageBoxIcon.Information, bool is_async = true) 
        {
            if (is_async) 
            {
                Thread ThreadA = new Thread(() => SpawnMSG(text, type));
                ThreadA.Start();
            }
            else 
            {
                SpawnMSG(text, type);
            }
        }

        public static void SpawnMSG(string text, MessageBoxIcon type) 
        {
            MessageBox.Show(text, $"Web Widget", MessageBoxButtons.OK, type);
        }
    }
}
