using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        List<Message> GetAllInbox(string parameter);
        List<Message> GetAllSendbox(string parameter);
        List<Message> GetAllUnRead(string parameter);
        List<Message> GetAllDraft(string parameter);
        List<Message> GetAllRead(string parameter);
        List<Message> IsDraft();
        Message GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
        void SaveDraftAdd(Message message);
    }
}
