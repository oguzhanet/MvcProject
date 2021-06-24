using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
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

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin GetById(int id)
        {
            return _adminDal.GetById(x => x.AdminId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Admin admin)
        {
            CheckIfAdminExists(admin);
            _adminDal.Add(admin);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin GetAdmin(string mail, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == mail && x.AdminPassword == password);
        }

        private void CheckIfAdminExists(Admin admin)
        {
            if (_adminDal.Get(x => x.AdminUserName == admin.AdminUserName) != null)
            {
                throw new Exception("Bu kullanıcı daha önce kayıt olmuştur.");
            }
        }
    }
}
