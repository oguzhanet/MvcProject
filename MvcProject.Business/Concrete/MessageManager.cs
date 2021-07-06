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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;
      
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAllInbox(string parameter)
        {
            return _messageDal.GetAll(x => x.ReceiverMail == parameter);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAllSendbox(string parameter)
        {
            return _messageDal.GetAll(x => x.SenderMail == parameter).Where(x=>x.IsDraft==false).ToList();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAllUnRead(string parameter)
        {
            return _messageDal.GetAll(x => x.ReceiverMail == parameter).Where(x => x.IsRead == false).ToList();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAllDraft(string parameter)
        {
            return _messageDal.GetAll(x => x.SenderMail == parameter);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Message> GetAllRead(string parameter)
        {
            return _messageDal.GetAll(x => x.ReceiverMail == parameter);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Message message)
        {
            _messageDal.Update(message);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> IsDraft()
        {
            return _messageDal.GetAllById(x => x.IsDraft == true);
        }
     
        public void SaveDraftAdd(Message message)
        {
            _messageDal.Add(message);
        }
    }
}
