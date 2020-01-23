using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//注意 [TestClass]和[TestClass()]，[TestMethod()]和[TestMethod]写法等价
namespace ClassLib.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        //使用ClassInitialize标签初始化一个Calculator对象以供下面所有的测试([ClassCleanup]之前）使用
        private static Calculator calc = null;
        [ClassInitialize]
        public static void ClassInit(TestContext testcontext)
        {
            calc = new Calculator();
        }


        [TestMethod()]
        public void DoubleValueTest_DoubleValue_ReturnTrue()
        {
            ////Arrange:准备，实例化一个带测试的类
            //Calculator objCalcultor = new Calculator();

            //Test Case:设计测试案例
            int value = 2;
            int expected = 4;

            //Act：执行
            int actual = calc.DoubleValue(value);

            //Assert：断言
            Assert.AreEqual(expected, actual);
        }


        public TestContext TestContext { get; set; }//注意为了获取数据库的数据，我们要自定义一个TestContext属性
        [TestMethod()]
        [DataSource("System.Data.SqlClient",
            @"server=.;database=db_Tome1;uid=sa;pwd=shanzm",
            "szmUnitTestDemo",
            DataAccessMethod.Sequential)]
        public void DoubleValueTest_DoubleValue_ReturnTrue2()
        {
            ////Arrange
            //Calculator bjCalcultor = new Calculator();

            //TestCase
            int value = Convert.ToInt32(TestContext.DataRow["Input"]);
            int expected = Convert.ToInt32(TestContext.DataRow["Expected"]);
            //Act
            int actual = calc.DoubleValue(value);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        #region 关于属性[DataSource]
        //1.DataSource的第一个参数是providername，即使用的数据源的命名空间，其实我们也是可是使用Excel表格的（菜单“项目”-->添加新的数据源……）参考：https://blog.csdn.net/site008/article/details/77070945
        // providername值参考：
        //"system.data.sqlclient" ----说明使用的是mssqlserver数据库
        //"system.data.sqllite" ----说明使用的是sqllite数据库
        //"system.data.oracleclient" ----说明使用的是oracle数据库或providername="system.data.oracle.dataaccess.client" 
        //"system.data.oledb" ----说明使用的是access数据库
        //"mysql.data.mysqlclient" ----说明使用的是mysql数据库
        //2.第二个参数是connectionString，我习惯是这样写：@"server=.;database=db_Tome1;uid=sa;pwd=shanzm"。
        //但是这也是一样的：@"Data Source=localhost;Initial Catalog=db_Tome1;User ID=sa;Password=shanzm"
        //3.第三个参数是tablename,使用的数据库中的哪张表
        //4.对表中的数据测试的顺序，可以是顺序的，也可以是随机的，这里是我们选择顺序的：DataAccessMethod.Sequential
        #endregion


        //因为Sum()函数代码中有抛出异常，所以哦我们要测试期望抛出的异常
        //异常测试，添加特性ExpectedException
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SumTest_ArgumentException_TrowException()
        {
            Calculator calc = new Calculator();
            int from = 100, to = 50;
            calc.Sum(from, to);
        }

        [TestMethod]
        public void SumTest2()
        {
            //Calculator objCalcultor = new Calculator();

            int from = 1, to = 10;
            int expected = 55;

            int actual = calc.Sum(from, to);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CaculateAgeTest1()
        {
            //Calculator objCalcultor = new Calculator();

            DateTime dt = new DateTime(1995, 10, 15);
            int expected = 24;

            int actual = calc.CaculateAge(dt);

            Assert.AreEqual(expected, actual, "测试失败-----------");
            //注意这里actual=25，expected=24，
            //测试是无法通过的，只是为了演示测试不通过的样子
        }

        [TestMethod]
        public void CaculateAgeTest2()
        {
            try
            {
                // Calculator objCalcultor = new Calculator();
                calc.CaculateAge(DateTime.Now.AddDays(1));//这里的生日日期是当前时间加一天，所以会抛出ArgumentOutOfRangeException
            }
            catch (ArgumentOutOfRangeException e)
            {
                //断言一个字符串是否包含另一字符串,其中第一个参数为被包含的字符串,第二个为实际字符串
                StringAssert.Contains(e.Message, Calculator.AgeErrorString);
                return;
            }
            Assert.Fail("No Exception was thrown");//断言这个测试案例是失败，若是测试的时候若是真的失败了，则测试通过
        }

        [TestMethod]
        [Ignore]
        public void testIngore()
        {
            Console.WriteLine("使用[Ignore]标签则会使测试框架忽视该单元测试函数");
        }

        [TestMethod]
        [TestCategory("给测试分类")]
        public void testCategory()
        {
            Console.WriteLine("使用[TestCategory]标签给每一个测试自定义分类");
        }

        [ClassCleanup]
        public static void Classup()
        {
            calc = null;
        }

        [TestMethod()]
        public void isLastFilenameValid_ValidName_ReturnTrue()
        {
            Calculator calc = new Calculator();
            string fileName = "test.txt";
            calc.isLastFilenameValid(fileName);

            Assert.IsTrue(calc.wasLastFileNameValid);
            //该测试是测试isLastFilenameValid()，
            //因为该函数是把结果赋值给类中属性wasLastFileNameValid
            //所以此处验证的是Calculator类中属性wasLastFileNameValid是否符合我们的期望
            //而不是简单的验证isLastFilenameValid(）的返回值是否符合我们的期望
        }
    }
}