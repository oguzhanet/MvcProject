using DevFramework.Core.DataAccess.EntityFramework;
using MvcProject.DataAccess.Abstract;
using MvcProject.Entities.Concrete;

namespace MvcProject.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category, Context>,ICategoryDal
    {
    }
}
