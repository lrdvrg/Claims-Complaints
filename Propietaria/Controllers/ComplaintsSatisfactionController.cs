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
    public class ComplaintsSatisfactionController : Controller
    {
        private ReclaimsAndComplaints2Entities db = new ReclaimsAndComplaints2Entities();

        // GET: ComplaintsSatisfaction
        public ActionResult Index()
        {
            var complaint = db.Complaint.Include(c => c.Users).Include(c => c.ComplaintType).Include(c => c.Department).Include(c => c.Product).Include(c => c.Department1).Include(c => c.ReclaimsAndComplaintsStatus).Include(c => c.Satisfaction1);
            return View(complaint.ToList());
        }

        // GET: ComplaintsSatisfaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaint.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // GET: ComplaintsSatisfaction/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Users, "IdUser", "Name");
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name");
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name");
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name");
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name");
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description");
            ViewBag.Satisfaction = new SelectList(db.Satisfaction, "IdSatisfaction", "Name");
            return View();
        }

        // POST: ComplaintsSatisfaction/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComplaint,IdClient,IdProduct,IdComplaintType,IdOriginDepartment,IdResponsibleDepartment,IdStatus,CreationDate,Description,Comment,Satisfaction")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                db.Complaint.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Users, "IdUser", "Name", complaint.IdClient);
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name", complaint.IdComplaintType);
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdOriginDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", complaint.IdProduct);
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdResponsibleDepartment);
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description", complaint.IdStatus);
            ViewBag.Satisfaction = new SelectList(db.Satisfaction, "IdSatisfaction", "Name", complaint.Satisfaction);
            return View(complaint);
        }

        // GET: ComplaintsSatisfaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaint.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Users, "IdUser", "Name", complaint.IdClient);
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name", complaint.IdComplaintType);
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdOriginDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", complaint.IdProduct);
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdResponsibleDepartment);
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description", complaint.IdStatus);
            ViewBag.Satisfaction = new SelectList(db.Satisfaction, "IdSatisfaction", "Name", complaint.Satisfaction);
            return View(complaint);
        }

        // POST: ComplaintsSatisfaction/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComplaint,IdClient,IdProduct,IdComplaintType,IdOriginDepartment,IdResponsibleDepartment,IdStatus,CreationDate,Description,Comment,Satisfaction")] Complaint complaint)
        {

            complaint.IdStatus = (from e in db.ReclaimsAndComplaintsStatus where e.description == "Calificada" select e.IdReclaimsAndComplaintsStatus).First();

            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Complaints/Index");

            }
            ViewBag.IdClient = new SelectList(db.Users, "IdUser", "Name", complaint.IdClient);
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name", complaint.IdComplaintType);
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdOriginDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", complaint.IdProduct);
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdResponsibleDepartment);
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description", complaint.IdStatus);
            ViewBag.Satisfaction = new SelectList(db.Satisfaction, "IdSatisfaction", "Name", complaint.Satisfaction);
            return RedirectToAction("../Complaints/Index");

        }

        // GET: ComplaintsSatisfaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaint.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: ComplaintsSatisfaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complaint complaint = db.Complaint.Find(id);
            db.Complaint.Remove(complaint);
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
