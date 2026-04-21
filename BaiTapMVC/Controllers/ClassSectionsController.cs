using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapMVC.DAL;
using BaiTapMVC.Models;

namespace BaiTapMVC.Controllers
{
    public class ClassSectionsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: ClassSections
        public ActionResult Index()
        {
            var classSections = db.ClassSections.Include(c => c.Course).Include(c => c.Teacher);
            return View(classSections.ToList());
        }

        // GET: ClassSections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSection classSection = db.ClassSections.Find(id);
            if (classSection == null)
            {
                return HttpNotFound();
            }
            return View(classSection);
        }

        // GET: ClassSections/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "FullName");
            return View();
        }

        // POST: ClassSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassSectionId,Semester,CourseId,TeacherId")] ClassSection classSection)
        {
            if (ModelState.IsValid)
            {
                db.ClassSections.Add(classSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", classSection.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "FullName", classSection.TeacherId);
            return View(classSection);
        }

        // GET: ClassSections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSection classSection = db.ClassSections.Find(id);
            if (classSection == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", classSection.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "FullName", classSection.TeacherId);
            return View(classSection);
        }

        // POST: ClassSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassSectionId,Semester,CourseId,TeacherId")] ClassSection classSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", classSection.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "FullName", classSection.TeacherId);
            return View(classSection);
        }

        // GET: ClassSections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSection classSection = db.ClassSections.Find(id);
            if (classSection == null)
            {
                return HttpNotFound();
            }
            return View(classSection);
        }

        // POST: ClassSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassSection classSection = db.ClassSections.Find(id);
            db.ClassSections.Remove(classSection);
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
