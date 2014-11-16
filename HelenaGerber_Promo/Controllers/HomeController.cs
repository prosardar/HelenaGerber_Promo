using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelenaGerber_Promo.Utils;

namespace HelenaGerber_Promo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Image(string imagename)
        {
            string fullPath = Path.Combine(ImageUtils.GetDataImagePath(), imagename);
            return File(fullPath, "image/png"); 
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
    }
}