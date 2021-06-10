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
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin GetById(int id)
        {
            return _adminDal.GetById(x => x.AdminId == id);
        }

        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }
    }
}
