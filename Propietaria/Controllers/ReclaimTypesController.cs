using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Propietaria.Models;

namespace Propietaria.Controllers
{
    public class ReclaimTypesController : Controller
    {
        private ReclaimsAndComplaints2Entities db = new ReclaimsAndComplaints2Entities();

        // GET: ReclaimTypes
        public ActionResult Index()
        {
            return View(db.ReclaimType.ToList());
        }

        // GET: ReclaimTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclaimType reclaimType = db.ReclaimType.Find(id);
            if (reclaimType == null)
            {
                return HttpNotFound();
            }
            return View(reclaimType);
        }

        // GET: ReclaimTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReclaimTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReclaimType,Name")] ReclaimType reclaimType)
        {
            if (ModelState.IsValid)
            {
                db.ReclaimType.Add(reclaimType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reclaimType);
        }

        // GET: ReclaimTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclaimType reclaimType = db.ReclaimType.Find(id);
            if (reclaimType == null)
            {
                return HttpNotFound();
            }
            return View(reclaimType);
        }

        // POST: ReclaimTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReclaimType,Name")] ReclaimType reclaimType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclaimType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reclaimType);
        }

        // GET: ReclaimTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclaimType reclaimType = db.ReclaimType.Find(id);
            if (reclaimType == null)
            {
                return HttpNotFound();
            }
            return View(reclaimType);
        }

        // POST: ReclaimTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReclaimType reclaimType = db.ReclaimType.Find(id);
            db.ReclaimType.Remove(reclaimType);
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
