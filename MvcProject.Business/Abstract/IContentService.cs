using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        List<Content> GetAllByWriter();
        List<Content> GetAllByHeadingId(int id);
        Content GetById(int id);
        void Add(Content content);
        void Update(Content content);
        void Delete(Content content);
    }
}
