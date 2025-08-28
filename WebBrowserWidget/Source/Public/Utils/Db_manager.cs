namespace WebBrowserWidget.Source.Public.Utils;

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
            List<string> lines = [.. File.ReadAllLines(filePath)];
            if (lines.Count() > 500)
            {
                lines.RemoveAt(1);
                File.WriteAllLines(filePath, lines);
            }

            ;
            var lastLine = lines[lines.Count() - 1];

            return rowData[1].Trim() == lastLine.Trim().Split(",")[1];
        }
        catch (IOException)
        {
            return true;
        }

        ;
    }

    public static void RemoveLineIndex(string filePath, long index = 0)
    {
        try
        {
            List<string> lines = [.. File.ReadAllLines(filePath)];

            lines.RemoveAt(Convert.ToInt32(index));
            File.WriteAllLines(filePath, lines);
        }
        catch (Exception ex)
        {
            MsgClass.Init(ex.Message, MessageBoxIcon.Warning);
        }

        ;
    }

    public static List<string> ReadCSV(string filePath)
    {
        try
        {
            return File.Exists(filePath) ? [.. File.ReadAllLines(filePath)] : [];
            ;
        }
        catch
        {
            return [];
        }

        ;
    }

    private static bool AddRowToCsv(string filePath, string[] rowData)
    {
        try
        {
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, string.Join(",", GetColumnNames()) + Environment.NewLine);

            ;

            if (!IsLastDuplicate(filePath, rowData))
            {
                using (var streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(string.Join(",", rowData));
                }

                ;
                return true;
            }

            return false;
            ;
        }
        catch
        {
            return false;
        }

        ;
    }

    private static string[] GetColumnNames()
    {
        return new[] { Keys.Item1, Keys.Item2 };
    }
}