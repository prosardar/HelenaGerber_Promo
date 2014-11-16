using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelenaGerber_Promo.Controllers.Admin
{
    [Authorize(Roles = "Holder")] 
    public class CPController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}