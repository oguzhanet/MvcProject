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
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public PartialViewResult Index()
        {
            var contentList = contentManager.GetAll();
            return PartialView(contentList);
        }

        public ActionResult Headings()
        {
            var headingList = headingManager.GetAll();
            return View(headingList);
        }
    }
}