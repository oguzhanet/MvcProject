using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcProject.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter);
        List<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
