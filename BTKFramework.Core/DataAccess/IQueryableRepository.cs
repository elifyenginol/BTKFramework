using BTKFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Core.DataAccess
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        //Readonly bir operasyon, bir context başvurucaz buna göre işlem gerçekleşecek
        IQueryable<T> Table { get; }
    }
}
