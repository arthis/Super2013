using NUnit.Framework;

namespace Toxicity.Test
{
    [TestFixture]
    public class MetricCalculatorTest
    {
        MetricCalculator calc = new MetricCalculator(MetricThresholds.Default());
        TypeMetric classToAnalyze;
        MethodMetric firstMethodToAnalyze;
        MethodMetric secondMethodToAnalyze;

        [SetUp]
        public void Setup()
        {
            classToAnalyze = TypeMetric.NameOfType("TestClass");
            firstMethodToAnalyze = new MethodMetric("TestClass.Test");
            secondMethodToAnalyze = new MethodMetric("TestClass.Test");
        }

        [Test]
        public void CodeSizeMetricWithSizeLessThanThreshold()
        {
            double result = calc.CalculateMetricToxicity(300, 300);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CodeSizeMetricWithSizeOneTenthAboveThreshold()
        {
            double result = calc.CalculateMetricToxicity(330, 300);
            Assert.AreEqual(1.1, result);
        }
        [Test]
        public void CodeSizeMetricWithSizeDoubleAboveThreshold()
        {
            double result = calc.CalculateMetricToxicity(600, 300);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void CodeSizeMetricWithNegativeSizeThreshold()
        {
            double result = calc.CalculateMetricToxicity(-1, 300);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ShouldCalculateMethodCodeSizeCorrectlyWithNoMethods()
        {
            double result = calc.MethodLengthToxicity(classToAnalyze);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ShouldCalculateCodeSizeToxicityOf0With1Methods()
        {
            classToAnalyze.Add(firstMethodToAnalyze);
            double result = calc.MethodLengthToxicity(classToAnalyze);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ShouldCalculateA2ToxicityWith1MethodMetric()
        { 
            firstMethodToAnalyze.CodeSize = MetricThresholds.Default().MethodLength * 2;
            classToAnalyze.Add(firstMethodToAnalyze);
            double result = calc.MethodLengthToxicity(classToAnalyze);
            Assert.AreEqual(2, result);
        }
        [Test]
        public void ShouldCalculateACodeSizeToxicityOf4With2MethodMetrics()
        {
            firstMethodToAnalyze.CodeSize = MetricThresholds.Default().MethodLength * 2;
            secondMethodToAnalyze.CodeSize = MetricThresholds.Default().MethodLength * 2;
            classToAnalyze.Add(firstMethodToAnalyze);
            classToAnalyze.Add(secondMethodToAnalyze);
            double result = calc.MethodLengthToxicity(classToAnalyze);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void FullTest()
        {
            classToAnalyze.Add(firstMethodToAnalyze);
            firstMethodToAnalyze.CodeSize = MetricThresholds.Default().MethodLength * 2;
            firstMethodToAnalyze.CyclomaticComplexity = MetricThresholds.Default().MethodCyclomaticComplexity * 3;
            Assert.AreEqual(5, calc.CalculateTotalTypeToxicity(classToAnalyze));

        }
    }
}
