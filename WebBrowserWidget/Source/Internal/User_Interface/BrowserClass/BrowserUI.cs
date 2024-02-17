using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using WebBrowserWidget.Source.Internal.BrowserClass;
using WebBrowserWidget.Source.Public.Interfaces.BrowserClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WebBrowserWidget
{
    public partial class BrowserUI : Form
    {
        public List<Thread>? Instances;
        public Int64 I { get; set; }

        public Point mouseLocation;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0xC00000;
                return cp;
            }
        }

        public BrowserUI()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.ControlBox = false;
            InitializeComponent();
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            //webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartInstance();
        }

        /*private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            // WebView2 initialization completed
            if (e.IsSuccess)
            {
                // WebView2 is ready to be used
            }
            else
            {
                // Handle initialization failure
                MessageBox.Show($"WebView2 initialization failed. Error: {e.InitializationException}");
            }
        }*/

        private async Task InitBrowser()
        {
            await webView21.EnsureCoreWebView2Async();
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
    }
}
