using System.Xml;
using NUnit.Framework;

namespace Toxicity.Test
{
    [TestFixture]
    public class XmlMetricReaderTest
    {
        [Test]
        public void ShouldIgnoreTestClass()
        {
            Assert.IsTrue(XmlMetricReader.IgnoreType("XMLTest"));
        }

        [Test]
        public void ShouldIgnoreModuleClasses()
        {
            Assert.IsTrue(XmlMetricReader.IgnoreType("<Module>"));
        }

        [Test]
        public void ShouldNotIgnoreRegularClassName()
        {
            Assert.IsFalse(XmlMetricReader.IgnoreType("RegularClassName"));
        }

        [Test]
        public void ShouldNotIgnoreEmptyString()
        {
            Assert.IsFalse(XmlMetricReader.IgnoreType(""));
        }

        [Test]
        public void ShouldCorrectlyReadXmlDocument()
        {
            var x = new XmlDocument();
            x.Load("code-metrics-report.xml");
            var xmlMetricReader = XmlMetricReader.ReadFromDocument(x);
            Assert.That(xmlMetricReader.RetrieveTypeList(), Has.Count.GreaterThan(0));
        }
    }
}
