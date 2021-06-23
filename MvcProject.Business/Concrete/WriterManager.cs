using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using MvcProject.Business.Abstract;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entities.Concrete;

namespace MvcProject.Business.Concrete
{
    public class WriterManager:IWriterService
    {
        private IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(w => w.WriterId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Writer writer)
        {
            CheckIfWriterExists(writer);
            _writerDal.Add(writer);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        private void CheckIfWriterExists(Writer writer)
        {
            if (_writerDal.Get(x=>x.WriterMail==writer.WriterMail) != null)
            {
                throw new Exception("Bu kullanıcı daha Önce kayıt olmuştur.");
            }
        }

        public Writer GetWriter(string mail, string password)
        {
            return _writerDal.Get(x => x.WriterMail == mail && x.WriterPassword == password);
        }
    }
}
