using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoxdonRetail.Models;

namespace FoxdonRetail.Controllers
{
    public class ProductTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: ProductTbls
        public ActionResult Index()
        {
            var productTbls = db.ProductTbls.Include(p => p.CategoryTbl).Include(p => p.ShopTbl);
            return View(productTbls.ToList());
        }

        // GET: ProductTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            return View(productTbl);
        }

        // GET: ProductTbls/Create
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.CategoryTbls, "CatID", "CatName");
            ViewBag.ShopID = new SelectList(db.ShopTbls, "ShopID", "ShopName");
            return View();
        }

        // POST: ProductTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,CatID,ShopID,ProductMRP,SellingPrice,FoxdonPrice")] ProductTbl productTbl)
        {
            if (ModelState.IsValid)
            {
                db.ProductTbls.Add(productTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatID = new SelectList(db.CategoryTbls, "CatID", "CatName", productTbl.CatID);
            ViewBag.ShopID = new SelectList(db.ShopTbls, "ShopID", "ShopName", productTbl.ShopID);
            return View(productTbl);
        }

        // GET: ProductTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.CategoryTbls, "CatID", "CatName", productTbl.CatID);
            ViewBag.ShopID = new SelectList(db.ShopTbls, "ShopID", "ShopName", productTbl.ShopID);
            return View(productTbl);
        }

        // POST: ProductTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,CatID,ShopID,ProductMRP,SellingPrice,FoxdonPrice")] ProductTbl productTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.CategoryTbls, "CatID", "CatName", productTbl.CatID);
            ViewBag.ShopID = new SelectList(db.ShopTbls, "ShopID", "ShopName", productTbl.ShopID);
            return View(productTbl);
        }

        // GET: ProductTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTbl productTbl = db.ProductTbls.Find(id);
            if (productTbl == null)
            {
                return HttpNotFound();
            }
            return View(productTbl);
        }

        // POST: ProductTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductTbl productTbl = db.ProductTbls.Find(id);
            db.ProductTbls.Remove(productTbl);
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
