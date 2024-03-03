namespace WebBrowserWidget.Source.Public.Utils
{
    public class Db_manager
    {
        private static (string, string) Keys { get; set; } = ("", "");

        public static bool AddColumnsAndRows(string inputFile, (string, string) t1, (string, string) keys)
        {
            Keys = keys;
            string[] newRowData = { t1.Item1, t1.Item2 };
            return AddRowToCsv(inputFile, newRowData);
        }

        private static bool IsLastDuplicate(string filePath, string[] rowData) 
        {
            try
            {
                List<string>? lines = new List<string>(File.ReadAllLines(filePath));
                if (lines.Count() > 500)
                {
                    lines.RemoveAt(1);
                    File.WriteAllLines(filePath, lines);
                };
                string lastLine = lines[lines.Count() - 1];

                return (rowData[1].Trim() == lastLine.Trim().Split(",")[1]);
            }
            catch (IOException)
            {
                return true;
            };
        }

        public static void RemoveLineIndex(string filePath, long index = 0)
        {
            try
            {
                List<string>? lines = new List<string>(File.ReadAllLines(filePath));

                lines.RemoveAt(Convert.ToInt32(index));
                File.WriteAllLines(filePath, lines);

            }
            catch (Exception ex)
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
            };
        }

        public static List<string> ReadCSV(string filePath) 
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return new List<string>(File.ReadAllLines(filePath));
                }
                else
                {
                    return new List<string>();
                };

            }catch
            {
                return new List<string>();
            };
        }

        private static bool AddRowToCsv(string filePath, string[] rowData)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Join(",", GetColumnNames()) + Environment.NewLine);
                };

                if (!IsLastDuplicate(filePath, rowData))
                {
                    using (StreamWriter streamWriter = File.AppendText(filePath))
                    {
                        streamWriter.WriteLine(string.Join(",", rowData));
                    };
                    return true;
                }
                else 
                {
                    return false;
                };
            }
            catch
            {
                return false;
            };
        }

        private static string[] GetColumnNames()
        {
            return new string[] { Keys.Item1, Keys.Item2 };
        }
    }
}
