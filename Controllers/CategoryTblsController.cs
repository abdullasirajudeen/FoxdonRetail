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
    public class CategoryTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: CategoryTbls
        public ActionResult Index()
        {
            return View(db.CategoryTbls.ToList());
        }

        // GET: CategoryTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            if (categoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(categoryTbl);
        }

        // GET: CategoryTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatID,CatName")] CategoryTbl categoryTbl)
        {
            if (ModelState.IsValid)
            {
                db.CategoryTbls.Add(categoryTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryTbl);
        }

        // GET: CategoryTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            if (categoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(categoryTbl);
        }

        // POST: CategoryTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatID,CatName")] CategoryTbl categoryTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryTbl);
        }

        // GET: CategoryTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            if (categoryTbl == null)
            {
                return HttpNotFound();
            }
            return View(categoryTbl);
        }

        // POST: CategoryTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CategoryTbl categoryTbl = db.CategoryTbls.Find(id);
            db.CategoryTbls.Remove(categoryTbl);
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
