using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseDemo.Controllers
{
    public class TestChildActionController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        [ActionName("CoolMenu")]
        public ActionResult Menu()
        {
            var menu = new List<string>()
            {
                "Item 1",
                "Item 2",
                "Item 3"
            };
            return PartialView("Menu", menu);
        }
    }
}