using Newtonsoft.Json.Linq;
using WebBrowserWidget.Source.Internal.Local;
using WebBrowserWidget.Source.Public.Interfaces.CustomsClass;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.Customize
{
    internal class Customize_Class : iCustomsClass
    {
        private static bool WinState(FormWindowState value)
        {
            if (value == FormWindowState.Maximized) 
            {
                return true;
            }
            else 
            {
                return false;
            };
        }

        public static string Customize(dynamic instance, string myDeferral, dynamic local_configs)
        {
            try
            {
                if (local_configs != null)
                {
                    foreach (dynamic key in local_configs)
                    {
                        myDeferral = key["URL"];

                        JArray sizesArray = (JArray)key["Sizes"];
                        instance.Size = new Size(sizesArray[0].Value<int>(), sizesArray[1].Value<int>());

                        instance.Opacity = (float)key["Opacity"];

                        JArray BarColorsArray = (JArray)key["BarColor"];
                        instance.panel2.BackColor = Color.FromArgb(BarColorsArray[0].Value<int>(), BarColorsArray[1].Value<int>(), BarColorsArray[2].Value<int>());

                        JArray PositionArray = (JArray)key["Position"];
                        instance.Location = new Point(PositionArray[0].Value<int>(), PositionArray[1].Value<int>());
                    };
                };
            }
            catch (Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
            }
            return myDeferral;
        }

        public static void Save_Customs(dynamic Instances) 
        {
            try
            {
                JObject data = AppSettings.ReadSettings();

                List<JObject> dicts_list = new List<JObject>();

                foreach (dynamic obj in Instances)
                {
                    if (obj is not null) 
                    {
                        dicts_list.Add(new JObject(
                            new JProperty("URL", obj.webView21.Source),
                            new JProperty("Sizes", new JArray(obj.Size.Width, obj.Size.Height)),
                            new JProperty("Opacity", obj.Opacity),
                            new JProperty("BarColor", new JArray(obj.panel2.BackColor.R, obj.panel2.BackColor.G, obj.panel2.BackColor.B)),
                            new JProperty("Position", new JArray(obj.Location.X, obj.Location.Y))
                            )
                        );
                    };     
                };

                JObject? mineinstances = data["Instances"] as JObject;
                List<JProperty>? propertiesToDelete = mineinstances.Properties().Where(p => p.Name.StartsWith("Instance_")).ToList();
                foreach (JProperty property in propertiesToDelete)
                {
                    property.Remove();
                }

                int i = 0;
                foreach (JObject dict in dicts_list) 
                {
                    data["Instances"][$"Instance_{i}"] = dict;
                    i++;
                };
                AppSettings.WriteSettings(data);
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
            };
        }
    }
}
