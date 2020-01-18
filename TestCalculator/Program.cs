using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//添加对ClassLib项目引用

namespace TestCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCalculatorDoubleValue();
        }

        //测试ClassLib项目中Calculator类中的DoubleValue()方法
        public static void TestCalculatorDoubleValue()
        {  
            //生成一个测试对象的实例
            Calculator obj = new Calculator();
            //设计测试案例
            int value = 2;
            int expected = 4;
            
            //与预期比较
            if (expected == obj.DoubleValue(value))
            {
                Console.WriteLine("测试通过");
            }
            else
            {
                Console.WriteLine($"测试未通过,测试的实际结果是{obj.DoubleValue(value)}");
            }
            Console.ReadKey();
        }
    }
}
