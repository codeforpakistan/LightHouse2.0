using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LightHouseMVC.Controllers
{
    public class Teacher_ProfileController : Controller
    {
        private LightHouseDatabaseEntities db = new LightHouseDatabaseEntities();

        //
        // GET: /Teacher_Profile/

        public ActionResult Index()
        {
            var teacher_profile = db.Teacher_Profile.Include(t => t.School_Profile);
            return View(teacher_profile.ToList());
        }

        //
        // GET: /Teacher_Profile/Details/5

        public ActionResult Details(int id = 0)
        {
            Teacher_Profile teacher_profile = db.Teacher_Profile.Find(id);
            if (teacher_profile == null)
            {
                return HttpNotFound();
            }
            return View(teacher_profile);
        }

        //
        // GET: /Teacher_Profile/Create

        public ActionResult Create()
        {
            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username");
            return View();
        }

        //
        // POST: /Teacher_Profile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher_Profile teacher_profile)
        {
            if (ModelState.IsValid)
            {
                db.Teacher_Profile.Add(teacher_profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username", teacher_profile.School_ID);
            return View(teacher_profile);
        }

        //
        // GET: /Teacher_Profile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Teacher_Profile teacher_profile = db.Teacher_Profile.Find(id);
            if (teacher_profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username", teacher_profile.School_ID);
            return View(teacher_profile);
        }

        //
        // POST: /Teacher_Profile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher_Profile teacher_profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher_profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username", teacher_profile.School_ID);
            return View(teacher_profile);
        }

        //
        // GET: /Teacher_Profile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Teacher_Profile teacher_profile = db.Teacher_Profile.Find(id);
            if (teacher_profile == null)
            {
                return HttpNotFound();
            }
            return View(teacher_profile);
        }

        //
        // POST: /Teacher_Profile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher_Profile teacher_profile = db.Teacher_Profile.Find(id);
            db.Teacher_Profile.Remove(teacher_profile);
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