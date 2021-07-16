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
    public class FalcultiesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Falculties
        public ActionResult Index()
        {
            return View(db.Falculties.ToList());
        }

        // GET: Falculties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falculty falculty = db.Falculties.Find(id);
            if (falculty == null)
            {
                return HttpNotFound();
            }
            return View(falculty);
        }

        // GET: Falculties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Falculties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FalcultyID,Name")] Falculty falculty)
        {
            if (ModelState.IsValid)
            {
                db.Falculties.Add(falculty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(falculty);
        }

        // GET: Falculties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falculty falculty = db.Falculties.Find(id);
            if (falculty == null)
            {
                return HttpNotFound();
            }
            return View(falculty);
        }

        // POST: Falculties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FalcultyID,Name")] Falculty falculty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(falculty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(falculty);
        }

        // GET: Falculties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falculty falculty = db.Falculties.Find(id);
            if (falculty == null)
            {
                return HttpNotFound();
            }
            return View(falculty);
        }

        // POST: Falculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Falculty falculty = db.Falculties.Find(id);
            db.Falculties.Remove(falculty);
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
