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
    public class WriterController : Controller
    {
        // GET: Writer
        private IWriterService _writerService;
        private WriterValidator _writerValidator;

        public WriterController(IWriterService writerService, WriterValidator writerValidator)
        {
            _writerService = writerService;
            _writerValidator = writerValidator;
        }

        public ActionResult Index()
        {
            var writerValues = _writerService.GetAll();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult results = _writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterRole = "C";
                _writerService.Add(writer);
                Thread.Sleep(1500);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = _writerService.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult results = _writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterRole = "C";
                _writerService.Update(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}