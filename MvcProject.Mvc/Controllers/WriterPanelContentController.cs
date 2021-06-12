using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());


        public ActionResult MyContent()
        {
            var contentValues = contentManager.GetAllByWriter();
            return View(contentValues);
        }
    }
}