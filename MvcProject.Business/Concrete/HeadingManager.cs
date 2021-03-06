using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MvcProject.Business.Abstract;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entities.Concrete;

namespace MvcProject.Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }

        public List<Heading> GetAllByWriter(int id)
        {
            return _headingDal.GetAll(x => x.WriterId == id);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Heading heading)
        {
            _headingDal.Add(heading);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
