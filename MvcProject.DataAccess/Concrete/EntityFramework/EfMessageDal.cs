using DevFramework.Core.DataAccess.EntityFramework;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal: EfEntityRepositoryBase<Message, Context>, IMessageDal
    {
    }
}
