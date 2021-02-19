using BTKFramework.Core.DataAccess.NHibernate;
using BTKFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T>:IQueryableRepository<T> where T:class,IEntity,new()
    {
        //iş katmanımın her context erişebilmesini ve bağımlılığını yok edecek

        private DbContext _context;
        private IDbSet<T> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities;//Expression: entities return et demek get gibi

        protected virtual IDbSet<T> Entities
        {
            get
            {
                //Eğer entities null ise context olarak ne gönderirsem abone ol ama aboneysen döndür
                //if (_entities==null)
                //{
                //    _entities = _context.Set<T>();
                //}
                return _entities ?? (_entities=_context.Set<T>());
            }
        }
    }
}
