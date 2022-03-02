using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project113_G3.Models;

namespace Project113_G3.Controllers
{
    public class Notification_AdminController : Controller
    {
        private NotificationModelEntities db = new NotificationModelEntities();

        // GET: Notification_Admin
        public ActionResult Index()
        {
            return View(db.Notification_Admin.ToList());
        }

        // GET: Notification_Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification_Admin notification_Admin = db.Notification_Admin.Find(id);
            if (notification_Admin == null)
            {
                return HttpNotFound();
            }
            return View(notification_Admin);
        }

        // GET: Notification_Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notification_Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Date_Noti")] Notification_Admin notification_Admin)
        {
            if (ModelState.IsValid)
            {
                notification_Admin.Date_Noti = DateTime.Now;

                db.Notification_Admin.Add(notification_Admin);
                db.SaveChanges();
                return RedirectToAction("Index");

            }


            return View(notification_Admin);
        }

        // GET: Notification_Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification_Admin notification_Admin = db.Notification_Admin.Find(id);
            if (notification_Admin == null)
            {
                return HttpNotFound();
            }
            return View(notification_Admin);
        }

        // POST: Notification_Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Date_Noti")] Notification_Admin notification_Admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification_Admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notification_Admin);
        }

        // GET: Notification_Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification_Admin notification_Admin = db.Notification_Admin.Find(id);
            if (notification_Admin == null)
            {
                return HttpNotFound();
            }
            return View(notification_Admin);
        }

        // POST: Notification_Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notification_Admin notification_Admin = db.Notification_Admin.Find(id);
            db.Notification_Admin.Remove(notification_Admin);
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
