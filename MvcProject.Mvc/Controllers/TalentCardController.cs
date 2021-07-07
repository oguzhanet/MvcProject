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

    }
}