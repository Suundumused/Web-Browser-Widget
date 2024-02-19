namespace WebBrowserWidget.Source.Internal.User_Interface.Settings
{
    public partial class Local_Settings : Form
    {
        private dynamic? myParent { get; set; } = null;

        public Local_Settings(dynamic? Parent)
        {
            myParent = Parent;

            InitializeComponent();
            BringToFront();
            Activate();
        }

        private void Change_Opacity(object sender, EventArgs e)
        {
            myParent.Opacity = Convert.ToInt32(trackBar1.Value) / 10f;
        }

        private void Change_Color(object sender, MouseEventArgs e)
        {
            colorDialog1.Color = myParent.panel2.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK) 
            {
                myParent.panel2.BackColor = colorDialog1.Color;
            }
        }
    }
}
