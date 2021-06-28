using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public Writer GetWriter(string mail, string password)
        {
            return _writerDal.Get(x => x.WriterMail == mail && x.WriterPassword == password);
        }

        public void UpdateWriterPanel(Writer writer)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = writer.WriterPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            if (writer.WriterPassword == null)
            {
                writer.WriterPassword = result;
            }

            writer.WriterStatus = true;
            writer.WriterRole = "C";
            _writerDal.Update(writer);
        }

        public void UpdatePasswordWriterPanel(Writer writer)
        {
            if (writer.WriterPassword != null)
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                string password = writer.WriterPassword;
                string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
                writer.WriterPassword = result;
            }
            var result1 = GetById(writer.WriterId);

            writer.WriterName = result1.WriterName;
            writer.WriterSurName = result1.WriterSurName;
            writer.WriterImage = result1.WriterImage;
            writer.WriterMail = result1.WriterMail;
            writer.WriterAbout = result1.WriterAbout;
            writer.WriterTitle = result1.WriterTitle;
            writer.WriterStatus = true;
            writer.WriterRole = "C";
            _writerDal.Update(writer);
        }

        private void CheckIfWriterExists(Writer writer)
        {
            if (_writerDal.Get(x => x.WriterMail == writer.WriterMail) != null)
            {
                throw new Exception("Bu kullanıcı daha önce kayıt olmuştur.");
            }
        }
    }
}
