using MvcProject.Business.Abstract;
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
    public class ContentController : Controller
    {
        // GET: Content

        private IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string parameter)
        {
            var values = _contentService.GetAll(parameter);
            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = _contentService.GetAllByHeadingId(id);
            return View(contentValues);
        }
    }
}