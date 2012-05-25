using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace Toxicity
{
    internal class Program
    {
        private const int NumberOfTypesToChart = 30;

        private static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Out.WriteLine("Usage: Toxicity.exe <path/to/Reflector.CodeMetrics.xml> [types to exclude (short names separated by space)]");
                return -1;
            }

            var inputFileName = args[0];
            var typesToExclude = new string[args.Length - 1];
            Array.Copy(args, 1, typesToExclude, 0, typesToExclude.Length);
            return new Program().Run(inputFileName, new List<string>(typesToExclude));
        }

        private int Run(string inputFileName, List<string> typesToExclude)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(inputFileName);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Couldn't load {0}: {1}", inputFileName, e.Message);
                return -2;
            }

            MetricCollection metrics = new MetricCollection(XmlMetricReader.ReadFromDocument(doc));
            List<TypeMetric> topMetrics =
                metrics.RankToxicMetrics().FindAll(typeMetric => !typesToExclude.Contains(typeMetric.ShortTypeName));

            string csvFileName = inputFileName.Replace(".xml", ".csv");
            CreateCsvFile(csvFileName, topMetrics);

            string chartFile = inputFileName.Replace(".xml", ".png");
            Uri chartUri = SaveMetricsChart(chartFile, GetMetricsSubset(topMetrics));

//            System.Diagnostics.Process.Start(chartUri.AbsoluteUri);
            return 0;
        }

        private void CreateCsvFile(string csvFileName, List<TypeMetric> topMetrics)
        {
            using (var csvFileWriter = new StreamWriter(new FileStream(csvFileName, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                const string formatStringCsv = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}";
                csvFileWriter.WriteLine(string.Format(formatStringCsv,
                                                      "Type Name",
                                                      "Cyclomatic Complexity",
                                                      "Exception Handlers",
                                                      "Exception Throws",
                                                      "Method Length",
                                                      "Locals Variables",
                                                      "Object Instantiations",
                                                      "Stack Size",
                                                      "Number Of Fields",
                                                      "Number Of Methods",
                                                      "Nested Types",
                                                      "Properties",
                                                      "Depth In Tree",
                                                      "Total Toxicity"));
                for (int i = 0; i < topMetrics.Count && topMetrics[i].TotalToxicity >= 10; i++)
                {
                    var metric = topMetrics[i];
                    csvFileWriter.WriteLine(string.Format(formatStringCsv,
//                                                          metric.TypeName,
                                                          metric.ShortTypeName,
                                                          metric.MethodCyclomaticComplexityToxicity,
                                                          metric.MethodExceptionHandlersToxicity,
                                                          metric.MethodExceptionThrowsToxicity,
                                                          metric.MethodLengthToxicity,
                                                          metric.MethodLocalsToxicity,
                                                          metric.MethodNewObjectToxicity,
                                                          metric.MethodStackToxicity,
                                                          metric.TypeNumberOfFieldsToxicity,
                                                          metric.TypeNumberOfMethodsToxicity,
                                                          metric.TypeNumberOfNestedTypesToxicity,
                                                          metric.TypeNumberOfPropertiesToxicity,
                                                          metric.TypeTreeDepthToxicity,
                                                          metric.TotalToxicity));
                }
            }
        }

        private MetricCollection GetMetricsSubset(List<TypeMetric> topMetrics)
        {
            return new MetricCollection(topMetrics.GetRange(0, Math.Min(NumberOfTypesToChart, topMetrics.Count)));
        }

        private Uri SaveMetricsChart(string outputFile, MetricCollection metrics)
        {
            GoogleChart chart = new GoogleChart(metrics);
            var chartUrl = chart.Url;
            HttpWebRequest req = (HttpWebRequest) WebRequest.Create(chartUrl);
            var systemWebProxy = WebRequest.GetSystemWebProxy();
            systemWebProxy.Credentials = CredentialCache.DefaultCredentials;
            req.Proxy = systemWebProxy;
            WebResponse response = req.GetResponse();

            using (Stream output = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                Stream input = new BufferedStream(response.GetResponseStream());
                int i = input.ReadByte();
                while (i != -1)
                {
                    output.WriteByte((byte) i);
                    i = input.ReadByte();
                }
            }
            Console.Out.WriteLine("Wrote chart data to " + outputFile);
            return new Uri(chartUrl);
        }
    }
}
