using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace Toxicity
{
    class XmlMetricReader
    {
        private const string documentTypeString = "//Type";
        private const string documentMethodString = "//Method";

        private readonly Dictionary<string, TypeMetric> typeMetrics = new Dictionary<string, TypeMetric>();
        private List<TypeMetric> typeList = new List<TypeMetric>();
        private List<MethodMetric> methodList = new List<MethodMetric>();

        public static XmlMetricReader ReadFromDocument(XmlDocument doc)
        {
            return new XmlMetricReader(doc);
        }

        private XmlMetricReader(XmlDocument doc)
        {
            XmlNodeList typeNodeList = doc.SelectNodes("//Type");
            foreach (XmlElement typeElement in typeNodeList)
            {
                Add(ConvertElementToTypeMetric(typeElement));
            }

            XmlNodeList methodNodeList = doc.SelectNodes("//Method");
            foreach (XmlElement methodElement in methodNodeList)
            {
                Add(ConvertElementToMethodMetric(methodElement));
            }
        }

        private TypeMetric ConvertElementToTypeMetric(XmlElement typeElement)
        {
            TypeMetric metric = TypeMetric.NameOfType(typeElement.GetAttribute("Name"));
            metric.CodeSize = int.Parse(typeElement.GetAttribute("CodeSize"));
            metric.Fields = int.Parse(typeElement.GetAttribute("Fields"));
            metric.Methods = int.Parse(typeElement.GetAttribute("Methods"));
            metric.Properties = int.Parse(typeElement.GetAttribute("Properties"));
            metric.NestedTypes = int.Parse(typeElement.GetAttribute("NestedTypes"));
            metric.DepthInTree = int.Parse(typeElement.GetAttribute("DepthInTree"));
            return metric;
        }

        private MethodMetric ConvertElementToMethodMetric(XmlElement methodElement)
        {
            MethodMetric metric = new MethodMetric(methodElement.GetAttribute("Name"));
            metric.CodeSize = int.Parse(methodElement.GetAttribute("CodeSize"));
            metric.CyclomaticComplexity = int.Parse(methodElement.GetAttribute("CyclomaticComplexity"));
            metric.MaxStack = int.Parse(methodElement.GetAttribute("MaxStack"));
            metric.Locals = int.Parse(methodElement.GetAttribute("Locals"));
            metric.ExceptionHandlers = int.Parse(methodElement.GetAttribute("ExceptionHandlers"));
            metric.Throws = int.Parse(methodElement.GetAttribute("Throw"));
            metric.NewObj = int.Parse(methodElement.GetAttribute("NewObj"));
            return metric;
        }

        private void Add(TypeMetric metric)
        {
            if (IgnoreType(metric.TypeName))
                return;
            typeMetrics[metric.TypeName] = metric;
        }

        static internal bool IgnoreType(string typeName)
        {
            Regex regex = new Regex("^<+|Test+");

            if (regex.IsMatch(typeName))
                return true;
            return false;
        }

        private void Add(MethodMetric metric)
        {
            if (IgnoreType(metric.TypeName))
                return;

            if (!typeMetrics.ContainsKey(metric.TypeName))
            {
                // Workaround for bug in Code Metrics plugin: 
                // When the interface name prefixes the method name in an implementation (usually in generated types), the resulting type becomes implementation.interface rather than implementation
                var fixedTypeName = metric.TypeName;
                while (fixedTypeName.Contains(".") && !typeMetrics.ContainsKey(fixedTypeName))
                {
                    fixedTypeName = fixedTypeName.Substring(0, fixedTypeName.LastIndexOf('.'));
                }
                if (!typeMetrics.ContainsKey(fixedTypeName))
                {
                    throw new ApplicationException("Couldn't find type [" + metric.TypeName + "] or fixed type name [" + fixedTypeName + "] when attempting to add method metric");
                }
                metric.TypeName = fixedTypeName;
            }
            typeMetrics[metric.TypeName].Add(metric);
        }

        public List<TypeMetric> RetrieveTypeList()
        {
            return new List<TypeMetric>(this.typeMetrics.Values);
        }
    }
}
