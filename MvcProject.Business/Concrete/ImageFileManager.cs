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
    public class ImageFileManager : IImageFileService
    {
        private IImageFileDal _ImageFileDal;

        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ImageFileDal = ımageFileDal;
        }  

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<ImageFile> GetAll()
        {
            return _ImageFileDal.GetAll();
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(ImageFile ımageFile)
        {
            _ImageFileDal.Add(ımageFile);
        }
    }
}
