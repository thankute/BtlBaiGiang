using BtlBaiGiang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BtlBaiGiang.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        BaiGiangDBEntities db = new BaiGiangDBEntities();
        public ActionResult Index()
        {
            if (Session["UserAdmin"] == null)
            {
                return RedirectToAction("Login", "LoginAdmin");
            }
            else
            {
                List<User> users = db.Users.ToList();

                return View(users);
            }
        }

        [HttpGet]
        public JsonResult GetUserById(int id)
        {
            var user = db.Users.Find(id);
            if (user == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                User newUser = new User();
                newUser.Username = user.Username;
                newUser.PasswordHash = user.PasswordHash;
                newUser.Email = user.Email;
                newUser.Gender = user.Gender;
                newUser.Status = user.Status;
                newUser.Role = user.Role;
                newUser.CreatedAt = DateTime.Now;

                db.Users.Add(newUser);
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public JsonResult Edit(User user)
        {
            try
            {
                var dbUser = db.Users.Find(user.UserID);
                if (dbUser == null)
                {
                    return Json(new { success = false, message = "User không tồn tại" });
                }

                dbUser.Username = user.Username;
                dbUser.PasswordHash = user.PasswordHash;
                dbUser.Email = user.Email;
                dbUser.Gender = user.Gender;
                dbUser.Status = user.Status;
                dbUser.Role = user.Role;
                dbUser.UpdatedAt = DateTime.Now;

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
            User sachDB = db.Users.Where(row => row.UserID == id).FirstOrDefault();
            db.Users.Remove(sachDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}