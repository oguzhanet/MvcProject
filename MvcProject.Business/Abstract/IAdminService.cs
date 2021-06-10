using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();
        Admin GetById(int id);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
    }
}
