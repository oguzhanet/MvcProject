﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using MvcProject.Business.Concrete;
using MvcProject.Business.ValidationRules.FluentValidation;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;

namespace MvcProject.Mvc.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager writerManager=new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        public ActionResult Index()
        {
            var writerValues = writerManager.GetAll();
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
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Add(writer);
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
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.Update(writer);
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