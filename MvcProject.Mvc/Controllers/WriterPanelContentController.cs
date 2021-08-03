using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
      
        private IContentService _contentService;
        private Context _context;

        public WriterPanelContentController(IContentService contentService, Context context)
        {
            _contentService = contentService;
            _context = context;
        }

        public ActionResult MyContent(string parameter)
        {
            
            parameter = (string)Session["WriterMail"];
            var writerIdInfo = _context.Writers.Where(x => x.WriterMail == parameter).Select(z => z.WriterId).FirstOrDefault();
            
            var contentValues = _contentService.GetAllByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.result = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = _context.Writers.Where(x => x.WriterMail == mail).Select(z => z.WriterId).FirstOrDefault();
            content.ContentDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;
            _contentService.Add(content);
            Thread.Sleep(1500);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}