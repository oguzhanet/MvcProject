using FluentValidation;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.ValidationRules.FluentValidation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(c => c.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş olamaz!");
           // RuleFor(c => c.ReceiverMail).EmailAddress().WithMessage("Alıcı adresi mail adresi türünde olmalıdır!");
            RuleFor(c => c.MessageContent).NotEmpty().WithMessage("Mesaj en az 3 karakter olmalıdır!");
           // RuleFor(c => c.MessageContent).MinimumLength(3).WithMessage("Mesaj boş olamaz!");
            RuleFor(c => c.Subject).NotEmpty().WithMessage("Konu boş olamaz!");
          //  RuleFor(c => c.Subject).MinimumLength(3).WithMessage("Konu en az 3 karakter olmalıdır!");
           // RuleFor(c => c.SenderMail).NotEmpty().WithMessage("Gönderici adresi boş olamaz!");
            //RuleFor(c => c.SenderMail).EmailAddress().WithMessage("Gönderici adresi mail adresi türünde olmalıdır!");
        }
    }
}
