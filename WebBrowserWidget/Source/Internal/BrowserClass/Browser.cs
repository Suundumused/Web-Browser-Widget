using WebBrowserWidget.Source.Public.Interfaces.BrowserClass;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.BrowserClass
{
    internal class Browser : iBrowser
    {
        public static void init(dynamic? masterObject = null)
        {
            Form BrowserUI = new BrowserUI(masterObject);
            //BrowserUI.Opacity = 0.67;

            try 
            {
                Application.Run(BrowserUI);
            }
            catch (Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error, false);
                System.Environment.Exit(1);
            }
            //Control panel1 = BrowserUI.Controls.Find("panel1", true)[0];
            //panel1.BackColor = BrowserUI.BackColor = Color.FromArgb((int)(0.6 * 255), BrowserUI.BackColor.R, BrowserUI.BackColor.G, BrowserUI.BackColor.B);
            //BrowserUI.Focus();
        }
    }
}
