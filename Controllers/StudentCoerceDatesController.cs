using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Report.Models;

namespace Report.Controllers
{
    public class StudentCoerceDatesController : Controller
    {
        private ConnectionString db = new ConnectionString();

        // GET: StudentCoerceDates
        public ActionResult Index()
        {
            var studentCoerceDates = db.StudentCoerceDates.Include(s => s.UserDetail);
            return View(studentCoerceDates.ToList());
        }

        // GET: StudentCoerceDates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCoerceDate studentCoerceDate = db.StudentCoerceDates.Find(id);
            if (studentCoerceDate == null)
            {
                return HttpNotFound();
            }
            return View(studentCoerceDate);
        }

        // GET: StudentCoerceDates/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "Name");
            return View();
        }

        // POST: StudentCoerceDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SCourseDateId,UserId,StartDate,PlanedFinishDate,CourseId")] StudentCoerceDate studentCoerceDate)
        {
            if (ModelState.IsValid)
            {
                db.StudentCoerceDates.Add(studentCoerceDate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "Name", studentCoerceDate.UserId);
            return View(studentCoerceDate);
        }

        // GET: StudentCoerceDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCoerceDate studentCoerceDate = db.StudentCoerceDates.Find(id);
            if (studentCoerceDate == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "Name", studentCoerceDate.UserId);
            return View(studentCoerceDate);
        }

        // POST: StudentCoerceDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SCourseDateId,UserId,StartDate,PlanedFinishDate,CourseId")] StudentCoerceDate studentCoerceDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCoerceDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserDetails, "UserId", "Name", studentCoerceDate.UserId);
            return View(studentCoerceDate);
        }

        // GET: StudentCoerceDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCoerceDate studentCoerceDate = db.StudentCoerceDates.Find(id);
            if (studentCoerceDate == null)
            {
                return HttpNotFound();
            }
            return View(studentCoerceDate);
        }

        // POST: StudentCoerceDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCoerceDate studentCoerceDate = db.StudentCoerceDates.Find(id);
            db.StudentCoerceDates.Remove(studentCoerceDate);
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
