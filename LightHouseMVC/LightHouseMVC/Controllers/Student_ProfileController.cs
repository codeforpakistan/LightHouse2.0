using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LightHouseMVC.Controllers
{
    public class Student_ProfileController : Controller
    {
        private LightHouseDatabaseEntities db = new LightHouseDatabaseEntities();

        //
        // GET: /Student_Profile/

        public ActionResult Index()
        {
            var student_profile = db.Student_Profile.Include(s => s.School_Profile);
            return View(student_profile.ToList());
        }

        //
        // GET: /Student_Profile/Details/5

        public ActionResult Details(int id = 0)
        {
            Student_Profile student_profile = db.Student_Profile.Find(id);
            if (student_profile == null)
            {
                return HttpNotFound();
            }
            return View(student_profile);
        }

        //
        // GET: /Student_Profile/Create

        public ActionResult Create()
        {
            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username");
            return View();
        }

        //
        // POST: /Student_Profile/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student_Profile student_profile)
        {
            if (ModelState.IsValid)
            {
                db.Student_Profile.Add(student_profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username", student_profile.School_ID);
            return View(student_profile);
        }

        //
        // GET: /Student_Profile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student_Profile student_profile = db.Student_Profile.Find(id);
            if (student_profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username", student_profile.School_ID);
            return View(student_profile);
        }

        //
        // POST: /Student_Profile/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student_Profile student_profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.School_ID = new SelectList(db.School_Profile, "School_ID", "SchoolAdmin_username", student_profile.School_ID);
            return View(student_profile);
        }

        //
        // GET: /Student_Profile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student_Profile student_profile = db.Student_Profile.Find(id);
            if (student_profile == null)
            {
                return HttpNotFound();
            }
            return View(student_profile);
        }

        //
        // POST: /Student_Profile/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Profile student_profile = db.Student_Profile.Find(id);
            db.Student_Profile.Remove(student_profile);
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