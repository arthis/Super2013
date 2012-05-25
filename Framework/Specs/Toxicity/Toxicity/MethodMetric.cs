namespace Toxicity
{
    internal class MethodMetric
    {
        MetricThresholds thresholds = MetricThresholds.Default();

        #region Getters, Setters and Attributes
        private string typeName;
        private readonly string methodName;

        public string TypeName
        {
            get { return typeName; }
            internal set { typeName = value; }
        }

        public string MethodName
        {
            get { return methodName; }
        }

        public int CodeSize { get; set; }

        public int CyclomaticComplexity { get; set; }

        public int MaxStack { get; set; }

        public int Locals { get; set; }

        public int ExceptionHandlers { get; set; }

        public int Throws { get; set; }

        public int NewObj { get; set; }

        #endregion

        public MethodMetric(string methodAndTypeName)
        {
            int ctorIndex = methodAndTypeName.LastIndexOf("..ctor");
            int cctorIndex = methodAndTypeName.LastIndexOf("..cctor");
            if(ctorIndex >= 0)
            {
                typeName = methodAndTypeName.Substring(0, ctorIndex);
                methodName = methodAndTypeName.Substring(ctorIndex + 2);
            }
            else if (cctorIndex >= 0)
            {
                typeName = methodAndTypeName.Substring(0, cctorIndex);
                methodName = methodAndTypeName.Substring(cctorIndex + 2);
            }
            else
            {
                int lastDotIndex = methodAndTypeName.LastIndexOf('.');
                typeName = methodAndTypeName.Substring(0, lastDotIndex);
                methodName = methodAndTypeName.Substring(lastDotIndex + 1);
            }
            typeName = typeName.TrimEnd('.', '<');

            if (typeName.IndexOf(".System.") > 0)
                typeName = typeName.Substring(0, typeName.IndexOf(".System."));
            if (typeName.IndexOf(".Com.") > 0)
                typeName = typeName.Substring(0, typeName.IndexOf(".Com."));
            if (typeName.IndexOf(".Microsoft.") > 0)
                typeName = typeName.Substring(0, typeName.IndexOf(".Microsoft."));
            if (typeName.IndexOf(".IronPython.") > 0)
                typeName = typeName.Substring(0, typeName.IndexOf(".IronPython."));
        }

    }
}