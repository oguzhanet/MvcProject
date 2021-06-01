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

        public List<Message> GetAllInbox()
        {
            return _messageDal.GetAll(x => x.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetAllSendbox()
        {
            return _messageDal.GetAll(x => x.SenderMail == "admin@gmail.com");
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Update(Message message)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
