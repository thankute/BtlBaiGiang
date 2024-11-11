using BtlBaiGiang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BtlBaiGiang.Controllers
{
    public class BaiGiangController : Controller
    {

        BaiGiangDBEntities db = new BaiGiangDBEntities();
        // GET: BaiGiang
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index(string query, int page = 1, int pageSize = 9)
        {
            var lecturesQuery = db.Lectures.ToList();

            if (!string.IsNullOrEmpty(query))
            {
                lecturesQuery = (List<Lecture>)lecturesQuery.Where(l => l.LectureName.Contains(query) || l.Title.Contains(query));
            }

            var lectures = lecturesQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = lecturesQuery.Count();

            return View(lectures);
        }

        public class RatingRequest
        {
            public int Id { get; set; }
            public int NewRating { get; set; }
            public string ReviewContent { get; set; }
            public string Timestamp { get; set; }
        }
    }
}