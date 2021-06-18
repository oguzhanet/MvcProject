using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        //AboutManager aboutManager = new AboutManager(new EfAboutDal());
        private IAboutService _aboutSercice;

        public AboutController(IAboutService aboutSercice)
        {
            _aboutSercice = aboutSercice;
        }

        public ActionResult Index()
        {
            var aboutValues = _aboutSercice.GetAll();
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
            _aboutSercice.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult StatusActiveAndPassive(int id)
        {
            var aboutValue = _aboutSercice.GetById(id);

            if (aboutValue.AboutStatus == true)
            {
                aboutValue.AboutStatus = false;
            }
            else
            {
                aboutValue.AboutStatus = true;
            }
            _aboutSercice.Update(aboutValue);
            return RedirectToAction("Index");
        }
    }
}