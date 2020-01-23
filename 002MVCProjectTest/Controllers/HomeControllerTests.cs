using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCProject.Controllers;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCProject.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            HomeController hContr = new HomeController();
            ViewResult result = (ViewResult)hContr.Index();

            string viewName = result.ViewName;
            Person model = (Person)result.Model;
            string ViewBagName = result.ViewData["Name"].ToString();
            #region 注释说明
            //此处中viewName是空，为什么，在View()函数中，有多重承载
            //一个参数的是直接写一个数据类，传递到默认的与Action同名的视图中
            //因为只写了一个参数，所以此处的viewName为空

            //若是HomeController中的Index()中是 return View("Index",p1);
            //Assert.IsTrue(model.Id == 001
            //              && model.Name == "shanzm"
            //              && viewName=="Index");

            //注意在Action中的ViewBag传递的数据在单元测试中需要通过ViewData方式获取
            //因为ViewBag是对ViewData的动态封装，在同一个Action中二者数据相通，此乃ASP.NET MVC的基础，不详述
            #endregion
            Assert.IsTrue(model.Id == 001
                         && model.Name == "shanzm"
                         && string.IsNullOrEmpty(viewName)
                         && ViewBagName == "shanzm1111");
        }
    }
}