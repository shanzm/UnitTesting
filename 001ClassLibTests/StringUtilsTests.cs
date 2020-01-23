using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Tests
{
    [TestClass]
    public class StringUtilsTest
    {
        [TestMethod]
        public void ReverseTest1()
        {
            var OriginalString = "I am Shanzm";
            var ActualResult = StringUtils.Reverse(OriginalString);
            Assert.AreEqual("Shanzm am I", ActualResult);
        }

        [TestMethod]
        public void ReverseTest2()
        {
            var OriginalString = "I am         Shanzm";
            var ActualResult = StringUtils.Reverse(OriginalString);
            Assert.AreEqual("Shanzm am I", ActualResult);
        }
    }
}