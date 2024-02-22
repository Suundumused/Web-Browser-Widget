using System;
using System.Diagnostics;
using System.Reflection;

namespace WebBrowserWidget.Source.Internal.User_Interface.Settings
{
    public partial class Local_Settings : Form
    {
        private dynamic myParent { get; set; }

        public Local_Settings(dynamic Parent)
        {
            myParent = Parent;
            InitializeComponent();
            UpdateUI();
            BringToFront();
            Activate();
        }

        private void Change_Opacity(object sender, EventArgs e)
        {
            int trackbar_value = trackBar1.Value;
            myParent.Invoke(new System.Windows.Forms.MethodInvoker(delegate { myParent.SetOpacity(Convert.ToInt32(trackbar_value) / 10f); }));
        }

        private void Change_Color(object sender, MouseEventArgs e)
        {
            colorDialog1.Color = myParent.panel2.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                myParent.panel2.BackColor = colorDialog1.Color;
            }
        }

        private void UpdateUI()
        {
            trackBar1.Value = Convert.ToInt32(myParent.Opacity * 10);
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            myParent.OnSettings = false;
        }
    }
}
