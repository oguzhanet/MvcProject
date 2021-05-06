using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using MvcProject.Entities.Concrete;

namespace MvcProject.DataAccess.Abstract
{
    public interface IContentDal:IEntityRepository<Content>
    {
    }
}
