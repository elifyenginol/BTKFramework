using BTKFramework.Core.DataAccess.NHibernate;
using BTKFramework.Northwind.DataAccess.Abstract;
using BTKFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal:NhEntityRepositoryBase<Category>,ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper):base(nHibernateHelper)
        {

        }
    }
}
