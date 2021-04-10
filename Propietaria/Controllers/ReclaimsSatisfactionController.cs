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
    public class ReclaimsSatisfactionController : Controller
    {
        private ReclaimsAndComplaints2Entities db = new ReclaimsAndComplaints2Entities();

        // GET: ReclaimsSatisfaction
        public ActionResult Index()
        {
            var reclaim = db.Reclaim.Include(r => r.Department).Include(r => r.Department1).Include(r => r.Product).Include(r => r.Users).Include(r => r.ReclaimType).Include(r => r.ReclaimsAndComplaintsStatus).Include(r => r.Satisfaction1);
            return View(reclaim.ToList());
        }

        // GET: ReclaimsSatisfaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclaim reclaim = db.Reclaim.Find(id);
            if (reclaim == null)
            {
                return HttpNotFound();
            }
            return View(reclaim);
        }

        // GET: ReclaimsSatisfaction/Create
        public ActionResult Create()
        {
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name");
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name");
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name");
            ViewBag.IdClient = new SelectList(db.Users, "IdUser", "Name");
            ViewBag.IdReclaimType = new SelectList(db.ReclaimType, "IdReclaimType", "Name");
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description");
            ViewBag.Satisfaction = new SelectList(db.Satisfaction, "IdSatisfaction", "Name");
            return View();
        }

        // POST: ReclaimsSatisfaction/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReclaim,IdClient,IdProduct,IdReclaimType,IdOriginDepartment,IdResponsibleDepartment,IdStatus,CreationDate,Description,Comment,Satisfaction")] Reclaim reclaim)
        {
            if (ModelState.IsValid)
            {
                db.Reclaim.Add(reclaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name", reclaim.IdOriginDepartment);
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name", reclaim.IdResponsibleDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", reclaim.IdProduct);
            ViewBag.IdClient = new SelectList(db.Users, "IdUser", "Name", reclaim.IdClient);
            ViewBag.IdReclaimType = new SelectList(db.ReclaimType, "IdReclaimType", "Name", reclaim.IdReclaimType);
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description", reclaim.IdStatus);
            ViewBag.Satisfaction = new SelectList(db.Satisfaction, "IdSatisfaction", "Name", reclaim.Satisfaction);
            return View(reclaim);
        }

        // GET: ReclaimsSatisfaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclaim reclaim = db.Reclaim.Find(id);
            if (reclaim == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name", reclaim.IdOriginDepartment);
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name", reclaim.IdResponsibleDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", reclaim.IdProduct);
            ViewBag.IdClient = new SelectList(db.Users, "IdUser", "Name", reclaim.IdClient);
            ViewBag.IdReclaimType = new SelectList(db.ReclaimType, "IdReclaimType", "Name", reclaim.IdReclaimType);
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description", reclaim.IdStatus);
            ViewBag.Satisfaction = new SelectList(db.Satisfaction, "IdSatisfaction", "Name", reclaim.Satisfaction);
            return View(reclaim);
        }

        // POST: ReclaimsSatisfaction/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReclaim,IdClient,IdProduct,IdReclaimType,IdOriginDepartment,IdResponsibleDepartment,IdStatus,CreationDate,Description,Comment,Satisfaction")] Reclaim reclaim)
        {

            reclaim.IdStatus = (from e in db.ReclaimsAndComplaintsStatus where e.description == "Calificada" select e.IdReclaimsAndComplaintsStatus).First();


            if (ModelState.IsValid)
            {
                db.Entry(reclaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Reclaims/Index");

            }
            ViewBag.IdOriginDepartment = new SelectList(db.Department, "IdDepartment", "Name", reclaim.IdOriginDepartment);
            ViewBag.IdResponsibleDepartment = new SelectList(db.Department, "IdDepartment", "Name", reclaim.IdResponsibleDepartment);
            ViewBag.IdProduct = new SelectList(db.Product, "IdProduct", "Name", reclaim.IdProduct);
            ViewBag.IdClient = new SelectList(db.Users, "IdUser", "Name", reclaim.IdClient);
            ViewBag.IdReclaimType = new SelectList(db.ReclaimType, "IdReclaimType", "Name", reclaim.IdReclaimType);
            ViewBag.IdStatus = new SelectList(db.ReclaimsAndComplaintsStatus, "IdReclaimsAndComplaintsStatus", "description", reclaim.IdStatus);
            ViewBag.Satisfaction = new SelectList(db.Satisfaction, "IdSatisfaction", "Name", reclaim.Satisfaction);
            return RedirectToAction("../Reclaims/Index");

        }

        // GET: ReclaimsSatisfaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclaim reclaim = db.Reclaim.Find(id);
            if (reclaim == null)
            {
                return HttpNotFound();
            }
            return View(reclaim);
        }

        // POST: ReclaimsSatisfaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclaim reclaim = db.Reclaim.Find(id);
            db.Reclaim.Remove(reclaim);
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
