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

namespace MvcProject.Mvc.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        //ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        private IContentService _contentService;

        public WriterPanelContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ActionResult MyContent(string parameter)
        {
            
            parameter = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterId).FirstOrDefault();
            
            var contentValues = _contentService.GetAllByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(z => z.WriterId).FirstOrDefault();
            content.ContentDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;
            _contentService.Add(content);
            return RedirectToAction("MyContent");
        }
    }
}