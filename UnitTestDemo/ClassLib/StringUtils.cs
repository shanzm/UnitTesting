#region Version Info 
// ===============================================================================
// Project Name        :    ClassLib  
// ===============================================================================
// Class Name          :    StringUtils
// Namespace           :    ClassLib 
// Class Version       :    v1.0.0.0
// Class Description   : 
// CLR                 :    4.0.30319.42000  
// Author              :    shanzm
// Create Time         :    2019/8/8 1:52:45
// Update Time         :    2019/8/8 1:52:45
// ===============================================================================
// Copyright © SHANZM-PC  2019 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLib
{
    public class StringUtils
    {
        public static string Reverse(string str)
        {
            //"\s"匹配任意的空白符
            string[] strArray = Regex.Split(str, @"\s").Reverse().ToArray();
            return string.Join(" ", strArray);

            #region 第三次重构
            //string[] strArray = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            //return string.Join(" ", strArray);
            #endregion

            #region 第二次重构
            //string[] strArray = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //StringBuilder sb = new StringBuilder();
            //for (int i = strArray.Length - 1; i >= 1; i--)
            //{
            //    sb.Append(strArray[i] + " ");
            //}
            //sb.Append(strArray[0]);
            //return sb.ToString();
            #endregion

            #region 第一次重构
            //string[] strArray = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < (strArray .Length-1)/2; i++)
            //{
            //    string temp = strArray[i];
            //    strArray[i] = strArray[strArray.Length - 1 - i];
            //    strArray[strArray.Length - 1 - i] = temp;
            //}
            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i <= strArray .Length-2 ; i++)
            //{
            //    sb.Append(strArray[i] + " ");
            //}
            //sb.Append(strArray[strArray.Length - 1]);//注意数组中最后一个不需要添加一个空格
            //return sb.ToString ();
            #endregion
        }
    }
}
