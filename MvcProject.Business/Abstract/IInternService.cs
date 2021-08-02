using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IInternService
    {
        List<Intern> GetAll();
        void Add(Intern ıntern);
    }
}
