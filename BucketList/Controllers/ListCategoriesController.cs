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
    public class ListCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListCategories
        public ActionResult Index()
        {
            return View(db.ListCategories.ToList());
        }

        // GET: ListCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListCategory listCategory = db.ListCategories.Find(id);
            if (listCategory == null)
            {
                return HttpNotFound();
            }
            return View(listCategory);
        }

        // GET: ListCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListCategoryId,ListCategories")] ListCategory listCategory)
        {
            if (ModelState.IsValid)
            {
                db.ListCategories.Add(listCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listCategory);
        }

        // GET: ListCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListCategory listCategory = db.ListCategories.Find(id);
            if (listCategory == null)
            {
                return HttpNotFound();
            }
            return View(listCategory);
        }

        // POST: ListCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListCategoryId,ListCategories")] ListCategory listCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listCategory);
        }

        // GET: ListCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListCategory listCategory = db.ListCategories.Find(id);
            if (listCategory == null)
            {
                return HttpNotFound();
            }
            return View(listCategory);
        }

        // POST: ListCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListCategory listCategory = db.ListCategories.Find(id);
            db.ListCategories.Remove(listCategory);
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
