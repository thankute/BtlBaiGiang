using BtlBaiGiang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BtlBaiGiang.Controllers
{
    public class LectureController : Controller
    {
        // GET: Lecture
        BaiGiangDBEntities db = new BaiGiangDBEntities();
        public ActionResult Index()
        {
            if (Session["UserAdmin"] == null)
            {
                return RedirectToAction("Login", "LoginAdmin");
            }
            else
            {
                List<Lecture> lectures = db.Lectures.ToList();
                ViewBag.Courses = db.Courses.ToList();

                return View(lectures);
            }
        }

        [HttpGet]
        public JsonResult GetLectureById(int id)
        {
            var lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                LectureID = lecture.LectureID,
                CourseID = lecture.CourseID,
                LectureName = lecture.LectureName,
                Title = lecture.Title,
                Content = lecture.Content,
                CreatedAt = lecture.CreatedAt?.ToString("yyyy-MM-dd HH:mm:ss"), // Định dạng theo ý muốn
                UpdatedAt = lecture.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss")
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(int courseId, string lectureName, string title, string content)
        {
            try
            {
                Lecture lecture= new Lecture();
                lecture.CourseID = courseId;
                lecture.LectureName = lectureName;
                lecture.Image = "programming_intro.jpg";
                lecture.Title = title;
                lecture.Content = content;
                lecture.CreatedAt = DateTime.Now;
                lecture.UpdatedAt = DateTime.Now;

                db.Lectures.Add(lecture);
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public JsonResult Edit(int id, int courseId, string lectureName, string title, string content)
        {
            try
            {
                var lecture = db.Lectures.Find(id);
                if (lecture == null)
                {
                    return Json(new { success = false, message = "Bài giảng không tồn tại" });
                }

                lecture.CourseID = courseId;
                lecture.LectureName = lectureName;
                lecture.Image = "programming_intro.jpg";
                lecture.Title = title;
                lecture.Content= content;
                lecture.UpdatedAt = DateTime.Now;

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
            Lecture sachDB = db.Lectures.Where(row => row.LectureID == id).FirstOrDefault();
            db.Lectures.Remove(sachDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}