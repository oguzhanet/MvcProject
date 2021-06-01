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
        Message GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
    }
}
