﻿using System;
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
    public class ComplaintsController : Controller
    {
        private ReclaimsAndComplaints2Entities db = new ReclaimsAndComplaints2Entities();

        // GET: Complaints
        public ActionResult Index()
        {
            var oUser = (Users)Session["User"];

            if ((oUser.IdRole == (from e in db.Role where e.Description == "Cliente" select e.IdRole).First()))
            {
                var complaint = db.Complaint.Where(s => s.IdClient == oUser.IdUser).Include(c => c.Users).Include(c => c.ComplaintType).Include(c => c.Department).Include(c => c.Product).Include(c => c.Department1).Include(c => c.ReclaimsAndComplaintsStatus);
                return View(complaint.ToList());

            }
            else
            {
                var complaint = db.Complaint.Include(c => c.Users).Include(c => c.ComplaintType).Include(c => c.Department).Include(c => c.Product).Include(c => c.Department1).Include(c => c.ReclaimsAndComplaintsStatus);
                return View(complaint.ToList());

            }
        }

        // GET: Complaints/Details/5
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

        // GET: Complaints/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Users.Where(s => s.Role.Description == "Cliente"), "IdUser", "Name");
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name");
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name");
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name");
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name");
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description");
            return View();
        }

        // POST: Complaints/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComplaint,IdClient,IdProduct,IdComplaintType,IdOriginDepartment,IdResponsibleDepartment,IdStatus,CreationDate,Description,Comment")] Complaint complaint)
        {

            complaint.IdStatus = (from e in db.ReclaimsAndComplaintsStatus where e.description == "Recibido" select e.IdReclaimsAndComplaintsStatus).First();

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
            return View(complaint);
        }

        // GET: Complaints/Edit/5
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
            ViewBag.IdClient = new SelectList(db.Users.Where(s => s.Role.Description == "Cliente"), "IdUser", "Name", complaint.IdClient);
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name", complaint.IdComplaintType);
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdOriginDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", complaint.IdProduct);
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdResponsibleDepartment);
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description", complaint.IdStatus);
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComplaint,IdClient,IdProduct,IdComplaintType,IdOriginDepartment,IdResponsibleDepartment,IdStatus,CreationDate,Description,Comment")] Complaint complaint)
        {

            complaint.IdStatus = (from e in db.ReclaimsAndComplaintsStatus where e.description == "Recibido" select e.IdReclaimsAndComplaintsStatus).First();

            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Users, "IdUser", "Name", complaint.IdClient);
            ViewBag.IdComplaintType = new SelectList(db.ComplaintType, "IdComplaintType", "Name", complaint.IdComplaintType);
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdOriginDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", complaint.IdProduct);
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name", complaint.IdResponsibleDepartment);
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description", complaint.IdStatus);
            return View(complaint);
        }

        // GET: Complaints/Delete/5
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

        // POST: Complaints/Delete/5
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
