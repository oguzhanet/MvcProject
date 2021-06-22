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
    public class ContactManager:IContactService
    {
        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.ContactId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Contact contact)
        {
            _contactDal.Update(contact);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Contact contact)
        {
            _contactDal.Delete(contact);
        }
    }
}
