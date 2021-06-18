using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        //HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        //ContentManager contentManager = new ContentManager(new EfContentDal());
        private IHeadingService _headingService;
        private IContentService _contentService;

        public DefaultController(IHeadingService headingService, IContentService contentService)
        {
            _headingService = headingService;
            _contentService = contentService;
        }

        public PartialViewResult Index()
        {
            var contentList = _contentService.GetAll();
            return PartialView(contentList);
        }

        public ActionResult Headings()
        {
            var headingList = _headingService.GetAll();
            return View(headingList);
        }
    }
}