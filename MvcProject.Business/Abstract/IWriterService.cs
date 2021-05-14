using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcProject.Entities.Concrete;

namespace MvcProject.Business.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        Writer GetById(int id);
        void Add(Writer writer);
        void Update(Writer writer);
        void Delete(Writer writer);

    }
}
