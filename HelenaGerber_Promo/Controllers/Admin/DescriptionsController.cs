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
    [Authorize(Roles = "Holder")]
    public class DescriptionsController : Controller
    {
        private HGStoreDbContext db = new HGStoreDbContext();

        // GET: Descriptions
        public ActionResult Index()
        {
            var descriptions = db.Descriptions.Include(d => d.Color).Include(d => d.Model).Include(d => d.Product).Include(d => d.Size).Include(d => d.Type);
            return View(descriptions.ToList());
        }

        // GET: Descriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // GET: Descriptions/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name");
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id");
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Id");
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
            return View();
        }

        // POST: Descriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,TypeId,ModelId,SizeId,ColorId")] Description description)
        {
            if (ModelState.IsValid)
            {
                db.Descriptions.Add(description);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", description.ColorId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name", description.ModelId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id", description.ProductId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Id", description.SizeId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", description.TypeId);
            return View(description);
        }

        // GET: Descriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", description.ColorId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name", description.ModelId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id", description.ProductId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Id", description.SizeId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", description.TypeId);
            return View(description);
        }

        // POST: Descriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,TypeId,ModelId,SizeId,ColorId")] Description description)
        {
            if (ModelState.IsValid)
            {
                db.Entry(description).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorId = new SelectList(db.Colors, "Id", "Name", description.ColorId);
            ViewBag.ModelId = new SelectList(db.Models, "Id", "Name", description.ModelId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Id", description.ProductId);
            ViewBag.SizeId = new SelectList(db.Sizes, "Id", "Id", description.SizeId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", description.TypeId);
            return View(description);
        }

        // GET: Descriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // POST: Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Description description = db.Descriptions.Find(id);
            db.Descriptions.Remove(description);
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
