using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WebBrowserWidget.Source.Internal.Local;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget
{
    public static class Program
    {
        public static string basepath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Web Widget");
        public static RegistryKey ?RegStart { get; } = Registry.CurrentUser.OpenSubKey(Path.Combine("SOFTWARE", "Microsoft", "Windows", "CurrentVersion", "Run"), true);

        [STAThread]
        static void Main(string[] args)
        {
            Process currentProcess = Process.GetCurrentProcess();

            if (Process.GetProcessesByName(currentProcess.ProcessName, currentProcess.MachineName).Length > 1)
            {
                MsgClass.Init("Another process is already running.", MessageBoxIcon.Warning, false);
                System.Environment.Exit(1);
            };

            Application.EnableVisualStyles();
            Master Manager = new Master();

            try
            {
                Directory.CreateDirectory(Path.Combine(basepath, "Settings"));
                Directory.CreateDirectory(Path.Combine(basepath, "User", "Cache"));
                Directory.CreateDirectory(Path.Combine(basepath, "Data"));

            }catch (Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error, false);
                System.Environment.Exit(1);
            };

            Thread MasterThread = new Thread(() => Manager.Init());
            MasterThread.Start();

            foreach (JProperty entry in AppSettings.ReadSettings()["Instances"])
            {
                SpawnActor.CreateInstance(Manager, configs: entry);
            };
            MasterThread.Join();
        }
    }
}