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
        ImageFileManager ımageFileManager = new ImageFileManager(new EfImageFileDal());
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        Context context = new Context();
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Image()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(categoryManager.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AboutChart()
        {
            return Json(aboutManager.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult HeadingChart()
        {
            return Json(ımageFileManager.GetAll(), JsonRequestBehavior.AllowGet);
        }
    }
}