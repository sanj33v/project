using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Employee(App.Entites.Empolyee empolyee)
        {
            try
            {
                App.BL.EntitiesHandler.EmployeeHandler.Save(empolyee, "Employee");
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

    }
}