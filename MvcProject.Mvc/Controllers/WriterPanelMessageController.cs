using FluentValidation.Results;
using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.Business.ValidationRules.FluentValidation;
using MvcProject.DataAccess.Concrete.EntityFramework;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Mvc.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        //MessageManager messageManager = new MessageManager(new EfMessageDal());
        private IMessageService _messageService;

        public WriterPanelMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            var messageList = _messageService.GetAllInbox();
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            var messageList = _messageService.GetAllSendbox();
            return View(messageList);
        }

        public PartialViewResult MessagePartial()
        {
            return PartialView();
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = _messageService.GetById(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = _messageService.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost] //Burası refaktor edilecek şuanlık bu şekide..
        public ActionResult NewMessage(Message message, string parameter)
        {
            ValidationResult results = messageValidator.Validate(message);
            if (parameter == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = "kadir@gmail.com";
                    message.IsDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    _messageService.Add(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            else if (parameter == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = "kadir@gmail.com";
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    _messageService.Add(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            return View();
        }
    }
}