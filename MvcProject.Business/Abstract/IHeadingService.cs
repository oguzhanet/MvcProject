using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcProject.Entities.Concrete;

namespace MvcProject.Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        Heading GetById(int id);
        void Add(Heading heading);
        void Update(Heading heading);
        void Delete(Heading heading);
    }
}
