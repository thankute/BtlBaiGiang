using BtlBaiGiang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BtlBaiGiang.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: LoginAdmin
        BaiGiangDBEntities db = new BaiGiangDBEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(string Email, string Password)
        {
            var userCheck = db.Users.SingleOrDefault(u => u.Email.Equals(Email) && u.PasswordHash.Equals(Password));
            if (userCheck != null)
            {
                Session["User"] = userCheck.Username;
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("User");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}