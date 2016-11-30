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
    public class RestraurantTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RestraurantTypes
        public ActionResult Index()
        {
            return View(db.RestraurantTypes.ToList());
        }

        // GET: RestraurantTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestraurantType restraurantType = db.RestraurantTypes.Find(id);
            if (restraurantType == null)
            {
                return HttpNotFound();
            }
            return View(restraurantType);
        }

        // GET: RestraurantTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestraurantTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestraurantTypeId,RestraurantsType")] RestraurantType restraurantType)
        {
            if (ModelState.IsValid)
            {
                db.RestraurantTypes.Add(restraurantType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restraurantType);
        }

        // GET: RestraurantTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestraurantType restraurantType = db.RestraurantTypes.Find(id);
            if (restraurantType == null)
            {
                return HttpNotFound();
            }
            return View(restraurantType);
        }

        // POST: RestraurantTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestraurantTypeId,RestraurantsType")] RestraurantType restraurantType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restraurantType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restraurantType);
        }

        // GET: RestraurantTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestraurantType restraurantType = db.RestraurantTypes.Find(id);
            if (restraurantType == null)
            {
                return HttpNotFound();
            }
            return View(restraurantType);
        }

        // POST: RestraurantTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestraurantType restraurantType = db.RestraurantTypes.Find(id);
            db.RestraurantTypes.Remove(restraurantType);
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
