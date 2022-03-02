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
    public class RQ_ReportedController : Controller
    {
        private UserDataAccEntities db = new UserDataAccEntities();

        // GET: RQ_Reported
        public ActionResult Index()
        {
            return View(db.RQ_Reported.ToList());
        }

        // GET: RQ_Reported/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RQ_Reported rQ_Reported = db.RQ_Reported.Find(id);
            if (rQ_Reported == null)
            {
                return HttpNotFound();
            }
            return View(rQ_Reported);
        }

        // GET: RQ_Reported/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RQ_Reported/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RQrp_Id,RQrp_ByUsername,RQrp_ToUserName,RQrp_Toppic,RQrp_Date,RQrp_Note")] RQ_Reported rQ_Reported)
        {
            if (ModelState.IsValid)
            {
                db.RQ_Reported.Add(rQ_Reported);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rQ_Reported);
        }

        // GET: RQ_Reported/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RQ_Reported rQ_Reported = db.RQ_Reported.Find(id);
            if (rQ_Reported == null)
            {
                return HttpNotFound();
            }
            return View(rQ_Reported);
        }

        // POST: RQ_Reported/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RQrp_Id,RQrp_ByUsername,RQrp_ToUserName,RQrp_Toppic,RQrp_Date,RQrp_Note")] RQ_Reported rQ_Reported)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rQ_Reported).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rQ_Reported);
        }

        // GET: RQ_Reported/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RQ_Reported rQ_Reported = db.RQ_Reported.Find(id);
            if (rQ_Reported == null)
            {
                return HttpNotFound();
            }
            return View(rQ_Reported);
        }

        // POST: RQ_Reported/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RQ_Reported rQ_Reported = db.RQ_Reported.Find(id);
            db.RQ_Reported.Remove(rQ_Reported);
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
