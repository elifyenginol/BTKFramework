using BTKFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Core.DataAccess
{
    //class:Referans tip
    //new yazma sebebimiz abstract sınıflarda bir referans tipi ama newlenemez bu yüzden new yazıyoruz ki class gelsin
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        ///LINQ (Expression) ile birlikte filtreye göre ürün listeleyebilirim null olursa hepsini döndürür.
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        //Nesne gönderip PK ile sileceğim.
        void Delete(T entity);
    }
}
