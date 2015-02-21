using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LightHouseMVC.Controllers
{
    public class Parent_ProfileController : Controller
    {
        private LightHouseDatabaseEntities db = new LightHouseDatabaseEntities();

        //
        // GET: /Parent_Profile/

        public ActionResult Index()
        {
            var parent_profile = db.Parent_Profile.Include(p => p.School_Profile);
            return View(parent_profile.ToList());
        }

        //
        // GET: /Parent_Profile/Details/5

        public ActionResult Details(int id = 0)
        {
            Parent_Profile parent_profile = db.Parent_Profile.Find(id);
            if (parent_profile == null)
            {
                return HttpNotFound();
            }
            return View(parent_profile);
        }

        //
        // GET: /Parent_Profile/Create

        public ActionResult Create()
        {
            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username");
            return View();
        }

        //
        // POST: /Parent_Profile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Parent_Profile parent_profile)
        {
            if (ModelState.IsValid)
            {
                db.Parent_Profile.Add(parent_profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username", parent_profile.School_ID);
            return View(parent_profile);
        }

        //
        // GET: /Parent_Profile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Parent_Profile parent_profile = db.Parent_Profile.Find(id);
            if (parent_profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username", parent_profile.School_ID);
            return View(parent_profile);
        }

        //
        // POST: /Parent_Profile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Parent_Profile parent_profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parent_profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username", parent_profile.School_ID);
            return View(parent_profile);
        }

        //
        // GET: /Parent_Profile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Parent_Profile parent_profile = db.Parent_Profile.Find(id);
            if (parent_profile == null)
            {
                return HttpNotFound();
            }
            return View(parent_profile);
        }

        //
        // POST: /Parent_Profile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parent_Profile parent_profile = db.Parent_Profile.Find(id);
            db.Parent_Profile.Remove(parent_profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}