using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Toxicity
{
    //TODO: Change XML index numbers into something more meaningful.
    public class MetricThresholds
    {
        private const string ToxicityConfigFileName = "Toxicity.config.xml";
        private static MetricThresholds instance;

        private readonly XmlNode metricRoot;

        public static MetricThresholds Default()
        {
            if (instance == null)
            {
                string toxicityConfigFileName = GetToxicityConfigFileNameAndLocation();
                instance = new MetricThresholds(toxicityConfigFileName);
            }
            return instance;
        }

        private static string GetToxicityConfigFileNameAndLocation()
        {
            var toxicityConfigFileInWorkingDirectory = ToxicityConfigFileName;
            if (File.Exists(toxicityConfigFileInWorkingDirectory))
            {
                return toxicityConfigFileInWorkingDirectory;
            }
            var executableDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var toxicityConfigFileInExecutableDirectory = string.Format("{0}\\{1}", executableDirectory, ToxicityConfigFileName);
            if (File.Exists(toxicityConfigFileInExecutableDirectory))
            {
                return toxicityConfigFileInExecutableDirectory;
            }
            throw new ApplicationException("Could not find Toxicity config file in either [" + toxicityConfigFileInWorkingDirectory + "] or [" + toxicityConfigFileInExecutableDirectory + "]");
        }

        private MetricThresholds(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            metricRoot = XmlNodeAtIndex(doc, 1);
        }

        #region Class Metric Methods
        public int ClassLength
        {
            get { return ReadIntAtXmlNodeIndex(TypeRoot(), 0); }
        }

        public int NumberOfFields
        {
            get { return ReadIntAtXmlNodeIndex(TypeRoot(), 1); }
        }

        public int NumberOfMethods
        {
            get { return ReadIntAtXmlNodeIndex(TypeRoot(), 2); }
        }

        public int NumberOfProperties
        {
            get { return ReadIntAtXmlNodeIndex(TypeRoot(), 3); }
        }

        public int NumberOfNestedTypes
        {
            get { return ReadIntAtXmlNodeIndex(TypeRoot(), 4); }
        }

        public int ClassDepthInTree
        {
            get { return ReadIntAtXmlNodeIndex(TypeRoot(), 5); }
        }
        #endregion

        #region Method Metric
        public int MethodLength
        {
            get { return ReadIntAtXmlNodeIndex(RootMethodNode(), 0); }
        }

        public int MethodCyclomaticComplexity
        {
            get { return ReadIntAtXmlNodeIndex(RootMethodNode(), 1); }
        }

        public int NumberOfLocals
        {
            get { return ReadIntAtXmlNodeIndex(RootMethodNode(), 2); }
        }

        public int MaxSizeOfStack
        {
            get { return ReadIntAtXmlNodeIndex(RootMethodNode(), 3); }
        }

        public int NumberOfExceptionHandlers
        {
            get { return ReadIntAtXmlNodeIndex(RootMethodNode(), 4); }
        }

        public int NumberOfExceptionThrows
        {
            get { return ReadIntAtXmlNodeIndex(RootMethodNode(), 5); }
        }

        public int NumberOfNewObjectCreations
        {
            get { return ReadIntAtXmlNodeIndex(RootMethodNode(), 6); }
        }
        #endregion

        private XmlNode TypeRoot()
        {
            return XmlNodeAtIndex(metricRoot, 0);
        }

        private XmlNode RootMethodNode()
        {
            return XmlNodeAtIndex(metricRoot, 1);
        }

        private static int ReadIntAtXmlNodeIndex(XmlNode node, int childNodeIndex)
        {
            return int.Parse(XmlNodeAtIndex(node, childNodeIndex).InnerText);
        }

        private static XmlNode XmlNodeAtIndex(XmlNode rootNode, int childNodeIndex)
        {
            return rootNode.ChildNodes[childNodeIndex];
        }
    }
}
