using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MvcProject.Business.Abstract;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(About about)
        {
            _aboutDal.Add(about);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(About about)
        {
            _aboutDal.Update(about);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(About about)
        {
            _aboutDal.Delete(about);
        }
    }
}
