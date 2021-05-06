using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Entities;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<T>:IQueryableRepository<T> 
    where  T:class,IEntity,new()
    {
        private NHibernateHelper _hibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NHibernateHelper hibernateHelper)
        {
            _hibernateHelper = hibernateHelper;
        }

        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities==null)
                {
                    _entities = _hibernateHelper.OpenSession().Query<T>();
                }

                return _entities;
            }
        }

    }
}
