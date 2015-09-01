using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
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

        public ActionResult EA()
        {
            ViewBag.Message = "I'm a verb now Lana, DEAL WITH IT!";

            return View();
        }

        public ActionResult Nielsen()
        {
            ViewBag.Message = "Just DO IT! Don't let your dreams stay dreams!";

            return View();
        }
    }
}