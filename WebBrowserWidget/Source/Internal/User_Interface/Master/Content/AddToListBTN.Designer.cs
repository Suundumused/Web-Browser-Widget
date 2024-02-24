namespace WebBrowserWidget.Source.Internal.User_Interface.Master.Content
{
    partial class AddToListBTN
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
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("Impact", 16F, FontStyle.Bold);
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(0);
            button1.MaximumSize = new Size(0, 48);
            button1.MinimumSize = new Size(440, 48);
            button1.Name = "button1";
            button1.Size = new Size(440, 48);
            button1.TabIndex = 0;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.MouseUp += OnClick;
            // 
            // AddToListBTN
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(button1);
            Margin = new Padding(0);
            MaximumSize = new Size(0, 48);
            MinimumSize = new Size(440, 48);
            Name = "AddToListBTN";
            Padding = new Padding(0, 0, 3, 0);
            Size = new Size(440, 48);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}
