using Microsoft.Web.WebView2.Core;
using System.Reflection;
using WebBrowserWidget.Source.Internal.Customize;
using WebBrowserWidget.Source.Internal.Master;
using WebBrowserWidget.Source.Internal.SettingsClass;
using WebBrowserWidget.Source.Internal.User_Interface.Master;
using WebBrowserWidget.Source.Internal.User_Interface.Settings;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget
{
    public partial class BrowserUI : Form
    {
        public bool OnSettings { get; set; } = false;
        public bool OnFavorites { get; set; } = false;
        public dynamic manager;
        public dynamic? Local_configs { get; set; } = null;
        public ListViewWindow? MineFavorites { get; set; } = null;
        public Local_Settings? MineSettings { get; set; } = null;

        protected Point mouseLocation;

        public string? MyDeferral { get; set; } = null;
        protected string H_path { get; } = Path.Combine(Program.basepath, "User", "historic.csv");
        protected string F_path { get; } = Path.Combine(Program.basepath, "User", "favorites.csv");

        public BrowserUI(dynamic masterObject, string? Deferral = null, dynamic? configs = null)
        {
            Local_configs = configs;
            MyDeferral = Deferral;
            manager = masterObject;
            manager.Instances.Add(this);

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.ControlBox = false;
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
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

        public System.Drawing.Rectangle MineMaximizedBounds
        {
            get { return MaximizedBounds; }
            set { MaximizedBounds = value; }
        }

        private async Task InitBrowser()
        {
            string? base_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (base_path == null || base_path == "")
            {
                base_path = AppContext.BaseDirectory;
            }

            string browseExe = Path.Combine(base_path, "Runtime", "_version");
            string cacheFolder = Path.Combine(Program.basepath, "User", "Cache");

            //CoreWebView2Environment cwv2Environment = await CoreWebView2Environment.CreateAsync(browseExe, Path.Combine(Program.basepath, "Data"), new CoreWebView2EnvironmentOptions("--autoplay-    policy=no-user-gesture-required"));
            CoreWebView2Environment cwv2Environment = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Program.basepath, "Data"), new CoreWebView2EnvironmentOptions("--autoplay-    policy=no-user-gesture-required"));
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
                };
                BringToFront();
                Activate();
            }
            else
            {
                webView21.CoreWebView2.Navigate("https://www.google.com");
            };
        }

        private void move_mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, e.Y);
        }

        private void mouse_move_Up(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y - 50);
                Location = mousePose;
            };
        }

        private void close_called(object sender, MouseEventArgs e)
        {
            manager.Instances.Remove(this);
            this.Close();
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

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("dd MMMM yyyy HH:mm");

            manager.SavePeriodically();
            Db_manager.AddColumnsAndRows(H_path, (formattedDateTime, webView21.Source.ToString()), ("Date", "Url"));
        }

        private void Maximize_Window(object sender, MouseEventArgs e)
        {
            Rectangle area = Screen.FromHandle(this.Handle).WorkingArea;

            this.Size = new System.Drawing.Size(area.Width, area.Height);
            this.Location = new System.Drawing.Point(area.X, area.Y);
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
            };
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
                };
                e.Handled = true;
                e.SuppressKeyPress = true;
            };
        }

        public string extract_URL()
        {
            if (textBox1.Text.Contains("://") && textBox1.Text.Contains("."))
            {
                return textBox1.Text;
            }
            else if (textBox1.Text.Contains("://"))
            {
                return $"{textBox1.Text}.com";
            }
            else if (textBox1.Text.Contains("."))
            {
                return $"https://{textBox1.Text}";
            }
            else
            {
                return $"https://www.google.com/search?q={textBox1.Text}";
            };
        }

        private void Local_Settings(object sender, MouseEventArgs e)
        {
            if (!OnSettings)
            {
                OnSettings = true;
                Settings.Sets(this);
            };
        }

        private void Favorites_Pressed(object sender, MouseEventArgs e)
        {
            if (!OnFavorites)
            {
                OnFavorites = true;
                ListClass.Init(this, Db_manager.ReadCSV(F_path), "Favorites", "navigate");
            };
        }

        private void WhenClosed(object sender, FormClosedEventArgs e)
        {
            Thread.CurrentThread.Interrupt();
        }

        private void WhenClosing(object sender, FormClosingEventArgs e)
        {
            if (MineFavorites is not null)
            {
                if (!MineFavorites.IsDisposed)
                {
                    MineFavorites.Invoke(new System.Windows.Forms.MethodInvoker(delegate { MineFavorites.Close(); }));
                };
            };

            if (MineSettings is not null)
            {
                if (!MineSettings.IsDisposed)
                {
                    MineSettings.Invoke(new System.Windows.Forms.MethodInvoker(delegate { MineSettings.Close(); }));
                };
            };
        }
    }
}
