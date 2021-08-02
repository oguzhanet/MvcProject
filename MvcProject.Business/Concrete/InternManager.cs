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
    public class InternManager : IInternService
    {
        IInternDal _ınternDal;

        public InternManager(IInternDal ınternDal)
        {
            _ınternDal = ınternDal;
        }

        public void Add(Intern ıntern)
        {
            _ınternDal.Add(ıntern);
        }

        public List<Intern> GetAll()
        {
            return _ınternDal.GetAll();
        }
    }
}
