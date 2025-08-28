namespace WebBrowserWidget.Source.Public.Utils;

public static class MsgClass
{
    public static void Init(string text = "", MessageBoxIcon type = MessageBoxIcon.Information, bool is_async = true)
    {
        if (is_async)
        {
            Thread ThreadA = new(() => SpawnMSG(text, type));
            ThreadA.Start();
        }
        else
        {
            SpawnMSG(text, type);
        }

        ;
    }

    public static void SpawnMSG(string text, MessageBoxIcon type)
    {
        _ = MessageBox.Show(text, "Web Widget", MessageBoxButtons.OK, type);
    }
}