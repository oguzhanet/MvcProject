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

namespace MvcProject.Mvc.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        
        private IAboutService _aboutSercice;

        public AboutController(IAboutService aboutSercice)
        {
            _aboutSercice = aboutSercice;
        }

        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetAll();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.Add(about);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var aboutValues = aboutManager.GetById(id);
            return View(aboutValues);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            aboutManager.Update(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult StatusActiveAndPassive(int id)
        {
            var aboutValue = aboutManager.GetById(id);

            if (aboutValue.AboutStatus == true)
            {
                aboutValue.AboutStatus = false;
            }
            else
            {
                aboutValue.AboutStatus = true;
            }
            aboutManager.Update(aboutValue);
            return RedirectToAction("Index");
        }
    }
}