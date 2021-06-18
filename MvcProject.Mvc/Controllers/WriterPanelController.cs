﻿using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        //HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        private IHeadingService _headingService;
        private ICategoryService _categoryService;

        public WriterPanelController(IHeadingService headingService, ICategoryService categoryService)
        {
            _headingService = headingService;
            _categoryService = categoryService;
        }

    
        Context context = new Context();

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string parameter)
        {
            parameter = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterId).FirstOrDefault();

            var values = _headingService.GetAllByWriter(writerIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from category in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;

            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string result = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == result).Select(z => z.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.HeadingStatus = true;
            heading.WriterId = writerIdInfo;
            _headingService.Add(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valueCategory = (from category in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.category = valueCategory;

            var headingValues = _headingService.GetById(id);
            return View(headingValues);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            _headingService.Update(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = _headingService.GetById(id);

            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }

            else
            {
                headingValue.HeadingStatus = true;
            }

            _headingService.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }
    }
}