using FluentValidation;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş olamaz!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı Adı en az 3 karakter olmalıdır!");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi boş olamaz!");
            RuleFor(x => x.UserMail).EmailAddress();
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı boş olamaz!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu Adı en az 3 karakter olmalıdır!");
        }
    }
}
