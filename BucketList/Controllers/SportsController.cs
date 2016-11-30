using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BucketList.Models;
using System.Net;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;



namespace BucketList.Controllers
{
    public class SportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sports
        public ActionResult Index()
        {
            var sports = db.sports.Include(s => s.SportType);
            return View(sports.ToList());
        }

        // GET: Sports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sports sports = db.sports.Find(id);
            if (sports == null)
            {
                return HttpNotFound();
            }
            return View(sports);
        }

        //Adding items to user list
        public ActionResult AddToUserList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sports sports = db.sports.Find(id);
            if (sports == null)
            {
                return HttpNotFound();
            }

            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());

            UserList newlist = new UserList();
            newlist.Title = sports.Title;
            newlist.Description = sports.Description;
            newlist.Link = sports.Link;
            newlist.Location = sports.Location;
            newlist.ListCategoryId = 5;  //have to use # be sure to confirm the numbers in List Categories.
            newlist.UserName = currentUser;
            db.UserLists.Add(newlist);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //A list of others wanting to go to the same event
        public ActionResult SeeWhoElse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sports sports = db.sports.Find(id);
            if (sports == null)
            {
                return HttpNotFound();
            }


            IQueryable<UserList> whoList = db.UserLists.Where(l => l.Title.ToLower() == sports.Title.ToLower());
            List<ApplicationUser> ids = whoList.Select(i => i.UserName).ToList();
            ViewBag.whoUser = ids;

            return View(sports);
        }

        // GET: Sports/Create
        public ActionResult Create()
        {
            ViewBag.SportTypeId = new SelectList(db.SportsTypes, "SportsTypeId", "SportType");
            return View();
        }

        // POST: Sports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SportsId,Title,Description,Link,SportTypeId")] Sports sports)
        {
            if (ModelState.IsValid)
            {
                db.sports.Add(sports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SportTypeId = new SelectList(db.SportsTypes, "SportsTypeId", "SportType", sports.SportTypeId);
            return View(sports);
        }

        // GET: Sports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sports sports = db.sports.Find(id);
            if (sports == null)
            {
                return HttpNotFound();
            }
            ViewBag.SportTypeId = new SelectList(db.SportsTypes, "SportsTypeId", "SportType", sports.SportTypeId);
            return View(sports);
        }

        // POST: Sports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SportsId,Title,Description,Link,SportTypeId")] Sports sports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SportTypeId = new SelectList(db.SportsTypes, "SportsTypeId", "SportType", sports.SportTypeId);
            return View(sports);
        }

        // GET: Sports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sports sports = db.sports.Find(id);
            if (sports == null)
            {
                return HttpNotFound();
            }
            return View(sports);
        }

        // POST: Sports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sports sports = db.sports.Find(id);
            db.sports.Remove(sports);
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
