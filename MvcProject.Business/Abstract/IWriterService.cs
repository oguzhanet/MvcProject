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
        Writer GetWriter(string mail, string password);
        void Add(Writer writer);
        void Update(Writer writer);
        void UpdateWriterPanel(Writer writer);
        void UpdatePasswordWriterPanel(Writer writer);
        void Delete(Writer writer);
    }
}
