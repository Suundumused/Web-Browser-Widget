namespace WebBrowserWidget
{
    partial class BrowserUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserUI));
            panel1 = new Panel();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel2 = new Panel();
            button5 = new Button();
            button8 = new Button();
            button7 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            button4 = new Button();
            button6 = new Button();
            button1 = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(webView21);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1091, 607);
            panel1.TabIndex = 0;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.BackColor = Color.Black;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.Transparent;
            webView21.Dock = DockStyle.Fill;
            webView21.ForeColor = Color.Black;
            webView21.Location = new Point(0, 48);
            webView21.Name = "webView21";
            webView21.Size = new Size(1091, 559);
            webView21.TabIndex = 1;
            webView21.ZoomFactor = 1D;
            webView21.NavigationCompleted += Navigation_Completed;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.BackColor = Color.LightSalmon;
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(button7);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button3);
            panel2.Dock = DockStyle.Top;
            panel2.ForeColor = Color.Transparent;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(0);
            panel2.MaximumSize = new Size(0, 48);
            panel2.MinimumSize = new Size(48, 48);
            panel2.Name = "panel2";
            panel2.Size = new Size(1091, 48);
            panel2.TabIndex = 0;
            panel2.MouseDown += move_mouse_Down;
            panel2.MouseMove += mouse_move_Up;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Cursor = Cursors.Hand;
            button5.Dock = DockStyle.Right;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(899, 0);
            button5.Margin = new Padding(0);
            button5.Name = "button5";
            button5.Size = new Size(48, 48);
            button5.TabIndex = 9;
            button5.UseVisualStyleBackColor = false;
            button5.MouseUp += Local_Settings;
            // 
            // button8
            // 
            button8.BackColor = Color.Transparent;
            button8.BackgroundImage = (Image)resources.GetObject("button8.BackgroundImage");
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            button8.Cursor = Cursors.Hand;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(230, 0);
            button8.Margin = new Padding(0);
            button8.Name = "button8";
            button8.Size = new Size(48, 48);
            button8.TabIndex = 8;
            button8.UseVisualStyleBackColor = false;
            button8.MouseUp += Favorites_Pressed;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.BackgroundImage = (Image)resources.GetObject("button7.BackgroundImage");
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button7.Cursor = Cursors.Hand;
            button7.Dock = DockStyle.Right;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(947, 0);
            button7.Margin = new Padding(0);
            button7.Name = "button7";
            button7.Size = new Size(48, 48);
            button7.TabIndex = 7;
            button7.UseVisualStyleBackColor = false;
            button7.MouseUp += New_Window;
            // 
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.AcceptsTab = true;
            textBox1.AllowDrop = true;
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.ForeColor = SystemColors.GradientInactiveCaption;
            textBox1.Location = new Point(288, 11);
            textBox1.Margin = new Padding(0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(400, 27);
            textBox1.TabIndex = 3;
            textBox1.WordWrap = false;
            textBox1.KeyDown += Swap_Forward;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Cursor = Cursors.Hand;
            button2.Dock = DockStyle.Left;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(96, 0);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(48, 48);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = false;
            button2.MouseUp += Browser_advance;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Cursor = Cursors.Hand;
            button4.Dock = DockStyle.Right;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.Transparent;
            button4.Location = new Point(995, 0);
            button4.Margin = new Padding(0);
            button4.Name = "button4";
            button4.Size = new Size(48, 48);
            button4.TabIndex = 4;
            button4.UseVisualStyleBackColor = false;
            button4.MouseUp += Maximize_Window;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.Cursor = Cursors.Hand;
            button6.Dock = DockStyle.Left;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(48, 0);
            button6.Margin = new Padding(0);
            button6.Name = "button6";
            button6.Size = new Size(48, 48);
            button6.TabIndex = 6;
            button6.UseVisualStyleBackColor = false;
            button6.MouseUp += Reload_Page;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Left;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(48, 48);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.MouseUp += Browser_back;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Cursor = Cursors.Hand;
            button3.Dock = DockStyle.Right;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Transparent;
            button3.Location = new Point(1043, 0);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new Size(48, 48);
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = false;
            button3.MouseUp += close_called;
            // 
            // BrowserUI
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            ClientSize = new Size(1091, 607);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(518, 250);
            Name = "BrowserUI";
            Opacity = 0.9D;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.LavenderBlush;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Panel panel1;
        public Panel panel2;
        public Button button1;
        public Button button2;
        public Button button3;
        public Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        public TextBox textBox1;
        public Button button4;
        public Button button6;
        public Button button7;
        public Button button8;
        public Button button5;
    }
}
