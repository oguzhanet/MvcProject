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

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetAllByWriter(int id)
        {
            return _contentDal.GetAll(x => x.WriterId == id);
        }

        public List<Content> GetAllByHeadingId(int id)
        {
            return _contentDal.GetAllById(x => x.HeadingId == id);
        }

        public Content GetById(int id)
        {
            return _contentDal.GetById(x => x.ContentId == id);
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }
    }
}
