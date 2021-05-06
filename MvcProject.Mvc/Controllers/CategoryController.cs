using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete;

namespace MvcProject.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.GetAll();
            return View(categoryValues);
        }
    }
}