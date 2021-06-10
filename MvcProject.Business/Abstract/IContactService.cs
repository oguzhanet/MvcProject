using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
