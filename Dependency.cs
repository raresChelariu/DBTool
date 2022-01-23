using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;

namespace DBTool
{
    public class Dependency
    {
        public List<int> X;
        public List<int> Y;
        public List<int> Z;
        public DependencyType Type;


        public Dependency(List<int> left, List<int> right)
        {
            this.X = new List<int>();
            this.Y = new List<int>();
            this.X.AddRange(left);
            this.Y.AddRange(right);
        }
        public static List<Dependency> GetAllDependeciesFromSubsetList(List<List<int>> subsetList)
        {
            var result = new List<Dependency>();
            for (var i = 0; i < subsetList.Count; i++)
                for (var j = 0; j < subsetList.Count; j++)
                {
                    if (i != j)
                    {
                        bool hasAtLeastOneCommon = subsetList[i].Intersect(subsetList[j]).Any();
                        if (false == hasAtLeastOneCommon)
                            result.Add(new Dependency(subsetList[i], subsetList[j]));
                    }
                }
            return result;
        }

        public static List<List<int>> GetAllSubsets(int setSize)
        {
            var isLeft = new bool[setSize];

            var sets = new List<List<int>>();

            long maxNoSets = 1 << setSize;
            for (long currSetIteration = 1; currSetIteration < maxNoSets; currSetIteration++)
            {
                var currSet = new List<int>();

                for (int i = 0; i < setSize; i++)
                {
                    isLeft[i] = (currSetIteration & (1 << i)) != 0;
                }
                for (int i = 0; i < setSize; i++)
                {
                    if (isLeft[i])
                    {
                        currSet.Add(i);
                    }
                }
                sets.Add(currSet);
            }
            return sets;
        }
        public string ToDetailedString(List<string> headers, DependencyType dependencyType)
        {
            var result = string.Empty;

            var leftAttributes = GetAttributesAsString(this.X, headers);
            var rightAttributes = GetAttributesAsString(this.Y, headers);

            var arrowType = ArrowStringByDependecyType(dependencyType);
            result = $"{leftAttributes}{arrowType}{rightAttributes}";

            return result;
        }
        public bool IsFunctionalDependency(DataTable table)
        {
            var currDependencyName = this.ToDetailedString(table.GetColumnNames(), DependencyType.Functional);
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var t1X = Utils.GetSubsetValuesFromRow(this.X, table, i);
                for (var j = i + 1; j < table.Rows.Count; j++)
                {
                    var t2X = Utils.GetSubsetValuesFromRow(this.X, table, j);

                    if (Utils.PairListStringEquality(t1X, t2X))
                    {
                        var t1Y = Utils.GetSubsetValuesFromRow(this.Y, table, i);
                        var t2Y = Utils.GetSubsetValuesFromRow(this.Y, table, j);
                        if (false == Utils.PairListStringEquality(t1Y, t2Y))
                            return false;
                    }

                }
            }

            return true;
        }
        public bool IsMultivaluedDependency(DataTable table)
        {
            var currDependencyName = this.ToDetailedString(table.GetColumnNames(), DependencyType.Functional);
            if (this.Z == null)
            {
                this.Z = Dependency.GetRemainderSetForMultivaluedDependency(this, table.Columns.Count);
            }
            for (var t1 = 0; t1 < table.Rows.Count; t1++)
            {
                var tuple1 = new TupleValues(this, table, t1);
                for (var t2 = t1 + 1; t2 < table.Rows.Count; t2++)
                {
                    var tuple2 = new TupleValues(this, table, t2);
                    if (Utils.ListStringEquality(tuple1.X, tuple2.X))
                    {
                        bool existsT3T4ForT1T2Pair = false;
                        for (var t3 = 0; t3 < table.Rows.Count && !existsT3T4ForT1T2Pair; t3++)
                        {
                            var tuple3 = new TupleValues(this, table, t3);
                            if (Utils.ListStringEquality(tuple2.X, tuple3.X))
                            {
                                for (var t4 = 0; t4 < table.Rows.Count && !existsT3T4ForT1T2Pair; t4++)
                                {
                                    var tuple4 = new TupleValues(this, table, t4);
                                    existsT3T4ForT1T2Pair = Utils.ListStringEquality(tuple3.X, tuple4.X) &&
                                         Utils.ListStringEquality(tuple1.Y, tuple3.Y) &&
                                         Utils.ListStringEquality(tuple2.Y, tuple4.Y) &&
                                         Utils.ListStringEquality(tuple2.Z, tuple3.Z) &&
                                         Utils.ListStringEquality(tuple1.Z, tuple4.Z);
                                }
                            }
                        }
                        if (false == existsT3T4ForT1T2Pair)
                            return false;
                    }
                }
            }
            return true;
        }
        public static List<int> GetRemainderSetForMultivaluedDependency(Dependency d, int setSize)
        {
            var unionLeftRight = d.X.Union(d.Y);
            var allColumnsIndexes = new List<int>();
            for (int i = 0; i < setSize; i++)
                allColumnsIndexes.Add(i);
            return allColumnsIndexes.Except(unionLeftRight).ToList();
        }
        public static string ArrowStringByDependecyType(DependencyType dependencyType)
        {
            switch (dependencyType)
            {
                case DependencyType.Functional:
                    return "->";
                case DependencyType.Multivalued:
                    return "->>";
                default:
                    throw new NotImplementedException(dependencyType.ToString());
            }
        }
        public static string GetAttributesAsString(List<int> attributesIndex, List<string> attributesNames)
        {
            return attributesIndex.Aggregate(string.Empty, (result, idx) => result += attributesNames[idx]);
        }
        public static string FromDependecyListToString(List<Dependency> dependencies, DependencyType dependencyType, List<string> attributeNames)
        {
            return dependencies.Aggregate(string.Empty, (result, d) => result += $"{d.ToDetailedString(attributeNames, dependencyType)}{Environment.NewLine}");
        }
    }


}
