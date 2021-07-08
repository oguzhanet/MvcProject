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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult HomePage()
        {
            Context context = new Context();
            var result = context.Headings.Count().ToString();
            ViewBag.result = result;

            var result1 = context.Writers.Count().ToString();
            ViewBag.result1 = result1;

            var result3 = context.Messages.Count().ToString();
            ViewBag.result3 = result3;

            var result4 = context.Contents.Count().ToString();
            ViewBag.result4 = result4;

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ContactAdd(Contact contact)
        {
            ContactManager contactManager = new ContactManager(new EfContactDal());
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToString());
            contactManager.Add(contact);
            return RedirectToAction("HomePage");
        }
    }
}