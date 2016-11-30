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
    public class EntertainmentTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EntertainmentTypes
        public ActionResult Index()
        {
            return View(db.EntertainmentTypes.ToList());
        }

        // GET: EntertainmentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntertainmentType entertainmentType = db.EntertainmentTypes.Find(id);
            if (entertainmentType == null)
            {
                return HttpNotFound();
            }
            return View(entertainmentType);
        }

        // GET: EntertainmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntertainmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntertainmentTypeId,EntertainmentsType")] EntertainmentType entertainmentType)
        {
            if (ModelState.IsValid)
            {
                db.EntertainmentTypes.Add(entertainmentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entertainmentType);
        }

        // GET: EntertainmentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntertainmentType entertainmentType = db.EntertainmentTypes.Find(id);
            if (entertainmentType == null)
            {
                return HttpNotFound();
            }
            return View(entertainmentType);
        }

        // POST: EntertainmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntertainmentTypeId,EntertainmentsType")] EntertainmentType entertainmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entertainmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entertainmentType);
        }

        // GET: EntertainmentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntertainmentType entertainmentType = db.EntertainmentTypes.Find(id);
            if (entertainmentType == null)
            {
                return HttpNotFound();
            }
            return View(entertainmentType);
        }

        // POST: EntertainmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntertainmentType entertainmentType = db.EntertainmentTypes.Find(id);
            db.EntertainmentTypes.Remove(entertainmentType);
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
