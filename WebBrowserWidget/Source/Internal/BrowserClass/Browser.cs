using System.Collections.Generic;
using System.Windows.Forms;
using WebBrowserWidget.Source.Public.Interfaces.BrowserClass;

namespace WebBrowserWidget.Source.Internal.BrowserClass
{
    internal class Browser : iBrowser
    {
        public static void init()
        {
            Form BrowserUI = new BrowserUI();
            BrowserUI.Opacity = 0.67;

            Application.Run(BrowserUI);

            //Control panel1 = BrowserUI.Controls.Find("panel1", true)[0];
            //panel1.BackColor = BrowserUI.BackColor = Color.FromArgb((int)(0.6 * 255), BrowserUI.BackColor.R, BrowserUI.BackColor.G, BrowserUI.BackColor.B);
            //BrowserUI.Focus();
        }
    }
}
