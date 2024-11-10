using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using BtlBaiGiang.Models;

namespace BtlBaiGiang.Controllers
{
    public class CourseController : Controller
    {

        BaiGiangDBEntities db = new BaiGiangDBEntities();

        // GET: Course
        public ActionResult Index()
        {
            if (Session["UserAdmin"] == null)
            {
                return RedirectToAction("Login", "LoginAdmin");
            }
            else
            {
                List<Cours> courses = db.Courses.ToList();
                return View(courses);
            }
        }

        [HttpGet]
        public JsonResult GetCourseById(int id)
        {
            var course = db.Courses.Find(id);
            if (course == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                CourseID = course.CourseID,
                CourseName = course.CourseName,
                Description = course.Description,
                CreatedAt = course.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"), // Định dạng theo ý muốn
                UpdatedAt = course.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss")
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(string courseName, string courseDescription)
        {
            try
            {
                Cours newCourse = new Cours();
                newCourse.CourseName = courseName;
                newCourse.Description = courseDescription;
                newCourse.CreatedAt = DateTime.Now;
                newCourse.UpdatedAt = DateTime.Now;

                db.Courses.Add(newCourse);
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public JsonResult Edit(int id, string name, string description)
        {
            try
            {
                var course = db.Courses.Find(id);
                if (course == null)
                {
                    return Json(new { success = false, message = "Khóa học không tồn tại" });
                }

                course.CourseName = name;
                course.Description = description;
                course.UpdatedAt = DateTime.Now;

                db.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Cours sachDB = db.Courses.Where(row => row.CourseID == id).FirstOrDefault();
            db.Courses.Remove(sachDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}