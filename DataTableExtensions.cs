using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTool
{
    public static class DataTableExtensions
    {
        public static List<string> GetColumnNames(this DataTable source)
        {
            return source.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToList();
        }
    }
}
