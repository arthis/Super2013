using System;
using System.Collections.Generic;
using GoogleChartSharp;
using System.Drawing;

namespace Toxicity
{
    internal class GoogleChart
    {
        private const int MaxTypeNameLengthOnChart = 25;

        private readonly MetricCollection collection;

        public GoogleChart(MetricCollection metrics)
        {
            this.collection = metrics;
        }

        public string Url
        {
            get
            {
                return ComposeGoogleChart().GetUrl();
            }
        }

        private Chart ComposeGoogleChart()
        {
            GoogleChartSharp.BarChart chart = new BarChart(517, 580, BarChartOrientation.Horizontal, BarChartStyle.Stacked);
            chart.SetTitle("Code Toxicity by Type");
            chart.SetData(ChangeDoubleListToFloatList(collection.ReturnCollectionCategoryToxicity()));
            chart.SetDatasetColors(new[]
                                       {
                                           GetHexColourCode(Color.Red), 
                                           GetHexColourCode(Color.Blue),
                                           GetHexColourCode(Color.Green), 
                                           GetHexColourCode(Color.Orange),
                                           GetHexColourCode(Color.Teal),
                                           GetHexColourCode(Color.Thistle), 
                                           GetHexColourCode(Color.SkyBlue),
                                           GetHexColourCode(Color.Purple), 
                                           GetHexColourCode(Color.Yellow),
                                           GetHexColourCode(Color.Firebrick),
                                           GetHexColourCode(Color.Salmon), 
                                           GetHexColourCode(Color.PeachPuff),
                                           GetHexColourCode(Color.Lime)
                                       });
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom, new[] { "0", "25", "50", "75", "100" }));
            string[] rankedMetricsNames = collection.RankedMetricsNames();
            Array.Reverse(rankedMetricsNames);
            rankedMetricsNames = Truncate(rankedMetricsNames);
            chart.AddAxis(new ChartAxis(ChartAxisType.Left, rankedMetricsNames));
            chart.SetLegend(new[]
                                {
                                    "Class Size", 
                                    "Num. Methods",
                                    "Num. Fields", 
                                    "Nested Types", 
                                    "Properties",
                                    "Depth In Tree", 
                                    "Method Length", 
                                    "Cyclomatic Compl.",
                                    "Local Variables", 
                                    "Stack Size", 
                                    "Excep. Handlers",
                                    "Excep. Throws", 
                                    "Object Instant."
                                });
            chart.SetBarWidth(14);

            return chart;
        }

        private string[] Truncate(string[] typeNames)
        {
            var truncatedTypeNames = new string[typeNames.Length];
            for (int i = 0; i < typeNames.Length; i++)
            {
                truncatedTypeNames[i] = TruncateTypeName(typeNames[i]);
            }
            return truncatedTypeNames;
        }

        private string TruncateTypeName(string typeName)
        {
            return typeName.Length > MaxTypeNameLengthOnChart ? typeName.Substring(0, MaxTypeNameLengthOnChart - 3) + "..." : typeName;
        }

        internal static string GetHexColourCode(Color color)
        {
            char[] hexDigits = {
         '0', '1', '2', '3', '4', '5', '6', '7',
         '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};


            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }

        internal List<float[]> ChangeDoubleListToFloatList(List<double[]> list)
        {
            var returnList = new List<float[]>();
            foreach (double[] data in list)
            {
                var toxicityValues = new float[data.Length];

                for (int i = 0; i < data.Length; i++)
                {
                    toxicityValues[i] = (float) Math.Round(data[i], 0);
                }
                returnList.Add(toxicityValues);
            }
            return returnList;
        }

        internal static List<int[]> ChangeDoubleListToIntList(List<double[]> list)
        {
            List<int[]> returnList = new List<int[]>();
            foreach (double[] data in list)
            {
                int[] ints = new int[data.Length];

                for (int i = 0; i < data.Length; i++)
                {
                    ints[i] = (int)data[i];
                }
                returnList.Add(ints);
            }
            return returnList;
        }
    }
}
