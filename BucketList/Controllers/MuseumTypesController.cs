using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BucketList.Models;

namespace BucketList.Controllers
{
    public class MuseumTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MuseumTypes
        public ActionResult Index()
        {
            return View(db.MuseumTypes.ToList());
        }

        // GET: MuseumTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuseumType museumType = db.MuseumTypes.Find(id);
            if (museumType == null)
            {
                return HttpNotFound();
            }
            return View(museumType);
        }

        // GET: MuseumTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MuseumTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MuseumTypeId,MuseumsType")] MuseumType museumType)
        {
            if (ModelState.IsValid)
            {
                db.MuseumTypes.Add(museumType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(museumType);
        }

        // GET: MuseumTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuseumType museumType = db.MuseumTypes.Find(id);
            if (museumType == null)
            {
                return HttpNotFound();
            }
            return View(museumType);
        }

        // POST: MuseumTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MuseumTypeId,MuseumsType")] MuseumType museumType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(museumType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(museumType);
        }

        // GET: MuseumTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MuseumType museumType = db.MuseumTypes.Find(id);
            if (museumType == null)
            {
                return HttpNotFound();
            }
            return View(museumType);
        }

        // POST: MuseumTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MuseumType museumType = db.MuseumTypes.Find(id);
            db.MuseumTypes.Remove(museumType);
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
