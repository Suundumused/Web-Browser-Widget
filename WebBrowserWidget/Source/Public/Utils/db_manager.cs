using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowserWidget.Source.Public.Utils
{
    public class db_manager
    {
        public static void AddColumnsAndRows(string inputFile, (string, string) t1)
        {
            // Data for the new row
            string[] newRowData = { t1.Item1, t1.Item2 };

            AddRowToCsv(inputFile, newRowData);
        }

        private static void AddRowToCsv(string filePath, string[] rowData)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Join(",", GetColumnNames()) + Environment.NewLine);
            }

            // Append the new row to the existing file
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine(string.Join(",", rowData));
            }
        }

        private static string[] GetColumnNames()
        {
            return new string[] { "Date", "Url" };
        }
    }
}
