using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete;

namespace MvcProject.Mvc.Controllers
{
    public class StatisticsController : Controller
    {
        private Context _context;

        public StatisticsController(Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var result = _context.Categories.Count().ToString();
            ViewBag.result = result;

            var result2 = _context.Headings.Count(h => h.CategoryId == 13).ToString();
            ViewBag.result2 = result2;

            var result3 = _context.Writers.Where(w => w.WriterName.Contains("a") || w.WriterName.Contains("A")).Count();
            ViewBag.result3 = result3;

            var result4 = _context.Categories.Where(u => u.CategoryId == _context.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.result4 = result4;

            var result5 = _context.Categories.Where(c => c.CategoryStatus == true).Count() -
                          _context.Categories.Where(c => c.CategoryStatus == false).Count();
            ViewBag.result5 = result5;

            var result6 = _context.Abouts.Count().ToString();
            ViewBag.result6 = result6;

            var result7 = _context.Admins.Count().ToString();
            ViewBag.result7 = result7;

            var result8 = _context.Writers.Count().ToString();
            ViewBag.result8 = result8;

            return View();
        }
    }
}