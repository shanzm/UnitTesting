using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLib;

namespace UnitTestClass
{
    [TestClass]
    public class TestStringUtils
    {
        [TestMethod]
        public void TestReverse()
        {
            var OriginalString = "I am Shanzm";
            var ActualResult = StringUtils.Reverse(OriginalString);
            Assert.AreEqual("Shanzm am I", ActualResult);
        }

        [TestMethod]
        public void TestReverse2()
        {
            var OriginalString = "I am         Shanzm";
            var ActualResult = StringUtils.Reverse(OriginalString);
            Assert.AreEqual("Shanzm am I", ActualResult);
        }
    }
}
