using System.Diagnostics;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using WebBrowserWidget.Source.Internal.Local;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget;

public static class Program
{
    public static string basepath { get; } =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Web Widget");

    public static RegistryKey? RegStart { get; } =
        Registry.CurrentUser.OpenSubKey(Path.Combine("SOFTWARE", "Microsoft", "Windows", "CurrentVersion", "Run"),
            true);

    [STAThread]
    private static void Main(string[] args)
    {
        var currentProcess = Process.GetCurrentProcess();

        if (Process.GetProcessesByName(currentProcess.ProcessName, currentProcess.MachineName).Length > 1)
        {
            MsgClass.Init("Another process is already running.", MessageBoxIcon.Warning, false);
            Environment.Exit(1);
        }

        ;

        Application.EnableVisualStyles();
        var Manager = new Master();

        try
        {
            Directory.CreateDirectory(Path.Combine(basepath, "Settings"));
            Directory.CreateDirectory(Path.Combine(basepath, "User", "Cache"));
            Directory.CreateDirectory(Path.Combine(basepath, "Data"));
        }
        catch (Exception ex)
        {
            MsgClass.Init(ex.Message, MessageBoxIcon.Error, false);
            Environment.Exit(1);
        }

        ;

        var MasterThread = new Thread(() => Manager.Init());
        MasterThread.Start();

        foreach (JProperty entry in AppSettings.ReadSettings()["Instances"])
            SpawnActor.CreateInstance(Manager, configs: entry);
        ;
        MasterThread.Join();
    }
}