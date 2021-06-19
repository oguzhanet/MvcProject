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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        //private IContactService _contactService;
        //private IMessageService _messageService;

        //public ContactController(IContactService contactService, IMessageService messageService)
        //{
        //    _contactService = contactService;
        //    _messageService = messageService;
        //}

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

        public PartialViewResult ContactPartial()
        {
            var contacts = contactManager.GetAll().Count();
            ViewBag.contact = contacts;

            var result = messageManager.GetAllSendbox().Count();
            ViewBag.result = result;

            var result2 = messageManager.GetAllInbox().Count();
            ViewBag.result2 = result2;

            var draft = messageManager.GetAll().Where(x => x.IsDraft == true).Count();
            ViewBag.draft = draft;


            var readMessage = messageManager.GetAll().Where(x => x.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unReadMessage = messageManager.GetAllUnRead().Count();
            ViewBag.unReadMessage = unReadMessage;

            return PartialView();
        }
    }
}