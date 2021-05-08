using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using MvcProject.Business.Abstract;
using MvcProject.Business.ValidationRules.FluentValidation;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entities.Concrete;

namespace MvcProject.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        //[FluentValidationAspect(typeof(CategoryValidator))]
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }
    }
}
