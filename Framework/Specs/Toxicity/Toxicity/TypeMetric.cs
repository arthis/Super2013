using System;
using System.Collections.Generic;

namespace Toxicity
{
    internal class TypeMetric : IComparable
    {
        #region Getters, Setters and Attributes
        
        private readonly string typeName;
        public List<MethodMetric> methodMetrics = new List<MethodMetric>();

        private double toxicity;

        public static TypeMetric NameOfType(string typeName)
        {
            return new TypeMetric(typeName);
        }

        private TypeMetric(string typeName)
        {
            this.typeName = typeName;
        }

        public string TypeName
        {
            get { return typeName; }
        }

        public string ShortTypeName
        {
            get
            {
                if(typeName.Contains("."))
                {
                    return typeName.Substring(typeName.LastIndexOf(".") + 1);
                }
                else
                {
                    return typeName;
                }
            }
        }

        public int CodeSize { get; set; }

        public int Fields { get; set; }

        public int Methods { get; set; }

        public int Properties { get; set; }

        public int NestedTypes { get; set; }

        public int DepthInTree { get; set; }

        public int TotalToxicity
        {
            get { return (int) toxicity; }
            set { toxicity = value; }
        }

        public double MethodLengthToxicity { get; set; }

        public double MethodCyclomaticComplexityToxicity { get; set; }

        public double MethodExceptionHandlersToxicity { get; set; }

        public double MethodExceptionThrowsToxicity { get; set; }

        public double MethodLocalsToxicity { get; set; }

        public double MethodStackToxicity { get; set; }

        public double MethodNewObjectToxicity { get; set; }

        public double TotalMethodToxicity { get; set; }

        public double TypeCodeSizeToxicity { get; set; }

        public double TypeNumberOfFieldsToxicity { get; set; }

        public double TypeNumberOfMethodsToxicity { get; set; }

        public double TypeNumberOfPropertiesToxicity { get; set; }

        public double TypeNumberOfNestedTypesToxicity { get; set; }

        public double TypeTreeDepthToxicity { get; set; }

        #endregion

        public void Add(MethodMetric methodMetric)
        {
            methodMetrics.Add(methodMetric);
        }

        public int CompareTo(object obj)
        {
            TypeMetric other = (TypeMetric) obj;
            return other.TotalToxicity - TotalToxicity;
        }

        
    }
}