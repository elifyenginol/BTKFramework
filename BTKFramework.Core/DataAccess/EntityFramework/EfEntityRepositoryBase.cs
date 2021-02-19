using BTKFramework.Core.DataAccess.NHibernate;
using BTKFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Core.DataAccess.EntityFramework
{
    //base içine Bir entity ve context gönderiyoruz  bunlar IEntity ve Dbcontext
    //Db context ef için gerekli bunlara şart ekledik(Defensive programming)
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        //base içine Bir entity ve context gönderiyoruz  bunlar IEntity ve Dbcontext
        //Db context ef için gerekli bunlara şart ekledik(Defensive programming)
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);//İlgili nesneye abone olmam gerekiyor
                addedEntity.State = EntityState.Added; //Durumunu eklenecek data olarak belirtiyorum
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//İlgili nesneye abone olmam gerekiyor
                deletedEntity.State = EntityState.Deleted; //Durumunu eklenecek data olarak belirtiyorum
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

      

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//İlgili nesneye abone olmam gerekiyor
                updatedEntity.State = EntityState.Modified; //Durumunu eklenecek data olarak belirtiyorum
                context.SaveChanges();
                return entity;
            }
        }
    }
}
