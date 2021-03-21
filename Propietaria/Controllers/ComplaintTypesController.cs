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
    public class ComplaintTypesController : Controller
    {
        private ReclaimsAndComplaints2Entities db = new ReclaimsAndComplaints2Entities();

        // GET: ComplaintTypes
        public ActionResult Index()
        {
            return View(db.ComplaintType.ToList());
        }

        // GET: ComplaintTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintType complaintType = db.ComplaintType.Find(id);
            if (complaintType == null)
            {
                return HttpNotFound();
            }
            return View(complaintType);
        }

        // GET: ComplaintTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplaintTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComplaintType,Name")] ComplaintType complaintType)
        {
            if (ModelState.IsValid)
            {
                db.ComplaintType.Add(complaintType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaintType);
        }

        // GET: ComplaintTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintType complaintType = db.ComplaintType.Find(id);
            if (complaintType == null)
            {
                return HttpNotFound();
            }
            return View(complaintType);
        }

        // POST: ComplaintTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComplaintType,Name")] ComplaintType complaintType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaintType);
        }

        // GET: ComplaintTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintType complaintType = db.ComplaintType.Find(id);
            if (complaintType == null)
            {
                return HttpNotFound();
            }
            return View(complaintType);
        }

        // POST: ComplaintTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplaintType complaintType = db.ComplaintType.Find(id);
            db.ComplaintType.Remove(complaintType);
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
