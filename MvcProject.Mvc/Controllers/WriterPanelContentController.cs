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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        //ContentManager contentManager = new ContentManager(new EfContentDal());
        private IContentService _contentService;

        public WriterPanelContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ActionResult MyContent(string parameter)
        {
            Context context = new Context();
            parameter = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterId).FirstOrDefault();
            
            var contentValues = _contentService.GetAllByWriter(writerIdInfo);
            return View(contentValues);
        }
    }
}