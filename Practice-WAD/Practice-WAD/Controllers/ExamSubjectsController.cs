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
    public class ExamSubjectsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ExamSubjects
        public ActionResult Index()
        {
            return View(db.ExamSubjects.ToList());
        }

        // GET: ExamSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            if (examSubject == null)
            {
                return HttpNotFound();
            }
            return View(examSubject);
        }

        // GET: ExamSubjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamSubjectID,Name")] ExamSubject examSubject)
        {
            if (ModelState.IsValid)
            {
                db.ExamSubjects.Add(examSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examSubject);
        }

        // GET: ExamSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            if (examSubject == null)
            {
                return HttpNotFound();
            }
            return View(examSubject);
        }

        // POST: ExamSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamSubjectID,Name")] ExamSubject examSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examSubject);
        }

        // GET: ExamSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            if (examSubject == null)
            {
                return HttpNotFound();
            }
            return View(examSubject);
        }

        // POST: ExamSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            db.ExamSubjects.Remove(examSubject);
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
