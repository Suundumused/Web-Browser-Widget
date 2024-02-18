using Microsoft.Web.WebView2.Core;
using System.Reflection;
using WebBrowserWidget.Source.Internal.Local;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget
{
    public partial class BrowserUI : Form
    {
        public Point mouseLocation;

        public BrowserUI(dynamic? masterObject = null)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.ControlBox = false;
            InitializeComponent();
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartInstance();
        }

        private async Task InitBrowser()
        {
            string? base_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (base_path == null || base_path == "") 
            {
                base_path = AppContext.BaseDirectory;
            }

            string browseExe = Path.Combine(base_path, "Runtime", "Microsoft.WebView2.FixedVersionRuntime.121.0.2277.128.x86");
            string cacheFolder = Path.Combine(Program.basepath, "User", "Cache");

            //CoreWebView2Environment cwv2Environment = await CoreWebView2Environment.CreateAsync(browseExe, Path.Combine(Program.basepath, "Data"), new CoreWebView2EnvironmentOptions("--autoplay-    policy=no-user-gesture-required"));
            CoreWebView2Environment cwv2Environment = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Program.basepath, "Data"), new CoreWebView2EnvironmentOptions("--autoplay-    policy=no-user-gesture-required"));
            await webView21.EnsureCoreWebView2Async(cwv2Environment);
        }

        public async void StartInstance()
        {
            await InitBrowser();
            webView21.CoreWebView2.Navigate("https://www.google.com");
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
            }
        }

        private void close_called(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void NewInstance(object sender, EventArgs e)
        {
            //old
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
        }

        private void Maximize_Window(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            else if (this.WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Reload_Page(object sender, MouseEventArgs e)
        {
            webView21.Reload();
        }

        private void New_Window(object sender, MouseEventArgs e)
        {
            Thread ThreadA = new Thread(() => Program.NewThread());
            ThreadA.SetApartmentState(ApartmentState.STA);
            ThreadA.Start();
        }

        private void Go_Forward(object sender, MouseEventArgs e)
        {

            webView21.CoreWebView2.Navigate(extract_URL());
        }

        private void Swap_Forward(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webView21.CoreWebView2.Navigate(extract_URL());
            }
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
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*private void autoStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }*/
    }
}
