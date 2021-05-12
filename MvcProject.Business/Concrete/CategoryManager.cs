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

        public List<Category> StatusIsTrue()
        {
            return _categoryDal.GetAll(c => c.CategoryStatus == true);
        }

        public List<Category> StatusIsFalse()
        {
            return _categoryDal.GetAll(c => c.CategoryStatus == false);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(c => c.CategoryId == id);
        }

        public Category GetByName(string name)
        {
            return _categoryDal.Get(c => c.CategoryName == name);
        }

        //[FluentValidationAspect(typeof(CategoryValidator))]
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }
    }
}
