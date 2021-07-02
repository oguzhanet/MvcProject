using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class ChartController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Context context = new Context();
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            var result = context.Categories.Count();
            ViewBag.r = result;
            return Json(categoryManager.GetAll(),JsonRequestBehavior.AllowGet);
        }
    }
}