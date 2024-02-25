namespace WebBrowserWidget.Source.Internal.User_Interface.Master.Content
{
    partial class UserClick
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserClick));
            label1 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Orange;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.MinimumSize = new Size(400, 24);
            label1.Name = "label1";
            label1.Padding = new Padding(8, 0, 0, 0);
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(400, 24);
            label1.TabIndex = 5;
            label1.Text = "Bar Color";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.MouseDown += Click_Color;
            label1.MouseLeave += Leave_Color;
            label1.MouseHover += Hover_Color;
            label1.MouseUp += event_click;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            button1.ForeColor = Color.Transparent;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(533, 0);
            button1.Margin = new Padding(0);
            button1.MaximumSize = new Size(24, 24);
            button1.MinimumSize = new Size(24, 24);
            button1.Name = "button1";
            button1.Size = new Size(24, 24);
            button1.TabIndex = 6;
            button1.UseVisualStyleBackColor = false;
            button1.MouseUp += Clicked;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.MinimumSize = new Size(400, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(557, 48);
            panel1.TabIndex = 7;
            // 
            // UserClick
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(button1);
            Controls.Add(panel1);
            Margin = new Padding(0);
            MaximumSize = new Size(0, 42);
            MinimumSize = new Size(400, 48);
            Name = "UserClick";
            Size = new Size(557, 48);
            Load += OnLoaded;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Panel panel1;
    }
}
