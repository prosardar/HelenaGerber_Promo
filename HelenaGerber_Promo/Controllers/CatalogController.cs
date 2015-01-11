using System;
using System.Linq;
using System.Web.Mvc;
using HelenaGerber_Promo.Models.HGStore;

namespace HelenaGerber_Promo.Controllers
{
    [HandleError]
    public class CatalogController : Controller
    {
        private HGStoreDbContext db = new HGStoreDbContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult BowTie(string name)
        {
            if (string.IsNullOrEmpty(name)) {
                return BowTies();
            }
            Product product = db.Products.SingleOrDefault(p => p.Name == name);
            if (product == null) {
                throw new ArgumentException("Не найден товар в базе");
            }
            return View(product);
        }


        public ActionResult BowTies()
        {
            return View();
        }
    }
}