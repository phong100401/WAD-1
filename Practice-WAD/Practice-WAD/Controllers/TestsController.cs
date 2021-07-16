using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practice_WAD.Context;
using Practice_WAD.Models;

namespace Practice_WAD.Controllers
{
    public class TestsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Tests
        public ActionResult Index()
        {
            var tests = db.Tests.Include(t => t.Classroom).Include(t => t.ExamSubject).Include(t => t.Falculty);
            return View(tests.ToList());
        }

        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "Name");
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "ExamSubjectID", "Name");
            ViewBag.FalcultyID = new SelectList(db.Falculties, "FalcultyID", "Name");
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Starttime,ExamDate,ExamDur,ClassroomID,ExamSubjectID,FalcultyID")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "Name", test.ClassroomID);
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "ExamSubjectID", "Name", test.ExamSubjectID);
            ViewBag.FalcultyID = new SelectList(db.Falculties, "FalcultyID", "Name", test.FalcultyID);
            return View(test);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "Name", test.ClassroomID);
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "ExamSubjectID", "Name", test.ExamSubjectID);
            ViewBag.FalcultyID = new SelectList(db.Falculties, "FalcultyID", "Name", test.FalcultyID);
            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Starttime,ExamDate,ExamDur,ClassroomID,ExamSubjectID,FalcultyID")] Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassroomID = new SelectList(db.Classrooms, "ClassroomID", "Name", test.ClassroomID);
            ViewBag.ExamSubjectID = new SelectList(db.ExamSubjects, "ExamSubjectID", "Name", test.ExamSubjectID);
            ViewBag.FalcultyID = new SelectList(db.Falculties, "FalcultyID", "Name", test.FalcultyID);
            return View(test);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
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
