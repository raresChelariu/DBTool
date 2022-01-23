using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace DBTool
{
    public class Utils
    {
        public static DataTable CSV2DataTable(string csvString)
        {
            var result = new DataTable();

            const string REGEX_SPLIT_LINES = "\r\n|\r|\n";

            var csvStringLines = Regex.Split(csvString, REGEX_SPLIT_LINES);

            var headerColumns = csvStringLines[0].Split(',');
            headerColumns.ToList().ForEach(header =>
            {
                result.Columns.Add(header, typeof(string));
            });

            for (var i = 1; i < csvStringLines.Length; i++)
            {
                DataRow tableRow = result.NewRow();
                var colValues = csvStringLines[i].Split(',');
                for (var j = 0; j < colValues.Length; j++)
                {
                    tableRow.SetField(j, colValues[j].Trim());
                }
                result.Rows.Add(tableRow);
            }
            return result;
        }

        
        public static List<string> GetSubsetValuesFromRow(List<int> set, DataTable table, int rowIndex)
        {          
            DataRow row = table.Rows[rowIndex];
            var rowValues = row.ItemArray.ToList().Select(x => x.ToString()).ToList();
            var values = new List<string>();
            
            for (var i = 0; i < set.Count; i++)
            {
                values.Add(rowValues[set[i]]);
            }
            return values;
        }
        public static bool PairListStringEquality(List<string> a, List<string> b)
        {
            if (a.Count != b.Count)
                return false;
            for (var i = 0; i < a.Count; i++)
                if (false == a[i].Equals(b[i]))
                    return false;
            return true;
        }
        public static bool ListStringEquality(params List<string>[] lists)
        {
            for (int i = 1; i < lists.Length; i++)
            {
                if (false == PairListStringEquality(lists[i-1], lists[i]))
                    return false;
            }
            return true;
        }
    }
}
