
namespace Toxicity
{
    internal class MetricCalculator
    {
        private readonly MetricThresholds threshold;
        private delegate int MethodDelegate(MethodMetric metric);

        public MetricCalculator(MetricThresholds metricThresholds)
        {
            threshold = metricThresholds;
        }

        public double CalculateTotalTypeToxicity(TypeMetric classToAnalyze)
        {
            var totalMethodToxicity = CalculateTotalMethodToxicity(classToAnalyze);
            var typeCodeSizeToxicity = TypeCodeSize(classToAnalyze);
            var typeNumberOfFieldsToxicity = TypeNumberOfFields(classToAnalyze);
            var typeNumberOfMethodsToxicity = TypeNumberOfMethods(classToAnalyze);
            var typeNumberOfPropertiesToxicity = TypeNumberOfProperties(classToAnalyze);
            var typeNumberOfNestedTypesToxicity = TypeNumberOfNestedTypes(classToAnalyze);
            var typeTreeDepthToxicity = TypeTreeDepth(classToAnalyze);

            classToAnalyze.TotalMethodToxicity = totalMethodToxicity;
            classToAnalyze.TypeCodeSizeToxicity = typeCodeSizeToxicity;
            classToAnalyze.TypeNumberOfFieldsToxicity = typeNumberOfFieldsToxicity;
            classToAnalyze.TypeNumberOfMethodsToxicity = typeNumberOfMethodsToxicity;
            classToAnalyze.TypeNumberOfPropertiesToxicity = typeNumberOfPropertiesToxicity;
            classToAnalyze.TypeNumberOfNestedTypesToxicity = typeNumberOfNestedTypesToxicity;
            classToAnalyze.TypeTreeDepthToxicity = typeTreeDepthToxicity;

            double toxicity = totalMethodToxicity + 
                              typeCodeSizeToxicity + 
                              typeNumberOfFieldsToxicity +
                              typeNumberOfMethodsToxicity + 
                              typeNumberOfPropertiesToxicity +
                              typeNumberOfNestedTypesToxicity + 
                              typeTreeDepthToxicity;
            classToAnalyze.TotalToxicity = (int)toxicity;
            return toxicity;
        }

        public double CalculateTotalMethodToxicity(TypeMetric classToAnalyze)
        {
            var methodLengthToxicity = MethodLengthToxicity(classToAnalyze);
            var methodCyclomaticComplexityToxicity = MethodCyclomaticComplexityToxicity(classToAnalyze);
            var methodExceptionHandlersToxicity = MethodExceptionHandlersToxicity(classToAnalyze);
            var methodExceptionThrowsToxicity = MethodExceptionThrowsToxicity(classToAnalyze);
            var methodLocalsToxicity = MethodLocalsToxicity(classToAnalyze);
            var methodStackToxicity = MethodStackToxicity(classToAnalyze);
            var methodNewObjectToxicity = MethodNewObjectToxicity(classToAnalyze);

            classToAnalyze.MethodLengthToxicity = methodLengthToxicity;
            classToAnalyze.MethodCyclomaticComplexityToxicity = methodCyclomaticComplexityToxicity;
            classToAnalyze.MethodExceptionHandlersToxicity = methodExceptionHandlersToxicity;
            classToAnalyze.MethodExceptionThrowsToxicity = methodExceptionThrowsToxicity;
            classToAnalyze.MethodLocalsToxicity = methodLocalsToxicity;
            classToAnalyze.MethodStackToxicity = methodStackToxicity;
            classToAnalyze.MethodNewObjectToxicity = methodNewObjectToxicity;

            return methodLengthToxicity
                + methodCyclomaticComplexityToxicity
                + methodExceptionHandlersToxicity
                + methodExceptionThrowsToxicity
                + methodLocalsToxicity
                + methodStackToxicity
                + methodNewObjectToxicity;
        }

        #region Method Toxicity
        public double MethodLengthToxicity(TypeMetric classToAnalyze)
        {
            MethodDelegate del = metric => metric.CodeSize;
            return CalculateCumulativeMethodToxicity(classToAnalyze, del, threshold.MethodLength);
        }

        public double MethodStackToxicity(TypeMetric classToAnalyze)
        {
            MethodDelegate del = metric => metric.MaxStack;
            return CalculateCumulativeMethodToxicity(classToAnalyze, del, threshold.MaxSizeOfStack);
        }

        public double MethodLocalsToxicity(TypeMetric classToAnalyze)
        {
            MethodDelegate del = metric => metric.Locals;
            return CalculateCumulativeMethodToxicity(classToAnalyze, del, threshold.NumberOfLocals);
        }

        public double MethodExceptionHandlersToxicity(TypeMetric classToAnalyze)
        {
            MethodDelegate del = metric => metric.ExceptionHandlers;
            return CalculateCumulativeMethodToxicity(classToAnalyze, del, threshold.NumberOfExceptionHandlers);
        }

        public double MethodExceptionThrowsToxicity(TypeMetric classToAnalyze)
        {
            MethodDelegate del = metric => metric.Throws;
            return CalculateCumulativeMethodToxicity(classToAnalyze, del, threshold.NumberOfExceptionThrows);
        }

        public double MethodNewObjectToxicity(TypeMetric classToAnalyze)
        {
            MethodDelegate del = metric => metric.NewObj;
            return CalculateCumulativeMethodToxicity(classToAnalyze, del, threshold.NumberOfNewObjectCreations);
        }

        public double MethodCyclomaticComplexityToxicity(TypeMetric classToAnalyze)
        {
            MethodDelegate del = metric => metric.CyclomaticComplexity;
            return CalculateCumulativeMethodToxicity(classToAnalyze, del, threshold.MethodCyclomaticComplexity);
        }
        #endregion

        #region Type Toxicity
        public double TypeCodeSize(TypeMetric classToAnalyze)
        {
            return CalculateMetricToxicity(classToAnalyze.CodeSize, threshold.ClassLength);
        }
        public double TypeNumberOfFields(TypeMetric classToAnalyze)
        {
            return CalculateMetricToxicity(classToAnalyze.Fields, threshold.NumberOfFields);
        }
        public double TypeNumberOfMethods(TypeMetric classToAnalyze)
        {
            return CalculateMetricToxicity(classToAnalyze.Methods, threshold.NumberOfMethods);
        }
        public double TypeNumberOfProperties(TypeMetric classToAnalyze)
        {
            return CalculateMetricToxicity(classToAnalyze.Properties, threshold.NumberOfProperties);
        }
        public double TypeTreeDepth(TypeMetric classToAnalyze)
        {
            return CalculateMetricToxicity(classToAnalyze.DepthInTree, threshold.ClassDepthInTree);
        }
        public double TypeNumberOfNestedTypes(TypeMetric classToAnalyze)
        {
            return CalculateMetricToxicity(classToAnalyze.NestedTypes, threshold.NumberOfNestedTypes);
        }
        #endregion

        public double CalculateMetricToxicity(int metricValue, int metricThreshold)
        {
            if (metricValue <= metricThreshold) return 0;
            return (double)metricValue / metricThreshold;
        }

        private double CalculateCumulativeMethodToxicity(TypeMetric classToAnalyze, MethodDelegate del, int thresholdValue)
        {
            double methodToxicity = 0;
            foreach (MethodMetric metric in classToAnalyze.methodMetrics)
            {
                methodToxicity += CalculateMetricToxicity(del.Invoke(metric), thresholdValue);
            }
            return methodToxicity;
        }
    }
}
