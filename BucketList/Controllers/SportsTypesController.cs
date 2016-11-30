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
    public class SportsTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SportsTypes
        public ActionResult Index()
        {
            return View(db.SportsTypes.ToList());
        }

        // GET: SportsTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportsType sportsType = db.SportsTypes.Find(id);
            if (sportsType == null)
            {
                return HttpNotFound();
            }
            return View(sportsType);
        }

        // GET: SportsTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SportsTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SportsTypeId,SportType")] SportsType sportsType)
        {
            if (ModelState.IsValid)
            {
                db.SportsTypes.Add(sportsType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sportsType);
        }

        // GET: SportsTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportsType sportsType = db.SportsTypes.Find(id);
            if (sportsType == null)
            {
                return HttpNotFound();
            }
            return View(sportsType);
        }

        // POST: SportsTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SportsTypeId,SportType")] SportsType sportsType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sportsType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sportsType);
        }

        // GET: SportsTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportsType sportsType = db.SportsTypes.Find(id);
            if (sportsType == null)
            {
                return HttpNotFound();
            }
            return View(sportsType);
        }

        // POST: SportsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SportsType sportsType = db.SportsTypes.Find(id);
            db.SportsTypes.Remove(sportsType);
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
