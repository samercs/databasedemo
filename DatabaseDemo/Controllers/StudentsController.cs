using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseDemo.Models;

namespace DatabaseDemo.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            var depts = db.Departments.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            ViewBag.DeptList = depts.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.City += "- Jordan";
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            var student = new Student();
            UpdateModel(student);
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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

        public ActionResult RegisterCourse(int id)
        {
            var courses = db.Courses.ToList();
            ViewBag.Courses = new SelectList(courses, "CourseId", "Name");

            var model = new FKStuCourse();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult RegisterCourse(int id, FKStuCourse course)
        {
            var fkCourse = new FKStuCourse
            {
                StudentId = id,
                CourseId = course.CourseId
            };
            var student = db.Students.Find(id);
            student.FkStuCourses.Add(fkCourse);
            db.SaveChanges();
            return RedirectToAction("Details", new { id });
        }

        public ActionResult DeleteRegister(int studentId, int courseId)
        {
            var fkCourse = db.FkStuCourses.FirstOrDefault(i => i.CourseId == courseId && i.StudentId == studentId);
            db.FkStuCourses.Remove(fkCourse);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = studentId });
        }
    }
}
