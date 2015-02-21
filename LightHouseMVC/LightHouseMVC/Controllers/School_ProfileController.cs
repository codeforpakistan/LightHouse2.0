using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LightHouseMVC.Controllers
{
    public class School_ProfileController : Controller
    {
        private LightHouseDatabaseEntities db = new LightHouseDatabaseEntities();

        //
        // GET: /School_Profile/

        public ActionResult Index()
        {
            return View(db.School_Profile.ToList());
        }

        //
        // GET: /School_Profile/Details/5

        public ActionResult Details(int id = 0)
        {
            School_Profile school_profile = db.School_Profile.Find(id);
            if (school_profile == null)
            {
                return HttpNotFound();
            }
            return View(school_profile);
        }

        //
        // GET: /School_Profile/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /School_Profile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School_Profile school_profile)
        {
            if (ModelState.IsValid)
            {
                db.School_Profile.Add(school_profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(school_profile);
        }

        //
        // GET: /School_Profile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            School_Profile school_profile = db.School_Profile.Find(id);
            if (school_profile == null)
            {
                return HttpNotFound();
            }
            return View(school_profile);
        }

        //
        // POST: /School_Profile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(School_Profile school_profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(school_profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(school_profile);
        }

        //
        // GET: /School_Profile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            School_Profile school_profile = db.School_Profile.Find(id);
            if (school_profile == null)
            {
                return HttpNotFound();
            }
            return View(school_profile);
        }

        //
        // POST: /School_Profile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            School_Profile school_profile = db.School_Profile.Find(id);
            db.School_Profile.Remove(school_profile);
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