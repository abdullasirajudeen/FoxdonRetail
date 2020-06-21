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
    public class CredenstialTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: CredenstialTbls
        public ActionResult Index()
        {
            return View(db.CredenstialTbls.ToList());
        }

        // GET: CredenstialTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CredenstialTbl credenstialTbl = db.CredenstialTbls.Find(id);
            if (credenstialTbl == null)
            {
                return HttpNotFound();
            }
            return View(credenstialTbl);
        }

        // GET: CredenstialTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CredenstialTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CredID,UserName,Password")] CredenstialTbl credenstialTbl)
        {
            if (ModelState.IsValid)
            {
                db.CredenstialTbls.Add(credenstialTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(credenstialTbl);
        }

        // GET: CredenstialTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CredenstialTbl credenstialTbl = db.CredenstialTbls.Find(id);
            if (credenstialTbl == null)
            {
                return HttpNotFound();
            }
            return View(credenstialTbl);
        }

        // POST: CredenstialTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CredID,UserName,Password")] CredenstialTbl credenstialTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(credenstialTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(credenstialTbl);
        }

        // GET: CredenstialTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CredenstialTbl credenstialTbl = db.CredenstialTbls.Find(id);
            if (credenstialTbl == null)
            {
                return HttpNotFound();
            }
            return View(credenstialTbl);
        }

        // POST: CredenstialTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CredenstialTbl credenstialTbl = db.CredenstialTbls.Find(id);
            db.CredenstialTbls.Remove(credenstialTbl);
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
