using System.Text.Json;
using System.Xml.Linq;
using WebBrowserWidget.Source.Public.Utils;

namespace WebBrowserWidget.Source.Internal.Local
{
    internal static class AppSettings
    {
        public class MyData
        {
            public bool AutoBoot { get; set; } = true;
        }

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

        public static dynamic? ReadSettings()
        {
            try
            {
                if (UserSettingsExists())
                {
                    string jsonText = File.ReadAllText(file_path);

                    return JsonSerializer.Deserialize<MyData>(jsonText);
                }
                else
                {
                    return new MyData();
                }
            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Error);
                return new MyData();
            }
        }

        public static void WriteSettings(object data)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(data);

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
