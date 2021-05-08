using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MvcProject.Entities.Concrete;

namespace MvcProject.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz!");
            RuleFor(c => c.CategoryName).MinimumLength(2).WithMessage("Kategori adı en az iki karakter olamalıdır!");
            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş olamaz!"); 
        }
    }
}
