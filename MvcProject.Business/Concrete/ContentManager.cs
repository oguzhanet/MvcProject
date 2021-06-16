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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Add(Content content)
        {
            throw new NotImplementedException();
        }

        public void Update(Content content)
        {
            throw new NotImplementedException();
        }

        public void Delete(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
