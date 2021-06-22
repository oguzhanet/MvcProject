using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
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

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Category> StatusIsTrue()
        {
            return _categoryDal.GetAll(c => c.CategoryStatus == true);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
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
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }
    }
}
