using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhEntityRepositoryBase<TEntity>:IEntityRepository<TEntity>
       where TEntity:class,IEntity,new()
    {
        private NHibernateHelper _hibernateHelper;

        public NhEntityRepositoryBase(NHibernateHelper hibernateHelper)
        {
            _hibernateHelper = hibernateHelper;
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _hibernateHelper.OpenSession())
            {
                return filter == null
                    ? session.Query<TEntity>().ToList()
                    : session.Query<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = _hibernateHelper.OpenSession())
            {
                return session.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var session=_hibernateHelper.OpenSession())
            {
                session.Save(entity);
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var session = _hibernateHelper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var session = _hibernateHelper.OpenSession())
            {
                session.Delete(entity);
                
            }
        }
    }
}
