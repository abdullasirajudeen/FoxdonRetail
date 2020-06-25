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
    public class AdminTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: AdminTbls
        public ActionResult Index()
        {
            var adminTbls = db.AdminTbls.Include(a => a.CredenstialTbl);
            return View(adminTbls.ToList());
        }

        // GET: AdminTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminTbl adminTbl = db.AdminTbls.Find(id);
            if (adminTbl == null)
            {
                return HttpNotFound();
            }
            return View(adminTbl);
        }

        // GET: AdminTbls/Create
        public ActionResult Create()
        {
            ViewBag.CredID = new SelectList(db.CredenstialTbls, "CredID", "UserName");
            return View();
        }

        // POST: AdminTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminID,CredID,AdminName")] AdminTbl adminTbl)
        {
            if (ModelState.IsValid)
            {
                db.AdminTbls.Add(adminTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CredID = new SelectList(db.CredenstialTbls, "CredID", "UserName", adminTbl.CredID);
            return View(adminTbl);
        }

        // GET: AdminTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminTbl adminTbl = db.AdminTbls.Find(id);
            if (adminTbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.CredID = new SelectList(db.CredenstialTbls, "CredID", "UserName", adminTbl.CredID);
            return View(adminTbl);
        }

        // POST: AdminTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminID,CredID,AdminName")] AdminTbl adminTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CredID = new SelectList(db.CredenstialTbls, "CredID", "UserName", adminTbl.CredID);
            return View(adminTbl);
        }

        // GET: AdminTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminTbl adminTbl = db.AdminTbls.Find(id);
            if (adminTbl == null)
            {
                return HttpNotFound();
            }
            return View(adminTbl);
        }

        // POST: AdminTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AdminTbl adminTbl = db.AdminTbls.Find(id);
            db.AdminTbls.Remove(adminTbl);
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
