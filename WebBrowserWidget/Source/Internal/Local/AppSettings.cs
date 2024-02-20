using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.Local
{
    internal static class AppSettings
    {
        public static Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>
        {
            { "AutoBoot", true },
            { "Instances", new Dictionary<string, object>
            {
                { "Instance_0", new Dictionary<string, object>
                {
                    { "URL", "https://www.google.com/" },
                    { "Maximized?", false },
                    { "Sizes", "1107, 646" },
                    { "Opacity", 0.9 },
                    { "BarColor", "255, 160, 122" },
                    { "Position", "-1, -1" }
                }
                }
            }
            }
        };

        public static string file_path = Path.Combine(Program.basepath, "Settings", "User_Settings.json");

        public static bool UserSettingsExists()
        {
            try
            {
                return File.Exists(file_path);

            }
            catch (Exception e)
            {
                MsgClass.Init(e.Message, MessageBoxIcon.Error);
                return false;
            }
        }

        public static dynamic ReadSettings()
        {
            try
            {
                if (UserSettingsExists())
                {
                    return JObject.Parse(File.ReadAllText(file_path));
                }
                else
                {
                    return JObject.Parse("{" + string.Join(",", Properties.Select(kv => kv.Key + "=" + kv.Value).ToArray()) + "}");
                }
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
                return Properties;
            }
        }

        public static void WriteSettings(object data)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string jsonString = System.Text.Json.JsonSerializer.Serialize(data, options);

                if (!UserSettingsExists())
                {
                    using (File.Create(file_path)) { }
                }
                File.WriteAllText(file_path, jsonString);
            }
            catch (Exception e)
            {
                MsgClass.Init(e.Message, MessageBoxIcon.Error);
            }
        }
    }
}
