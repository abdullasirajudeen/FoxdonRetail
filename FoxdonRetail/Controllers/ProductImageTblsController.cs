using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoxdonRetail.Models;

namespace FoxdonRetail.Controllers
{
    public class ProductImageTblsController : Controller
    {
        private Entities db = new Entities();

        // GET: ProductImageTbls
        public ActionResult Index()
        {
            return View(db.ProductImageTbls.ToList());
        }

        // GET: ProductImageTbls/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImageTbl productImageTbl = db.ProductImageTbls.Find(id);
            if (productImageTbl == null)
            {
                return HttpNotFound();
            }
            return View(productImageTbl);
        }

        // GET: ProductImageTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductImageTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductImageTbl productImageTbl, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (file.ContentLength > 0)
                    {
                        string _Extenstion = Path.GetExtension(file.FileName);
                        if (_Extenstion == ".pdf")
                        {
                            string _FileName = Path.GetFileName(file.FileName);
                            string _path = Path.Combine(Server.MapPath("~/ImageUpload"), _FileName);  //Folder Name ee Blue
                            file.SaveAs(_path);
                            productImageTbl.ImagePath = _FileName;
                            db.ProductImageTbls.Add(productImageTbl);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        ModelState.AddModelError("MeterailPath", "Not Valid File Type");
                    }
                }

            }
            catch
            {
                ModelState.AddModelError("MeterailPath", "Uploading Failed");
            }

            return View(productImageTbl);
        }

        // GET: ProductImageTbls/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImageTbl productImageTbl = db.ProductImageTbls.Find(id);
            if (productImageTbl == null)
            {
                return HttpNotFound();
            }
            return View(productImageTbl);
        }

        // POST: ProductImageTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductImageTbl productImageTbl, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productImageTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productImageTbl);
        }

        // GET: ProductImageTbls/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImageTbl productImageTbl = db.ProductImageTbls.Find(id);
            if (productImageTbl == null)
            {
                return HttpNotFound();
            }
            return View(productImageTbl);
        }

        // POST: ProductImageTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductImageTbl productImageTbl = db.ProductImageTbls.Find(id);
            db.ProductImageTbls.Remove(productImageTbl);
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
