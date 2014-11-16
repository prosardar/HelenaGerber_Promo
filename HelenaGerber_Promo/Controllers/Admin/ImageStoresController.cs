using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelenaGerber_Promo.Models.HGStore;

namespace HelenaGerber_Promo.Controllers.Admin
{
    public class ImageStoresController : Controller
    {
        private HGStoreDbContext db = new HGStoreDbContext();

        // GET: ImageStores
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }

        // GET: ImageStores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageStore imageStore = db.Images.Find(id);
            if (imageStore == null)
            {
                return HttpNotFound();
            }
            return View(imageStore);
        }

        // GET: ImageStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FileName1,FileName2,FileName3")] ImageStore imageStore)
        {
            if (ModelState.IsValid)
            {
                db.Images.Add(imageStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imageStore);
        }

        // GET: ImageStores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageStore imageStore = db.Images.Find(id);
            if (imageStore == null)
            {
                return HttpNotFound();
            }
            return View(imageStore);
        }

        // POST: ImageStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName1,FileName2,FileName3")] ImageStore imageStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imageStore);
        }

        // GET: ImageStores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageStore imageStore = db.Images.Find(id);
            if (imageStore == null)
            {
                return HttpNotFound();
            }
            return View(imageStore);
        }

        // POST: ImageStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageStore imageStore = db.Images.Find(id);
            db.Images.Remove(imageStore);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
