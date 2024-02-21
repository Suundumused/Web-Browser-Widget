using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.Local
{
    internal static class AppSettings
    {
        public static JObject Properties = new JObject(
            new JProperty("AutoBoot", true),
            new JProperty("Instances", new JObject(
                new JProperty("Instance_0", new JObject(
                    new JProperty("URL", "https://www.google.com/"),
                    new JProperty("Maximized?", false),
                    new JProperty("Sizes", new JArray(1107, 646)),
                    new JProperty("Opacity", 0.9),
                    new JProperty("BarColor", new JArray(255, 160, 122)),
                    new JProperty("Position", new JArray(-1, -1))
                ))
            ))
        );

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

        public static JObject ReadSettings()
        {
            try
            {
                if (UserSettingsExists())
                {
                    return JObject.Parse(File.ReadAllText(file_path));
                }
                else
                {
                    return Properties;
                }
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
                return Properties;
            }
        }

        public static void WriteSettings(JObject data)
        {
            try
            {
                if (!UserSettingsExists())
                {
                    using (File.Create(file_path)) { }
                }
                using (StreamWriter file = File.CreateText(file_path))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    writer.Formatting = Formatting.Indented;
                    data.WriteTo(writer);
                };
            }
            catch (Exception e)
            {
                MsgClass.Init(e.Message, MessageBoxIcon.Error);
            }
        }
    }
}
