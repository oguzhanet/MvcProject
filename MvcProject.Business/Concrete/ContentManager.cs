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
    public class ContentManager : IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Content> GetAllByWriter(int id)
        {
            return _contentDal.GetAll(x => x.WriterId == id);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Content> GetAllByHeadingId(int id)
        {
            return _contentDal.GetAllById(x => x.HeadingId == id);
        }

        public Content GetById(int id)
        {
            return _contentDal.GetById(x => x.ContentId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Content content)
        {
            _contentDal.Update(content);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll(string parameter)
        {
            if (parameter == null)
            {
                return _contentDal.GetAll();
            }
            return _contentDal.GetAll(x => x.ContentValue.Contains(parameter));
        }
    }
}
