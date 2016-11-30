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
    public class ShoppingTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingTypes
        public ActionResult Index()
        {
            return View(db.ShoppingTypes.ToList());
        }

        // GET: ShoppingTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingType shoppingType = db.ShoppingTypes.Find(id);
            if (shoppingType == null)
            {
                return HttpNotFound();
            }
            return View(shoppingType);
        }

        // GET: ShoppingTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingTypeId,ShoppingsType")] ShoppingType shoppingType)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingTypes.Add(shoppingType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingType);
        }

        // GET: ShoppingTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingType shoppingType = db.ShoppingTypes.Find(id);
            if (shoppingType == null)
            {
                return HttpNotFound();
            }
            return View(shoppingType);
        }

        // POST: ShoppingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingTypeId,ShoppingsType")] ShoppingType shoppingType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingType);
        }

        // GET: ShoppingTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingType shoppingType = db.ShoppingTypes.Find(id);
            if (shoppingType == null)
            {
                return HttpNotFound();
            }
            return View(shoppingType);
        }

        // POST: ShoppingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingType shoppingType = db.ShoppingTypes.Find(id);
            db.ShoppingTypes.Remove(shoppingType);
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
