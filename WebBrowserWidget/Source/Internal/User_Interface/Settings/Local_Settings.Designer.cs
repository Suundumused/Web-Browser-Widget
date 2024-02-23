namespace WebBrowserWidget.Source.Internal.User_Interface.Settings
{
    partial class Local_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Local_Settings));
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button1 = new Button();
            trackBar1 = new TrackBar();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.Transparent;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel1.RightToLeft = RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.Salmon;
            splitContainer1.Panel2.BackgroundImageLayout = ImageLayout.None;
            splitContainer1.Panel2.Controls.Add(flowLayoutPanel2);
            splitContainer1.Panel2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            splitContainer1.Panel2.ForeColor = Color.Transparent;
            splitContainer1.Size = new Size(467, 444);
            splitContainer1.SplitterDistance = 155;
            splitContainer1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = Color.LightGray;
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.ForeColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 3, 0, 3);
            flowLayoutPanel1.Size = new Size(155, 444);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.MediumTurquoise;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(55, 12);
            label2.Margin = new Padding(0, 9, 0, 0);
            label2.MinimumSize = new Size(100, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 3, 0, 3);
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(100, 24);
            label2.TabIndex = 2;
            label2.Text = "Bar Color";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.MediumTurquoise;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(55, 45);
            label1.Margin = new Padding(0, 9, 0, 0);
            label1.MinimumSize = new Size(100, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 3, 0, 3);
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(100, 24);
            label1.TabIndex = 1;
            label1.Text = "Opacity";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.BackColor = Color.LightSalmon;
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Controls.Add(trackBar1);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(3, 3, 0, 3);
            flowLayoutPanel2.Size = new Size(308, 444);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumTurquoise;
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Top;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 13);
            button1.Margin = new Padding(9, 10, 15, 0);
            button1.MaximumSize = new Size(0, 24);
            button1.MinimumSize = new Size(100, 0);
            button1.Name = "button1";
            button1.Size = new Size(294, 23);
            button1.TabIndex = 4;
            button1.Text = "ººº";
            button1.UseVisualStyleBackColor = false;
            button1.MouseUp += Change_Color;
            // 
            // trackBar1
            // 
            trackBar1.Cursor = Cursors.SizeWE;
            trackBar1.Dock = DockStyle.Top;
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(3, 45);
            trackBar1.Margin = new Padding(0, 9, 9, 0);
            trackBar1.MaximumSize = new Size(0, 24);
            trackBar1.Minimum = 3;
            trackBar1.MinimumSize = new Size(309, 0);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(309, 24);
            trackBar1.TabIndex = 3;
            trackBar1.TickFrequency = 2;
            trackBar1.Value = 9;
            trackBar1.Scroll += Change_Opacity;
            // 
            // colorDialog1
            // 
            colorDialog1.AnyColor = true;
            colorDialog1.Color = Color.LightSalmon;
            colorDialog1.ShowHelp = true;
            // 
            // Local_Settings
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.MediumTurquoise;
            ClientSize = new Size(473, 450);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Local_Settings";
            Opacity = 0.95D;
            Padding = new Padding(3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Local Settings";
            TransparencyKey = Color.Sienna;
            FormClosing += OnClose;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel2;
        public TrackBar trackBar1;
        private Label label2;
        private Button button1;
        public ColorDialog colorDialog1;
    }
}