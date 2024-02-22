namespace WebBrowserWidget.Source.Internal.User_Interface.Master
{
    partial class ListViewWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListViewWindow));
            colorDialog1 = new ColorDialog();
            vScrollBar1 = new VScrollBar();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // colorDialog1
            // 
            colorDialog1.AnyColor = true;
            colorDialog1.Color = Color.LightSalmon;
            colorDialog1.ShowHelp = true;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Cursor = Cursors.SizeNS;
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Location = new Point(456, 0);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(17, 450);
            vScrollBar1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.Transparent;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(4, 9, 0, 9);
            panel1.Size = new Size(456, 450);
            panel1.TabIndex = 1;
            // 
            // ListViewWindow
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.MediumTurquoise;
            ClientSize = new Size(473, 450);
            Controls.Add(panel1);
            Controls.Add(vScrollBar1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListViewWindow";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.Sienna;
            Load += UpdateUI;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public ColorDialog colorDialog1;
        private VScrollBar vScrollBar1;
        private Panel panel1;
    }
}