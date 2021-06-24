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
        Context context=new Context();
        public ActionResult Index()
        {
            var result = context.Categories.Count().ToString();
            ViewBag.result = result;

            var result2 = context.Headings.Count(h => h.CategoryId == 13).ToString();
            ViewBag.result2 = result2;

            var result3 = context.Writers.Where(w => w.WriterName.Contains("a") || w.WriterName.Contains("A")).Count();
            ViewBag.result3 = result3;

            var result4 = context.Categories.Where(u => u.CategoryId == context.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.result4 = result4;

            var result5 = context.Categories.Where(c => c.CategoryStatus == true).Count() -
                          context.Categories.Where(c => c.CategoryStatus == false).Count();
            ViewBag.result5 = result5;

            var result6 = context.Abouts.Count().ToString();
            ViewBag.result6 = result6;

            var result7 = context.Admins.Count().ToString();
            ViewBag.result7 = result7;

            var result8 = context.Writers.Count().ToString();
            ViewBag.result8 = result8;

            return View();
        }
    }
}