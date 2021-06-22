using FluentValidation;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.ValidationRules.FluentValidation
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetails1).NotEmpty().WithMessage("Hakkında Detayı Boş Olmaz!");
            RuleFor(x => x.AboutDetails2).NotEmpty().WithMessage("Hakkında Detayı Boş Olmaz!");
        }
    }
}
