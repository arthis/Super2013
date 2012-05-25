using NUnit.Framework;

namespace Toxicity.Test
{
    [TestFixture]
    public class MethodMetricTest
    {
        [Test]
        public void ShouldParseSimpleGetMethod()
        {
            MethodMetric metric = new MethodMetric("Toxicity.MethodMetric.get_CodeSize() : Int");
            Assert.AreEqual("Toxicity.MethodMetric", metric.TypeName);
            Assert.AreEqual("get_CodeSize() : Int", metric.MethodName);
        }
        
        [Test]
        public void ShouldParseSimpleConstructor()
        {
            MethodMetric metric = new MethodMetric("Toxicity.MethodMetric..ctor(String)");
            Assert.AreEqual("Toxicity.MethodMetric", metric.TypeName);
            Assert.AreEqual("ctor(String)", metric.MethodName);
        }

        [Test]
        public void ShouldParseSimpleClassConstructor()
        {
            MethodMetric metric = new MethodMetric("Toxicity.MethodMetric..cctor()");
            Assert.AreEqual("Toxicity.MethodMetric", metric.TypeName);
            Assert.AreEqual("cctor()", metric.MethodName);
        }

        [Test]
        public void ShouldParseGenericsClassConstructor()
        {
            MethodMetric metric = new MethodMetric("Toxicity.MethodMetric.<.cctor>b__0(Int32, String) : Int32");
            Assert.AreEqual("Toxicity.MethodMetric", metric.TypeName);
            Assert.AreEqual("cctor>b__0(Int32, String) : Int32", metric.MethodName);
        }

        [Test]
        public void ShouldParseGenericsWithEnumerableReturnValueMethod()
        {
            MethodMetric metric = new MethodMetric("Toxicity.Groupings<Item>.System.Collections.Generic.IEnumerable<Toxicity.LabelledList<Item>>.GetEnumerator() : IEnumerator<LabelledList<Item>>");
            Assert.AreEqual("Toxicity.Groupings<Item>", metric.TypeName);
            Assert.AreEqual("GetEnumerator() : IEnumerator<LabelledList<Item>>", metric.MethodName);
        }

        [Test]
        public void ShouldParseMethodWithReturnValueOfComSomething()
        {
            MethodMetric metric = new MethodMetric("Toxicity.MethodMetric.Com.Acme.SomeType.GetEnumerator() : IEnumerator<LabelledList<Item>>");
            Assert.AreEqual("Toxicity.MethodMetric", metric.TypeName);
            Assert.AreEqual("GetEnumerator() : IEnumerator<LabelledList<Item>>", metric.MethodName);
        }

    }
}
