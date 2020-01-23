using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Name = "shanzm1111";
            Person p1 = new Person { Id = 001, Name = "shanzm" };
            return View(p1);
        }
    }
}