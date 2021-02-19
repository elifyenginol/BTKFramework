using BTKFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;
        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }
        public IQueryable<T> Table => this.Entities;

        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities==null)
                {
                    _entities = _nHibernateHelper.OpenSession().Query<T>();
                }
                return _entities;
            }
        }
    }
}
