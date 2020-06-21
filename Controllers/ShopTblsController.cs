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
    public class ShopTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: ShopTbls
        public ActionResult Index()
        {
            return View(db.ShopTbls.ToList());
        }

        // GET: ShopTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopTbl shopTbl = db.ShopTbls.Find(id);
            if (shopTbl == null)
            {
                return HttpNotFound();
            }
            return View(shopTbl);
        }

        // GET: ShopTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShopID,ShopName,ShopPlace,ShopCity,GSTIN")] ShopTbl shopTbl)
        {
            if (ModelState.IsValid)
            {
                db.ShopTbls.Add(shopTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shopTbl);
        }

        // GET: ShopTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopTbl shopTbl = db.ShopTbls.Find(id);
            if (shopTbl == null)
            {
                return HttpNotFound();
            }
            return View(shopTbl);
        }

        // POST: ShopTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShopID,ShopName,ShopPlace,ShopCity,GSTIN")] ShopTbl shopTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopTbl);
        }

        // GET: ShopTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopTbl shopTbl = db.ShopTbls.Find(id);
            if (shopTbl == null)
            {
                return HttpNotFound();
            }
            return View(shopTbl);
        }

        // POST: ShopTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ShopTbl shopTbl = db.ShopTbls.Find(id);
            db.ShopTbls.Remove(shopTbl);
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
