using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseDemo.Models;

namespace DatabaseDemo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ApplicationContext db = new ApplicationContext();
            var students = db.Students.ToList();
            return View(students);
        }
    }
}