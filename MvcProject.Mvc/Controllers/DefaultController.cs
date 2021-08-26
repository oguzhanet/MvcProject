using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FluentValidation.Results;
using MvcProject.Business.ValidationRules.FluentValidation;
using MvcProject.DataAccess.Concrete;

namespace MvcProject.Mvc.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        private IHeadingService _headingService;
        private IContentService _contentService;
        private IInternService _ınternService;
        private InternValidator _validator;
        private Context _context;
        public DefaultController(IHeadingService headingService, IContentService contentService, IInternService ınternService, InternValidator validator, Context context)
        {
            _headingService = headingService;
            _contentService = contentService;
            _ınternService = ınternService;
            _validator = validator;
            _context = context;
        }

        public PartialViewResult Index(int id=1)
        {
            var contentList = _contentService.GetAllByHeadingId(id);
            return PartialView(contentList);
        }

        public ActionResult Headings()
        {
            var headingList = _headingService.GetAll();
            //var t = _context.Headings.Select(x => x.HeadingId).FirstOrDefault();
            //var result = _context.Contents.Where(x => x.HeadingId == t).Select(z=>z.ContentValue).Count();
            //ViewBag.result = result;
            return View(headingList);
        }

        [HttpGet]
        public ActionResult Intern(int number=1)
        {
            var result = _ınternService.GetAll().OrderByDescending(x=>x.Id).ToPagedList(number,1);
            return View(result);
        }

        [HttpPost]
        public ActionResult Intern(Intern ıntern)
        {
            ValidationResult result = _validator.Validate(ıntern);
            if (result.IsValid)
            {
                _ınternService.Add(ıntern);
                return RedirectToAction("Intern");
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
    }
}