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
    public class FabricsController : Controller
    {
        private HGStoreDbContext db = new HGStoreDbContext();

        // GET: Fabrics
        public ActionResult Index()
        {
            var fabrics = db.Fabrics.Include(f => f.Material).Include(f => f.Product);
            return View(fabrics.ToList());
        }

        // GET: Fabrics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabric fabric = db.Fabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            return View(fabric);
        }

        // GET: Fabrics/Create
        public ActionResult Create()
        {
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id");
            return View();
        }

        // POST: Fabrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,MaterialId,Сontents")] Fabric fabric)
        {
            if (ModelState.IsValid)
            {
                db.Fabrics.Add(fabric);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name", fabric.MaterialId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id", fabric.ProductId);
            return View(fabric);
        }

        // GET: Fabrics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabric fabric = db.Fabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name", fabric.MaterialId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id", fabric.ProductId);
            return View(fabric);
        }

        // POST: Fabrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,MaterialId,Сontents")] Fabric fabric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "Name", fabric.MaterialId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id", fabric.ProductId);
            return View(fabric);
        }

        // GET: Fabrics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabric fabric = db.Fabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            return View(fabric);
        }

        // POST: Fabrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fabric fabric = db.Fabrics.Find(id);
            db.Fabrics.Remove(fabric);
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
