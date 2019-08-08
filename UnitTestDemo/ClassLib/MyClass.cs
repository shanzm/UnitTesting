#region Version Info 
// ===============================================================================
// Project Name        :    ClassLib  
// ===============================================================================
// Class Name          :    MyClass
// Namespace           :    ClassLib 
// Class Version       :    v1.0.0.0
// Class Description   : 
// CLR                 :    4.0.30319.42000  
// Author              :    shanzm
// Create Time         :    2019/8/7 21:54:17
// Update Time         :    2019/8/7 21:54:17
// ===============================================================================
// Copyright © SHANZM-PC  2019 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class MyClass
    {
        public int DoubleValue(int i)
        {
            return i * 2;
        }

        /// <summary>
        /// 计算从from到to的所有整数的和
        /// </summary>
        /// <param name="from">头</param>
        /// <param name="to">尾</param>
        /// <returns></returns>
        public int Sum(int from, int to)
        {
            if (from > to)
            {
                throw new ArgumentException("参数from必须小于to");
            }
            int sum = 0;
            for (int i = from; i <= to; i++)
            {
                sum += i;
            }
            return sum;
        }


        /// <summary>
        /// 年龄异常信息
        /// </summary>
        public const string AgeErrorString = "生日必须小于当前日期";

        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="Birthday"></param>
        /// <returns></returns>
        public int CaculateAge(DateTime Birthday)
        {
            if (DateTime.Now<Birthday )
            {
                throw new ArgumentOutOfRangeException(AgeErrorString);
            }
            return DateTime.Now.Year - Birthday.Year;
        }

    }
}
