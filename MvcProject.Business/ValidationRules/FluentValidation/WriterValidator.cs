using FluentValidation;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.ValidationRules.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş olamaz!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 karakter olmalıdır!");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş olamaz!");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Yazar soyadı en az 2 karakter olmalıdır!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanı boş olamaz!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında boş olamaz!");
            RuleFor(x => x.WriterAbout).MinimumLength(2).WithMessage("Yazar hakkında en az 2 karakter olmalıdır!");
            RuleFor(x => x.WriterAbout).Must(MustBeA).WithMessage("Hakkında kısmında mutlaka A harfı olmalıdır!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar mail boş olamaz!");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Yazar maili mail adresi türünde olmalıdır!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar şifre boş olamaz!");
            RuleFor(x => x.WriterPassword).MinimumLength(3).WithMessage("Yazar şifre en az 3 karakter olmalıdır!");
        }

        private bool MustBeA(string arg)
        {
            var result = arg.Contains("A") || arg.Contains("a");
            return result;
        }
    }
}
