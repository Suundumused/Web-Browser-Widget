namespace WebBrowserWidget.Source.Public.Utils
{
    public class db_manager
    {
        private static (string, string) Keys { get; set; } = ("", "");

        public static void AddColumnsAndRows(string inputFile, (string, string) t1, (string, string) keys)
        {
            Keys = keys;
            string[] newRowData = { t1.Item1, t1.Item2 };
            AddRowToCsv(inputFile, newRowData);
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
            }
        } 

        private static void AddRowToCsv(string filePath, string[] rowData)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, string.Join(",", GetColumnNames()) + Environment.NewLine);
                }

                if (!IsLastDuplicate(filePath, rowData))
                {
                    using (StreamWriter streamWriter = File.AppendText(filePath))
                    {
                        streamWriter.WriteLine(string.Join(",", rowData));
                    }
                }
            }
            catch(Exception ex) 
            {
                MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
            }
        }

        private static string[] GetColumnNames()
        {
            return new string[] { Keys.Item1, Keys.Item2 };
        }
    }
}
