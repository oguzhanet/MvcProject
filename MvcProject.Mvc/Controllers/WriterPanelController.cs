using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using MvcProject.Business.ValidationRules.FluentValidation;

namespace MvcProject.Mvc.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        //private IHeadingService _headingService;
        //private ICategoryService _categoryService;

        //public WriterPanelController(IHeadingService headingService, ICategoryService categoryService)
        //{
        //    _headingService = headingService;
        //    _categoryService = categoryService;
        //}

        Context context = new Context();
        WriterValidator writerValidator = new WriterValidator();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string parameter = (string)Session["WriterMail"];
            //var writerValue = context.Writers.FirstOrDefault(x => x.WriterMail == parameter);

            id = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterId).FirstOrDefault();
            var writerValue = writerManager.GetById(id);

            var writerName = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterName + " " + z.WriterSurName).FirstOrDefault();
            ViewBag.writerName = writerName;

            var writerImage = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterImage).FirstOrDefault();
            ViewBag.writerImage = writerImage;

            var writerMail = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterMail).FirstOrDefault();
            ViewBag.writerMail = writerMail;

            var writerAbout = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterAbout).FirstOrDefault();
            ViewBag.writerAbout = writerAbout;

            var writerTitle = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterTitle).FirstOrDefault();
            ViewBag.writerTitle = writerTitle;

            var writerId = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterId).FirstOrDefault();
            var writerTitles = context.Contents.Where(x => x.WriterId == writerId).Count();
            ViewBag.writerTitles = writerTitles;

            var writerMessage = context.Messages.Where(x => x.ReceiverMail == parameter).Count();
            ViewBag.writerMessage = writerMessage;

            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterRole = "C";
                writerManager.Update(writer);
                return RedirectToAction("WriterProfile");
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

        public ActionResult MyHeading(string parameter)
        {
            parameter = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterId).FirstOrDefault();

            var values = headingManager.GetAllByWriter(writerIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from category in categoryManager.GetAll()
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
            headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valueCategory = (from category in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.category = valueCategory;

            var headingValues = headingManager.GetById(id);
            return View(headingValues);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);

            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
            }

            else
            {
                headingValue.HeadingStatus = true;
            }

            headingManager.Delete(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int page=1)
        {
            var headings = headingManager.GetAll().ToPagedList(page,5);
            return View(headings);
        }
    }
}