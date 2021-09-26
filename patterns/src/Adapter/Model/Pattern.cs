using Adapter.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Model
{
    public class Pattern
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// this is the new component, we want to use logic in the adaptee : DataRenderer, but we can't due to interface incompatibility
    /// </summary>
    public class PatternRenderer
    {
        private readonly IDataPatternRendererAdapater _patternRenderer;
        public PatternRenderer(IDataPatternRendererAdapater patternRenderer)
        {
            _patternRenderer = patternRenderer;
        }
        public PatternRenderer() : this(new DataPatternRendererAdapter())
        {

        }
        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            return _patternRenderer.ListPatterns(patterns);
        }
    }

    public interface IDataPatternRendererAdapater
    {
        string ListPatterns(IEnumerable<Pattern> patterns);
    }

    class DataPatternRendererAdapter : IDataPatternRendererAdapater
    {
        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            IDataRenderer _dataRenderer = new DataRenderer(new PatternCollectionDbAdapter(patterns));
            TextWriter writer = new StringWriter();
            _dataRenderer.Render(writer);
            return writer.ToString();
        }
        internal class PatternCollectionDbAdapter : IDbDataAdapter
        {
            private readonly IEnumerable<Pattern> _patterns;

            public PatternCollectionDbAdapter(IEnumerable<Pattern> patterns)
            {
                _patterns = patterns;
            }
            public int Fill(DataSet dataSet)
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
                dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
                dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
                int i = 0;
                foreach (Pattern pattern in _patterns)
                {
                    var row = dataTable.NewRow();
                    row[0] = pattern.Id;
                    row[1] = pattern.Name;
                    row[2] = pattern.Description;
                    dataTable.Rows.Add(row);
                }
                
                dataSet.Tables.Add(dataTable);
                dataSet.AcceptChanges();
                return _patterns.Count() + 1;
            }

            #region Not implemented
            public IDbCommand DeleteCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public IDbCommand InsertCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public IDbCommand SelectCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public IDbCommand UpdateCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public MissingMappingAction MissingMappingAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public MissingSchemaAction MissingSchemaAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public ITableMappingCollection TableMappings => throw new NotImplementedException();



            public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
            {
                throw new NotImplementedException();
            }

            public IDataParameter[] GetFillParameters()
            {
                throw new NotImplementedException();
            }

            public int Update(DataSet dataSet)
            {
                throw new NotImplementedException();
            } 
            #endregion
        }
    }

}
