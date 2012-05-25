using System.Collections.Generic;

namespace Toxicity
{
    internal class MetricCollection
    {
        private readonly MetricCalculator calculator = new MetricCalculator(MetricThresholds.Default());
        private readonly List<TypeMetric> metricList;

        public MetricCollection(XmlMetricReader reader)
        {
            metricList = reader.RetrieveTypeList();
        }

        public MetricCollection(IEnumerable<TypeMetric> metricList)
        {
            this.metricList = new List<TypeMetric>(metricList);
        }

        private void CalculateToxicity()
        {
            if(!HasMetricsBeenOrdered(metricList))
                metricList.ForEach(type => calculator.CalculateTotalTypeToxicity(type));
        }

       static bool HasMetricsBeenOrdered(IList<TypeMetric> metrics)
        {
            if(metrics.Count == 0||metrics[0].TotalToxicity != 0)
                return true;
            return false;
        }

        public List<TypeMetric> RankToxicMetrics()
        {
            CalculateToxicity();
            metricList.Sort();
            return metricList;
        }

        public List<double[]> ReturnCollectionCategoryToxicity()
        {
            List<double[]> result = new List<double[]>();
            for (int i = 0; i < 13; i++)
                result.Add(new double[0]);

            foreach (TypeMetric type in RankToxicMetrics())
            {
                result[0] = GroupTypeMetrics(calculator.TypeCodeSize(type), result[0]);
                result[1] = GroupTypeMetrics(calculator.TypeNumberOfMethods(type), result[1]);
                result[2] = GroupTypeMetrics(calculator.TypeNumberOfFields(type), result[2]);
                result[3] = GroupTypeMetrics(calculator.TypeNumberOfNestedTypes(type), result[3]);
                result[4] = GroupTypeMetrics(calculator.TypeNumberOfProperties(type), result[4]);
                result[5] = GroupTypeMetrics(calculator.TypeTreeDepth(type), result[5]);
                result[6] = GroupTypeMetrics(calculator.MethodLengthToxicity(type), result[6]);
                result[7] = GroupTypeMetrics(calculator.MethodCyclomaticComplexityToxicity(type), result[7]);
                result[8] = GroupTypeMetrics(calculator.MethodLocalsToxicity(type), result[8]);
                result[9] = GroupTypeMetrics(calculator.MethodStackToxicity(type), result[9]);
                result[10] = GroupTypeMetrics(calculator.MethodExceptionHandlersToxicity(type), result[10]);
                result[11] = GroupTypeMetrics(calculator.MethodExceptionThrowsToxicity(type), result[11]);
                result[12] = GroupTypeMetrics(calculator.MethodNewObjectToxicity(type), result[12]);
            }
            return result;
        }

        static double[] GroupTypeMetrics(double input, IEnumerable<double> array)
        {
            if (array == null)
                return new double[] { input };

            List<double> list = new List<double>();
            list.AddRange(array);
            list.Add(input);
            return list.ToArray();
        }

        internal string[] RankedMetricsNames()
        {
            List<string> returnList = new List<string>();
            RankToxicMetrics().ForEach(metric => returnList.Add(metric.ShortTypeName));
            return returnList.ToArray();
        }
    }


}