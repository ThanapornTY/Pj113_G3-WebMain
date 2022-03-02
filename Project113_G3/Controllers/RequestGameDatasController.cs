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
    public class RequestGameDatasController : Controller
    {
        private DashboardEntities db = new DashboardEntities();

        // GET: RequestGameDatas
        public ActionResult Index()
        {
            return View(db.RequestGameDatas.ToList());
        }

        // GET: RequestGameDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestGameData requestGameData = db.RequestGameDatas.Find(id);
            if (requestGameData == null)
            {
                return HttpNotFound();
            }
            return View(requestGameData);
        }

        // GET: RequestGameDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestGameDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RQGUsername,RQGGame,RQGDes")] RequestGameData requestGameData)
        {
            if (ModelState.IsValid)
            {
                db.RequestGameDatas.Add(requestGameData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requestGameData);
        }

        // GET: RequestGameDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestGameData requestGameData = db.RequestGameDatas.Find(id);
            if (requestGameData == null)
            {
                return HttpNotFound();
            }
            return View(requestGameData);
        }

        // POST: RequestGameDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RQGUsername,RQGGame,RQGDes")] RequestGameData requestGameData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestGameData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requestGameData);
        }

        // GET: RequestGameDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestGameData requestGameData = db.RequestGameDatas.Find(id);
            if (requestGameData == null)
            {
                return HttpNotFound();
            }
            return View(requestGameData);
        }

        // POST: RequestGameDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestGameData requestGameData = db.RequestGameDatas.Find(id);
            db.RequestGameDatas.Remove(requestGameData);
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
