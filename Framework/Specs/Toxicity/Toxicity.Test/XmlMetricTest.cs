using NUnit.Framework;

namespace Toxicity.Test
{
    [TestFixture]
    public class XmlMetricTest
    {
        MetricThresholds metrics = MetricThresholds.Default();

        [Test]
        public void LoadTypeCodeSizeTest()
        {
            int result = metrics.ClassLength;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadTypeNumberOfFieldsTest()
        {
            int result = metrics.NumberOfFields;
            Assert.IsNotNull(result);
        }


        [Test]
        public void LoadTypeNumberOfMethodTest()
        {
            int result = metrics.NumberOfMethods;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadTypeNumberOfPropertiesTest()
        {
            int result = metrics.NumberOfProperties;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadTypeNumberOfNestedTypesTest()
        {
            int result = metrics.NumberOfNestedTypes;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadTypeClassDepthInTreeTest()
        {
            int result = metrics.ClassDepthInTree;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadMethodLengthTest()
        {
            int result = metrics.MethodLength;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadMethodCyclomaticComplexityTest()
        {
            int result = metrics.MethodCyclomaticComplexity;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadMethodLocalesTest()
        {
            int result = metrics.NumberOfLocals;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadMethodStackSize()
        {
            int result = metrics.MaxSizeOfStack;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadMethodExceptionHandlers()
        {
            int result = metrics.NumberOfExceptionHandlers;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoadMethodExceptionThrows()
        {
            int result = metrics.NumberOfExceptionThrows;
            Assert.IsNotNull(result);
        }
    }
}
