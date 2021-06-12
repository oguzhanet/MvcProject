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
        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message> GetAllInbox()
        {
            return _messageDal.GetAll(x => x.ReceiverMail == "kadir@gmail.com");
        }

        public List<Message> GetAllSendbox()
        {
            return _messageDal.GetAll(x => x.SenderMail == "kadir@gmail.com").Where(x=>x.IsDraft==false).ToList();
        }

        public List<Message> GetAllUnRead()
        {
            return _messageDal.GetAll(x => x.ReceiverMail == "kadir@gmail.com").Where(x => x.IsRead == false).ToList();
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }

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
