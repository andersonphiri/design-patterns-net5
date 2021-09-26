using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Library
{
    public class DataRenderer : IDataRenderer
    {
        private readonly IDbDataAdapter _dbDataAdapter;
        public DataRenderer(IDbDataAdapter dbDataAdapter)
        {
            _dbDataAdapter = dbDataAdapter;
        }
        public void Render(TextWriter writer)
        {
            Console.WriteLine("Rendering Data:");
            var dataSet = new DataSet();
            _dbDataAdapter.Fill(dataSet);
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    writer.Write(column.ColumnName.PadRight(20) + " ");
                }
                writer.WriteLine();
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        writer.Write(row[i].ToString().PadRight(20) + " ");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
