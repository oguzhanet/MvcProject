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
    public class TalentCardController : Controller
    {
        // GET: TalentCard
        TalentCardManager talentCardManager = new TalentCardManager(new EfTalentCardDal());
        //private ITalentCardService _talentCardService;

        //public TalentCardController(ITalentCardService talentCardService)
        //{
        //    _talentCardService = talentCardService;
        //}

        public ActionResult Index()
        {
            var cardValues = talentCardManager.GetAll();
            return View(cardValues);
        }

        [HttpGet]
        public ActionResult AddCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCard(TalentCard talentCard)
        {
            talentCardManager.Add(talentCard);
            Thread.Sleep(1500);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCard(int id)
        {
            var cardValues = talentCardManager.GetById(id);
            return View(cardValues);
        }

        [HttpPost]
        public ActionResult UpdateCard(TalentCard talentCard)
        {
            talentCardManager.Update(talentCard);
            return RedirectToAction("Index");
        }
    }
}