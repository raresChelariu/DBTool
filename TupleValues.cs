using System.Collections.Generic;
using System.Data;

namespace DBTool
{
    public class TupleValues
    {
        public List<string> X;
        public List<string> Y;
        public List<string> Z;
        public int index;

        public TupleValues(Dependency dependency, DataTable table, int index)
        {
            this.index = index;
            this.X = Utils.GetSubsetValuesFromRow(dependency.X, table, index);
            this.Y = Utils.GetSubsetValuesFromRow(dependency.Y, table, index);
            if (dependency.Type == DependencyType.Multivalued)
            {
                this.Z = Utils.GetSubsetValuesFromRow(dependency.Z, table, index);
            }
        }
    }
}
