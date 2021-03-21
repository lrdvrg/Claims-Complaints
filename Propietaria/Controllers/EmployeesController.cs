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
    public class EmployeesController : Controller
    {
        private ReclaimsAndComplaints2Entities db = new ReclaimsAndComplaints2Entities();

        // GET: Employees
        public ActionResult Index()
        {
            var users = db.Users.Where(s => s.Role.Description == "Empleado").Include(u => u.Country).Include(u => u.IdentificationType).Include(u => u.Role).Include(u => u.UserStatus);
            return View(users.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.IdCountry = new SelectList(db.Country, "IdCountry", "Description");
            ViewBag.IdIdentificationType = new SelectList(db.IdentificationType, "IdIdentificationType", "Name");
            ViewBag.IdRole = new SelectList(db.Role.Where(s => s.Description == "Empleado"), "IdRole", "Description");
            ViewBag.IdUserStatus = new SelectList(db.UserStatus, "IdUserStatus", "Description");
            return View();
        }

        // POST: Employees/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUser,Name,Email,Password,Phone,Date,Provincia,Sector,Municipio,Barrio,Direccion,Direccion2,IdIdentificationType,IdentificationNumber,IdRole,IdUserStatus,IdCountry")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCountry = new SelectList(db.Country, "IdCountry", "Description", users.IdCountry);
            ViewBag.IdIdentificationType = new SelectList(db.IdentificationType, "IdIdentificationType", "Name", users.IdIdentificationType);
            ViewBag.IdRole = new SelectList(db.Role, "IdRole", "Description", users.IdRole);
            ViewBag.IdUserStatus = new SelectList(db.UserStatus, "IdUserStatus", "Description", users.IdUserStatus);
            return View(users);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCountry = new SelectList(db.Country, "IdCountry", "Description", users.IdCountry);
            ViewBag.IdIdentificationType = new SelectList(db.IdentificationType, "IdIdentificationType", "Name", users.IdIdentificationType);
            ViewBag.IdRole = new SelectList(db.Role.Where(s => s.Description == "Empleado"), "IdRole", "Description", users.IdRole);
            ViewBag.IdUserStatus = new SelectList(db.UserStatus, "IdUserStatus", "Description", users.IdUserStatus);
            return View(users);
        }

        // POST: Employees/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUser,Name,Email,Password,Phone,Date,Provincia,Sector,Municipio,Barrio,Direccion,Direccion2,IdIdentificationType,IdentificationNumber,IdRole,IdUserStatus,IdCountry")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCountry = new SelectList(db.Country, "IdCountry", "Description", users.IdCountry);
            ViewBag.IdIdentificationType = new SelectList(db.IdentificationType, "IdIdentificationType", "Name", users.IdIdentificationType);
            ViewBag.IdRole = new SelectList(db.Role, "IdRole", "Description", users.IdRole);
            ViewBag.IdUserStatus = new SelectList(db.UserStatus, "IdUserStatus", "Description", users.IdUserStatus);
            return View(users);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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
