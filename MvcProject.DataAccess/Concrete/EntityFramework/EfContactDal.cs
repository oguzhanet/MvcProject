using DevFramework.Core.DataAccess.EntityFramework;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entities.Concrete;

namespace MvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfContactDal:EfEntityRepositoryBase<Contact,Context>,IContactDal
    {
    }
}
