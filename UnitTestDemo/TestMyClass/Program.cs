using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMyClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //生成一个测试对象的实例
            MyClass obj = new MyClass();
            //测试案例的实际结果
            int result = obj.DoubleValue(2);
            //与预期比较
            if (result ==4)
            {
                Console.WriteLine("The Code is correct!");
            }
            else
            {
                Console.WriteLine("The code is not correct!");
            }
            Console.ReadKey();
        }
    }
}
