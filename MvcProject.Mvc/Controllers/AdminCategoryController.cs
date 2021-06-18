using System;
using System.Collections.Generic;
using System.Linq;
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
        //CategoryManager categoryManager=new CategoryManager(new EfCategoryDal());
        private ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categoryValues = _categoryService.GetAll();
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
                _categoryService.Add(category);
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
            var categoryValue = _categoryService.GetById(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = _categoryService.GetById(id);
            _categoryService.Delete(categoryValue);
            return RedirectToAction("Index");
        }
    }
}