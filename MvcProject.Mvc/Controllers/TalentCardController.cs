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
        public ActionResult Index()
        {
            Context context = new Context();
            var cardValues = talentCardManager.GetAll();

            var result = context.TalentCards.Sum(x => x.SkillPoint) * 250 / 100;
            ViewBag.result = result;
            var result2 = context.TalentCards.Sum(x => x.SkillPoint2) * 250 / 100;
            ViewBag.result2 = result2;
            var result3 = context.TalentCards.Sum(x => x.SkillPoint3) * 250 / 100;
            ViewBag.result3 = result3;
            var result4 = context.TalentCards.Sum(x => x.SkillPoint4) * 250 / 100;
            ViewBag.result4 = result4;
            var result5 = context.TalentCards.Sum(x => x.SkillPoint5) * 250 / 100;
            ViewBag.result5 = result5;
            var result6 = context.TalentCards.Sum(x => x.SkillPoint6) * 250 / 100;
            ViewBag.result6 = result6;
            var result7 = context.TalentCards.Sum(x => x.SkillPoint7) * 250 / 100;
            ViewBag.result7 = result7;
            var result8 = context.TalentCards.Sum(x => x.SkillPoint8) * 250 / 100;
            ViewBag.result8 = result8;
            var result9 = context.TalentCards.Sum(x => x.SkillPoint9) * 250 / 100;
            ViewBag.result9 = result9;
            var result10 = context.TalentCards.Sum(x => x.SkillPoint10) * 250 / 100;
            ViewBag.result10 = result10;

            return View(cardValues);
        }

    }
}