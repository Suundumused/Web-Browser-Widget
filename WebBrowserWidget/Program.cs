using System;
using System.Windows.Forms;
using WebBrowserWidget.Source.Internal.BrowserClass;
using WebBrowserWidget.Source.Internal.Local;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget
{
    public static class Program
    {
        private static NotifyIcon ?_trayIcon;
        private static ContextMenuStrip ?_contextMenu;

        public static string basepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Web Widget");

        [STAThread]
        static void Main()
        {
            Master Mananger = new Master();

            try
            {
                Directory.CreateDirectory(Path.Combine(basepath, "Settings"));
                Directory.CreateDirectory(Path.Combine(basepath, "Browser Properties"));
                Directory.CreateDirectory(Path.Combine(basepath, "User", "Cache"));
                Directory.CreateDirectory(Path.Combine(basepath, "Data"));

            }catch (Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error, false);
                System.Environment.Exit(1);
            }

            Thread MasterThread = new Thread(() => Mananger.init());
            MasterThread.Start();

            Thread ThreadA = new Thread(() => NewThread(Mananger));
            ThreadA.SetApartmentState(ApartmentState.STA);
            ThreadA.Start();

            MasterThread.Join();
        }

        public static void NewThread(dynamic ?masterObject = null) 
        {
            ApplicationConfiguration.Initialize();
            Browser.init(masterObject);
        }
    }
}