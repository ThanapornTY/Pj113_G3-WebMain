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
    public class DataGamesController : Controller
    {
        private DashboardEntities db = new DashboardEntities();

        // GET: DataGames
        public ActionResult Index()
        {
            return View(db.Datagames.ToList());
        }

        // GET: DataGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datagame datagame = db.Datagames.Find(id);
            if (datagame == null)
            {
                return HttpNotFound();
            }
            return View(datagame);
        }

        // GET: DataGames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameGame,TypeGame,Description_Game,url")] Datagame datagame)
        {
            if (ModelState.IsValid)
            {


                db.Datagames.Add(datagame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datagame);
        }

        // GET: DataGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datagame datagame = db.Datagames.Find(id);
            if (datagame == null)
            {
                return HttpNotFound();
            }
            return View(datagame);
        }

        // POST: DataGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameGame,TypeGame,Description_Game,url")] Datagame datagame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datagame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datagame);
        }

        // GET: DataGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datagame datagame = db.Datagames.Find(id);
            if (datagame == null)
            {
                return HttpNotFound();
            }
            return View(datagame);
        }

        // POST: DataGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Datagame datagame = db.Datagames.Find(id);
            db.Datagames.Remove(datagame);
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
