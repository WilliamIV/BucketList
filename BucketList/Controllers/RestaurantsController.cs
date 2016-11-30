using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BucketList.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BucketList.Controllers
{
    public class RestaurantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Restaurants
        public ActionResult Index()
        {
            var restaurants = db.restaurants.Include(r => r.RestraurantsType);
            return View(restaurants.ToList());
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurants restaurants = db.restaurants.Find(id);
            if (restaurants == null)
            {
                return HttpNotFound();
            }
            return View(restaurants);
        }
        public ActionResult AddToUserList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurants restaurants = db.restaurants.Find(id);
            if (restaurants == null)
            {
                return HttpNotFound();
            }

            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());

            UserList newlist = new UserList();
            newlist.Title = restaurants.Title;
            newlist.Description = restaurants.Description;
            newlist.Link = restaurants.Link;
            newlist.Location = restaurants.Location;
            newlist.ListCategoryId = 1;  //have to use # be sure to confirm the numbers in List Categories.
            newlist.UserName = currentUser;
            db.UserLists.Add(newlist);

            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult SeeWhoElse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurants restaurants = db.restaurants.Find(id);
            if (restaurants == null)
            {
                return HttpNotFound();
            }

            IQueryable<UserList> whoList = db.UserLists.Where(l => l.Title.ToLower() == restaurants.Title.ToLower());
            List<ApplicationUser> ids = whoList.Select(i => i.UserName).ToList();
            ViewBag.whoUser = ids;

            return View(restaurants);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            ViewBag.RestraurantTypeId = new SelectList(db.RestraurantTypes, "RestraurantTypeId", "RestraurantsType");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantId,Title,Description,Link,Location,RestraurantTypeId")] Restaurants restaurants)
        {
            if (ModelState.IsValid)
            {
                db.restaurants.Add(restaurants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestraurantTypeId = new SelectList(db.RestraurantTypes, "RestraurantTypeId", "RestraurantsType", restaurants.RestraurantTypeId);
            return View(restaurants);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurants restaurants = db.restaurants.Find(id);
            if (restaurants == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestraurantTypeId = new SelectList(db.RestraurantTypes, "RestraurantTypeId", "RestraurantsType", restaurants.RestraurantTypeId);
            return View(restaurants);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantId,Title,Description,Link,Location,RestraurantTypeId")] Restaurants restaurants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestraurantTypeId = new SelectList(db.RestraurantTypes, "RestraurantTypeId", "RestraurantsType", restaurants.RestraurantTypeId);
            return View(restaurants);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurants restaurants = db.restaurants.Find(id);
            if (restaurants == null)
            {
                return HttpNotFound();
            }
            return View(restaurants);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurants restaurants = db.restaurants.Find(id);
            db.restaurants.Remove(restaurants);
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
