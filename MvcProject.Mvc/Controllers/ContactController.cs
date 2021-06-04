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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        public ActionResult Index()
        {
            var contactValues = contactManager.GetAll();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult ContactPartial(Message message)
        {
            var contacts = contactManager.GetAll().Count();
            ViewBag.contact = contacts;

            var result = messageManager.GetAllSendbox();
            ViewBag.result = result.Count();

            var result2 = messageManager.GetAllInbox().Count();
            ViewBag.result2 = result2;

            return PartialView();
        }
    }
}