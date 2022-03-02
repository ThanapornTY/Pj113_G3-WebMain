using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project113_G3.Models;

namespace Project113_G3.Controllers
{
    public class UserDatasController : Controller
    {
        private UserDataAccEntities db = new UserDataAccEntities();

        // GET: UserDatas
        public ActionResult Index()
        {
            var userDatas = db.UserDatas.Include(u => u.RQ_Reported);
            return View(userDatas.ToList());
        }

        // GET: UserDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // GET: UserDatas/Create
        public ActionResult Create()
        {
            //ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: UserDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UID,Name,Email_User,Bd_User,GenderUser,Description,User_Id,url,JoinDate")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    file.SaveAs(path);
                    userData.url = fileName;
                }

                /*ตัวกำหนดวันที่*/
                userData.JoinDate = DateTime.Now;

                db.UserDatas.Add(userData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", userData.User_Id);
            return View(userData);
        }

        // GET: UserDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            //ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", userData.User_Id);
            return View(userData);
        }

        // POST: UserDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,Name,Email_User,Bd_User,GenderUser,Description,User_Id,url,JoinDate")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", userData.User_Id);
            return View(userData);
        }

        // GET: UserDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // POST: UserDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserData userData = db.UserDatas.Find(id);
            db.UserDatas.Remove(userData);
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
