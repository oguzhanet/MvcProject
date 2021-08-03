using FluentValidation.Results;
using MvcProject.Business.Abstract;
using MvcProject.Business.Concrete;
using MvcProject.Business.ValidationRules.FluentValidation;
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
    public class MessageController : Controller
    {
        // GET: Message

        private IMessageService _messageService;
        private MessageValidator _messageValidator;

        public MessageController(IMessageService messageService, MessageValidator messageValidator)
        {
            _messageService = messageService;
            _messageValidator = messageValidator;
        }

        MessageManager messageManager = new MessageManager(new EfMessageDal());

        public ActionResult Inbox()
        {
            string parameter = (string)Session["AdminUserName"];
            var messageList = messageManager.GetAllInbox(parameter);
            return View(messageList);
        }

        public ActionResult Sendbox()
        {
            string parameter = (string)Session["AdminUserName"];
            var messageList = messageManager.GetAllSendbox(parameter);
            return View(messageList);
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
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
            ValidationResult results = _messageValidator.Validate(message);
            string adminValue = (string)Session["AdminUserName"];
            if (parameter == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = adminValue;
                    message.IsDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.Add(message);
                    Thread.Sleep(1500);
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

            else if (parameter=="draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = adminValue;
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.Add(message);
                    Thread.Sleep(1500);
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

        public ActionResult Draft()
        {
            string parameter = (string)Session["AdminUserName"];
            var result = messageManager.GetAllDraft(parameter).Where(x => x.IsDraft == true).ToList();
            return View(result);
        }

        public ActionResult IsRead(int id)
        {
            var result= messageManager.GetById(id);
            if (result.IsRead==false)
            {
                result.IsRead = true;
            }
            messageManager.Update(result);
            return RedirectToAction("ReadMessage");
        }

        public ActionResult ReadMessage()
        {
            string parameter = (string)Session["AdminUserName"];
            var readMessage = messageManager.GetAllRead(parameter).Where(x => x.IsRead == true).ToList();
            return View(readMessage);
        }

        public ActionResult UnReadMessage()
        {
            string parameter = (string)Session["AdminUserName"];
            var unReadMessage = messageManager.GetAllUnRead(parameter);
            return View(unReadMessage);
        }
    }
}