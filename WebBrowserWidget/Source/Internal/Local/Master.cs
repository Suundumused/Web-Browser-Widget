using System.Reflection;
using WebBrowserWidget.Properties;
using WebBrowserWidget.Source.Internal.Customize;
using WebBrowserWidget.Source.Internal.Master;
using WebBrowserWidget.Source.Internal.User_Interface.About;
using WebBrowserWidget.Source.Internal.User_Interface.BrowserClass;
using WebBrowserWidget.Source.Public.Utils;
using MethodInvoker = System.Windows.Forms.MethodInvoker;

namespace WebBrowserWidget.Source.Internal.Local;

internal class Master
{
    private ToolStripMenuItem? AutoBoot;
    private NotifyIcon? Icon_x;
    private ToolStripMenuItem? Objects;
    private AboutMe? AboutOfMe { get; set; }

    private string icoPath { get; } = "";
    public static string hPath { get; } = System.IO.Path.Combine(Program.basepath, "User", "historic.csv");
    public static string fPath { get; } = System.IO.Path.Combine(Program.basepath, "User", "favorites.csv");
    private string path { get; } = System.IO.Path.Combine(Program.basepath, "Settings", "User_Settings.json");
    private string dataPath { get; } = System.IO.Path.Combine(Program.basepath, "Data", "EBWebView");
    public string? basePath { get; set; } = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string executablePath { get; } = Application.ExecutablePath;

    public bool onFavorites { get; set; }

    private int maxBSave { get; } = 1;
    private int maxBSaveCount { get; set; }

    public List<dynamic> Instances { get; set; } = [];

    public void Init()
    {
        DeleteDataTask();
        AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        Application.ApplicationExit += Application_ApplicationExit;
        Instances = [];

        try
        {
            if (basePath is null or "") basePath = AppContext.BaseDirectory;

            SpawnTray();
        }
        catch (Exception ex)
        {
            MsgClass.Init(ex.Message, MessageBoxIcon.Error);
            Environment.Exit(1);
        }

        ;
    }

    public void SavePeriodically()
    {
        if (maxBSaveCount < maxBSave)
        {
            maxBSaveCount++;
        }
        else
        {
            CustomizeClass.Save_Customs(Instances);
            maxBSaveCount = 0;
        }

        ;
    }

    private void CurrentDomain_ProcessExit(object? sender, EventArgs e)
    {
        CustomizeClass.Save_Customs(Instances);
    }

    private void Application_ApplicationExit(object? sender, EventArgs e)
    {
        CustomizeClass.Save_Customs(Instances);
    }

    private void SpawnTray()
    {
        Icon_x = new NotifyIcon();
        try
        {
            Icon_x.Icon = Resources._16x;
        }
        catch (Exception ex)
        {
            MsgClass.Init(ex.Message, MessageBoxIcon.Error);
            Environment.Exit(1);
        }

        Icon_x.MouseClick += List_Instances;
        Icon_x.Visible = true;

        ContextMenuStrip contextMenu = new();

        ToolStripMenuItem AboutThis = new("About");
        AboutThis.Click += AboutThisMe;
        _ = contextMenu.Items.Add(AboutThis);

        ToolStripMenuItem Instancer = new("New Window");
        Instancer.Click += New_Instance;
        _ = contextMenu.Items.Add(Instancer);

        Objects = new ToolStripMenuItem("Instances");
        _ = contextMenu.Items.Add(Objects);

        ToolStripMenuItem menuItem1 = new("Settings");
        _ = contextMenu.Items.Add(menuItem1);

        AutoBoot = new ToolStripMenuItem("Auto Boot");
        AutoBoot.Click += setAutoBoot;
        _ = menuItem1.DropDownItems.Add(AutoBoot);

        ToolStripMenuItem Clear = new("Clear history");
        Clear.Click += Clear_Historic;
        _ = menuItem1.DropDownItems.Add(Clear);

        ToolStripMenuItem ClearData = new("Clear User Data");
        ClearData.Click += Clear_User_Data;
        _ = menuItem1.DropDownItems.Add(ClearData);

        ToolStripMenuItem setsclear = new("Clear settings");
        setsclear.Click += Clear_Settings;
        _ = menuItem1.DropDownItems.Add(setsclear);

        ToolStripMenuItem historic = new("Historic");
        historic.Click += History;
        _ = contextMenu.Items.Add(historic);

        ToolStripMenuItem menuItem2 = new("Exit");
        menuItem2.Click += Exit;
        _ = contextMenu.Items.Add(menuItem2);

        Icon_x.ContextMenuStrip = contextMenu;

        var data = AppSettings.ReadSettings();

        AutoBoot.CheckState = (bool)data["AutoBoot"] ? CheckState.Checked : CheckState.Unchecked;
        ;
        Application.Run();
    }

