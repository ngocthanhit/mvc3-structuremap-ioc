using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleWebsite.Code;

namespace SampleWebsite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IBar bar)
        {
            _bar = bar;
        }

        private IBar _bar;

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC! " + _bar.IPityTheFoo();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
