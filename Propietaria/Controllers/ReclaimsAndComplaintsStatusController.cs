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
    public class ReclaimsAndComplaintsStatusController : Controller
    {
        private ReclaimsAndComplaints2Entities db = new ReclaimsAndComplaints2Entities();

        // GET: ReclaimsAndComplaintsStatus
        public ActionResult Index()
        {
            return View(db.ReclaimsAndComplaintsStatus.ToList());
        }

        // GET: ReclaimsAndComplaintsStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclaimsAndComplaintsStatus reclaimsAndComplaintsStatus = db.ReclaimsAndComplaintsStatus.Find(id);
            if (reclaimsAndComplaintsStatus == null)
            {
                return HttpNotFound();
            }
            return View(reclaimsAndComplaintsStatus);
        }

        // GET: ReclaimsAndComplaintsStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReclaimsAndComplaintsStatus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReclaimsAndComplaintsStatus,description")] ReclaimsAndComplaintsStatus reclaimsAndComplaintsStatus)
        {
            if (ModelState.IsValid)
            {
                db.ReclaimsAndComplaintsStatus.Add(reclaimsAndComplaintsStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reclaimsAndComplaintsStatus);
        }

        // GET: ReclaimsAndComplaintsStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclaimsAndComplaintsStatus reclaimsAndComplaintsStatus = db.ReclaimsAndComplaintsStatus.Find(id);
            if (reclaimsAndComplaintsStatus == null)
            {
                return HttpNotFound();
            }
            return View(reclaimsAndComplaintsStatus);
        }

        // POST: ReclaimsAndComplaintsStatus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReclaimsAndComplaintsStatus,description")] ReclaimsAndComplaintsStatus reclaimsAndComplaintsStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclaimsAndComplaintsStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reclaimsAndComplaintsStatus);
        }

        // GET: ReclaimsAndComplaintsStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclaimsAndComplaintsStatus reclaimsAndComplaintsStatus = db.ReclaimsAndComplaintsStatus.Find(id);
            if (reclaimsAndComplaintsStatus == null)
            {
                return HttpNotFound();
            }
            return View(reclaimsAndComplaintsStatus);
        }

        // POST: ReclaimsAndComplaintsStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReclaimsAndComplaintsStatus reclaimsAndComplaintsStatus = db.ReclaimsAndComplaintsStatus.Find(id);
            db.ReclaimsAndComplaintsStatus.Remove(reclaimsAndComplaintsStatus);
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
