using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLib;
using System.Data.SqlClient;


namespace ClassLibTestProject
{
    [TestClass]
    public class TestMyClass
    {

        [TestMethod]
        public void TestDoubleValue()
        {
            //Arrange:准备，实例化一个带测试的类
            MyClass obj = new MyClass();

            //Test Case:设计测试案例
            int value = 2;
            int expected = 4;

            //Act：执行
            int actual = obj.DoubleValue(value);

            //Assert：断言
            Assert.AreEqual(expected, actual);
        }


        public TestContext TestContext { get; set; }//注意为了获取数据的数据，我们要自定义一个TestContext属性
        [TestMethod]
        [DataSource("System.Data.SqlClient",
            @"server=.;database=db_Tome1;uid=sa;pwd=shanzm" , 
            "szmUnitTestDemo", 
            DataAccessMethod.Sequential)]
        public void TestDoubleVlaue2()
        {
            //Arrange
            MyClass target = new MyClass();
            //TestCase
            int value = Convert.ToInt32(TestContext.DataRow["Input"]);
            int expected = Convert.ToInt32(TestContext.DataRow["Expected"]);
            //Act
            int actual = target.DoubleValue(value);
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
        public void TestSum1()
        {
            MyClass obj = new MyClass();
            obj.Sum(100, 50);
        }

        [TestMethod]
        public void TestSum2()
        {
            MyClass obj = new MyClass();

            int from = 1, to = 10;
            int expected = 55;

            int actual = obj.Sum(from, to);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCaculateAge1()
        {
            MyClass obj = new MyClass();

            DateTime dt = new DateTime(1995, 10, 15);
            int expected = 24;

            int actual = obj.CaculateAge(dt);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCaculateAge2()
        {
            try
            {
                MyClass target = new MyClass();
                target.CaculateAge(DateTime.Now.AddDays(1));
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, MyClass.AgeErrorString);
                return;
            }
            Assert.Fail("No Exception was thrown");//断言这个测试案例是失败，若是测试的时候若是真的失败了，则测试通过
        }


    }
}
