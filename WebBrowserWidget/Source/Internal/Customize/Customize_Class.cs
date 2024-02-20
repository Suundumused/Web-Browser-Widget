using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowserWidget.Source.Public.Interfaces.CustomsClass;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.Customize
{
    internal class Customize_Class : iCustomsClass
    {
        public static string Customize(dynamic instance, string myDeferral, dynamic local_configs)
        {
            try
            {
                if (local_configs != null)
                {
                    foreach (var key in local_configs)
                    {
                        myDeferral = key["URL"];

                        if (key["Maximized?"] != false)
                        {
                            //instance.MaximizedBounds = Screen.FromHandle(instance.Handle).WorkingArea;
                            instance.WindowState = FormWindowState.Maximized;
                        }
                        else
                        {
                            instance.WindowState = FormWindowState.Normal;
                        }

                        string[] Values = Convert.ToString(key["Sizes"]).Replace(" ", "").Split(",");
                        instance.Size = new Size(Convert.ToInt32(Values[0]), Convert.ToInt32(Values[1]));

                        instance.Opacity = (float)key["Opacity"];

                        string[] ValuesB = Convert.ToString(key["BarColor"]).Replace(" ", "").Split(",");
                        instance.panel2.BackColor = Color.FromArgb(Convert.ToInt32(ValuesB[0]), Convert.ToInt32(ValuesB[1]), Convert.ToInt32(ValuesB[2]));

                        string[] ValuesC = Convert.ToString(key["Position"]).Replace(" ", "").Split(",");
                        if (Convert.ToInt32(ValuesC[0]) > 0 && Convert.ToInt32(ValuesC[1]) > 0)
                        {
                            instance.Location = new Point(Convert.ToInt32(ValuesC[0]), Convert.ToInt32(ValuesC[1]));
                        };
                    };
                };
            }
            catch (Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
            }
            return myDeferral;
        }
    }
}
