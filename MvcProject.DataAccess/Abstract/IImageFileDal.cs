using DevFramework.Core.DataAccess;
using MvcProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.DataAccess.Abstract
{
    public interface IImageFileDal : IEntityRepository<ImageFile>
    {
    }
}