    protected void DeleteDataTask()
    {
        var data = AppSettings.ReadSettings();
        try
        {
            if ((bool)data["DeleteData"])
            {
                if (System.IO.Path.Exists(dataPath)) Directory.Delete(dataPath, true);

                ;
                data["DeleteData"] = false;
                AppSettings.WriteSettings(data);
            }

            ;
        }
        catch (Exception ex)
        {
            MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
        }

        ;
    }

    private void Clear_User_Data(object? sender, EventArgs e)
    {
        var data = AppSettings.ReadSettings();

        if (!(bool)data["DeleteData"])
        {
            try
            {
                data["DeleteData"] = true;
                AppSettings.WriteSettings(data);
                MsgClass.Init("Restart to apply settings.");
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
            }

            ;
        }

        ;
    }

    private void AboutThisMe(object? sender, EventArgs e)
    {
        if (AboutOfMe is not null)
        {
            if (AboutOfMe.IsDisposed)
            {
                AboutOfMe = new AboutMe(this);
                AboutOfMe.Show();
            }

            ;
        }
        else
        {
            AboutOfMe = new AboutMe(this);
            AboutOfMe.Show();
        }

        ;
    }

    private void History(object? sender, EventArgs e)
    {
        if (!onFavorites)
        {
            onFavorites = true;
            ListClass.Init(this, Db_manager.ReadCSV(hPath), "Historic");
        }

        ;
    }

    private void Clear_Historic(object? sender, EventArgs e)
    {
        try
        {
            if (File.Exists(hPath)) File.Delete(hPath);

            ;
        }
        catch (Exception es)
        {
            MsgClass.Init(es.Message, MessageBoxIcon.Warning);
        }

        ;
    }

    private void Clear_Settings(object? sender, EventArgs e)
    {
        try
        {
            if (File.Exists(path)) File.Delete(path);

            ;
        }
        catch (Exception ex)
        {
            MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
        }

        ;
    }

    private void List_Instances(object? sender, EventArgs e)
    {
        Objects.DropDownItems.Clear();
        var i = 0;
        foreach (BrowserUI? object_ in Instances)
        {
            if (object_ is null)
            {
                Instances.RemoveAt(i);
            }
            else if (object_.IsDisposed)
            {
                Instances.RemoveAt(i);
            }
            else
            {
                try
                {
                    var documentTitle = "";

                    _ = object_.Invoke(new MethodInvoker(delegate
                            {
                                try
                                {
                                    documentTitle = object_.webView21.CoreWebView2.DocumentTitle;
                                }
                                catch
                                {
                                    documentTitle = "Loading...";
                                }

                                ;
                            }
                        )
                    );
                    if (documentTitle is " " or "") documentTitle = "Loading...";

                    ;
                    ToolStripMenuItem Item = new(documentTitle);
                    Item.Click += (sender, e) => browser_focus(sender, e, object_);
                    _ = Objects.DropDownItems.Add(Item);
                }
                catch
                {
                }

                ;
            }

            ;
            i++;
        }

        ;
    }

    private void browser_focus(object? sender, EventArgs e, dynamic index)
    {
        index.Invoke(new MethodInvoker(delegate { index.Activate(); }));
    }

    private void New_Instance(object sender, EventArgs e)
    {
        SpawnActor.CreateInstance(this);
    }

    private void Exit(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void setAutoBoot(object sender, EventArgs e)
    {
        var data = AppSettings.ReadSettings();

        if ((bool)data["AutoBoot"])
        {
            try
            {
                Program.RegStart.DeleteValue("Web_Widget", false);
                data["AutoBoot"] = false;
                AutoBoot.CheckState = CheckState.Unchecked;
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
            }

            ;
        }
        else
        {
            try
            {
                Program.RegStart.SetValue("Web_Widget", executablePath);
                data["AutoBoot"] = true;
                AutoBoot.CheckState = CheckState.Checked;
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
            }

            ;
        }

        ;
        AppSettings.WriteSettings(data);
    }
}