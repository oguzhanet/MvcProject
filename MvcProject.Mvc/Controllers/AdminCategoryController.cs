using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.Business.ValidationRules.FluentValidation;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;

namespace MvcProject.Mvc.Controllers
{
    //[Authorize(Roles ="A,B")]
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());
        //private ICategoryService _categoryService;

        //public AdminCategoryController(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}

        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetAll();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validator=new CategoryValidator();
            ValidationResult result = validator.Validate(category);
            if (result.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.Add(category);
                Thread.Sleep(1500);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryValue = categoryManager.GetById(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            category.CategoryStatus = true;
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = categoryManager.GetById(id);
            categoryManager.Delete(categoryValue);
            return RedirectToAction("Index");
        }
    }
}