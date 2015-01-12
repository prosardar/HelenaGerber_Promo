using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelenaGerber_Promo.Models.HGStore;
using HelenaGerber_Promo.Utils;
using PagedList;

namespace HelenaGerber_Promo.Controllers
{
    public class HomeController : Controller
    {
        private HGStoreDbContext db = new HGStoreDbContext();
        private const int pageSize = 9;

        public ActionResult Index(int? page)
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.ImageStore);
            int pageNumber = (page ?? 1);
            return View(products.OrderBy(p => p.Id).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Image(string imagename)
        {
            string fullPath = ImageUtils.Combine(imagename);
            if (string.IsNullOrEmpty(fullPath)) {
                throw new HttpException(404, "Not Found");
            }
            return File(fullPath, "image/jpeg");
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