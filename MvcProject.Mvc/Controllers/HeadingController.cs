using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        //HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //WriterManager writerManager = new WriterManager(new EfWriterDal());
        private IHeadingService _headingService;
        private ICategoryService _categoryService;
        private IWriterService _writerService;
        public HeadingController(IHeadingService headingService, ICategoryService categoryService, IWriterService writerService)
        {
            _headingService = headingService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        
        public ActionResult Index()
        {
            var headingValues = _headingService.GetAll();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from category in _categoryService.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryId.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from writer in _writerService.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = writer.WriterName + " " + writer.WriterSurName,
                                                    Value = writer.WriterId.ToString()
                                                }).ToList();
            ViewBag.category = valueCategory;
            ViewBag.writer = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingService.Add(heading);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}