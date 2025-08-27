using System.Reflection;
using Microsoft.Web.WebView2.Core;
using WebBrowserWidget.Source.Internal.Customize;
using WebBrowserWidget.Source.Internal.Master;
using WebBrowserWidget.Source.Internal.User_Interface.Master;
using WebBrowserWidget.Source.Internal.User_Interface.Settings;
using WebBrowserWidget.Source.Public.Utils;
using MethodInvoker = System.Windows.Forms.MethodInvoker;

namespace WebBrowserWidget.Source.Internal.User_Interface.BrowserClass;

public partial class BrowserUI : Form
{
    public dynamic manager;
    protected Point mouseLocation;

    public BrowserUI(dynamic masterObject, string? Deferral = null, dynamic? configs = null)
    {
        Local_configs = configs;
        MyDeferral = Deferral;
        manager = masterObject;
        manager.Instances.Add(this);

        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        ControlBox = false;
        InitializeComponent();
        FormClosing += MainForm_FormClosing;
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
    }

    public bool OnSettings { get; set; }
    public bool OnFavorites { get; set; }
    public dynamic? Local_configs { get; set; }
    public ListViewWindow? MineFavorites { get; set; } = null;
    public Local_Settings? MineSettings { get; set; } = null;

    protected bool FirstTime { get; set; } = true;

    public string? MyDeferral { get; set; }
    protected string H_path { get; } = Path.Combine(Program.basepath, "User", "historic.csv");
    protected string F_path { get; } = Path.Combine(Program.basepath, "User", "favorites.csv");

    public Rectangle MineMaximizedBounds
    {
        get => MaximizedBounds;
        set => MaximizedBounds = value;
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Customize_Class.Save_Customs(manager.Instances);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        MyDeferral = Customize_Class.Customize(this, MyDeferral, Local_configs);
        StartInstance();
    }

    public void SetOpacity(float newValue)
    {
        Opacity = newValue;
    }

    private async Task InitBrowser()
    {
        var base_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (base_path == null || base_path == "") base_path = AppContext.BaseDirectory;
        var browseExe = Path.Combine(base_path, "Runtime", "_version");
        var cacheFolder = Path.Combine(Program.basepath, "User", "Cache");

        //CoreWebView2Environment cwv2Environment = await CoreWebView2Environment.CreateAsync(browseExe, Path.Combine(Program.basepath, "Data"), new CoreWebView2EnvironmentOptions("--autoplay-    policy=no-user-gesture-required"));
        var cwv2Environment = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Program.basepath, "Data"),
            new CoreWebView2EnvironmentOptions("--autoplay-    policy=no-user-gesture-required"));
        await webView21.EnsureCoreWebView2Async(cwv2Environment);
    }

    private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
    {
        //e.NewWindow = (CoreWebView2)sender;
        SpawnActor.CreateInstance(manager, e.Uri);
        e.Handled = true;
    }

    public async void StartInstance()
    {
        await InitBrowser();
        webView21.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
        if (MyDeferral != null)
        {
            try
            {
                webView21.CoreWebView2.Navigate(MyDeferral);
            }
            catch (Exception ex)
            {
                webView21.CoreWebView2.Navigate("https://www.google.com");
                MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
            }

            ;
            BringToFront();
            Activate();
        }
        else
        {
            webView21.CoreWebView2.Navigate("https://www.google.com");
        }

        ;
    }

    private void move_mouse_Down(object sender, MouseEventArgs e)
    {
        mouseLocation = new Point(-e.X, e.Y);
    }

    private void mouse_move_Up(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            var mousePose = MousePosition;
            mousePose.Offset(mouseLocation.X, mouseLocation.Y - 50);
            Location = mousePose;
        }

        ;
    }

    private void close_called(object sender, MouseEventArgs e)
    {
        manager.Instances.Remove(this);
        Close();
    }

    private void End_Application(object sender, MouseEventArgs e)
    {
        Application.Exit();
    }

    private void Browser_advance(object sender, MouseEventArgs e)
    {
        webView21.GoForward();
    }

    private void Browser_back(object sender, MouseEventArgs e)
    {
        webView21.GoBack();
    }

    private void Navigation_Completed(object sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        textBox1.Text = webView21.Source.ToString();

        var currentDateTime = DateTime.Now;
        var formattedDateTime = currentDateTime.ToString("dd MMMM yyyy HH:mm");

        manager.SavePeriodically();
        if (FirstTime)
            FirstTime = false;
        else
            Db_manager.AddColumnsAndRows(H_path, (formattedDateTime, webView21.Source.ToString()), ("Date", "Url"));
        ;
    }

    private void Maximize_Window(object sender, MouseEventArgs e)
    {
        var area = Screen.FromHandle(Handle).WorkingArea;

        Size = new Size(area.Width, area.Height);
        Location = new Point(area.X, area.Y);
    }

    private void Reload_Page(object sender, MouseEventArgs e)
    {
        webView21.Reload();
    }

    private void New_Window(object sender, MouseEventArgs e)
    {
        SpawnActor.CreateInstance(manager);
    }

    private void Go_Forward(object sender, MouseEventArgs e)
    {
        try
        {
            webView21.CoreWebView2.Navigate(extract_URL());
        }
        catch (Exception ex)
        {
            MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
        }

        ;
    }

    private void Swap_Forward(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            try
            {
                webView21.CoreWebView2.Navigate(extract_URL());
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
            }

            ;
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        ;
    }

    public string extract_URL()
    {
        if (textBox1.Text.Contains("://") && textBox1.Text.Contains(".")) return textBox1.Text;

        if (textBox1.Text.Contains("://")) return $"{textBox1.Text}.com";

        if (textBox1.Text.Contains(".")) return $"https://{textBox1.Text}";

        return $"https://www.google.com/search?q={textBox1.Text}";
        ;
    }

    private void Local_Settings(object sender, MouseEventArgs e)
    {
        if (!OnSettings)
        {
            OnSettings = true;
            SettingsClass.Settings.Sets(this);
        }

        ;
    }

    private void Favorites_Pressed(object sender, MouseEventArgs e)
    {
        if (!OnFavorites)
        {
            OnFavorites = true;
            ListClass.Init(this, Db_manager.ReadCSV(F_path), "Favorites");
        }

        ;
    }

    private void WhenClosed(object sender, FormClosedEventArgs e)
    {
        Thread.CurrentThread.Interrupt();
    }

    private void WhenClosing(object sender, FormClosingEventArgs e)
    {
        if (MineFavorites is not null)
        {
            if (!MineFavorites.IsDisposed) MineFavorites.Invoke(new MethodInvoker(delegate { MineFavorites.Close(); }));
            ;
        }

        ;

        if (MineSettings is not null)
        {
            if (!MineSettings.IsDisposed) MineSettings.Invoke(new MethodInvoker(delegate { MineSettings.Close(); }));
            ;
        }

        ;
    }
}