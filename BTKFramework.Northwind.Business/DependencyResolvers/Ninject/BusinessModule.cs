using BTKFramework.Core.DataAccess;
using BTKFramework.Core.DataAccess.EntityFramework;
using BTKFramework.Core.DataAccess.NHibernate;
using BTKFramework.Northwind.Business.Abstract;
using BTKFramework.Northwind.Business.Concrete.Managers;
using BTKFramework.Northwind.DataAccess.Abstract;
using BTKFramework.Northwind.DataAccess.Concrete.EntityFramework;
using BTKFramework.Northwind.DataAccess.Concrete.NHibernate;
using BTKFramework.Northwind.DataAccess.Concrete.NHibernate.Helper;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
           Bind<IProductService>().To<ProductManager>().InSingletonScope();
           Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
           Bind<IUserService>().To<UserManager>();
           Bind<IUserDal>().To<EfUserDal>();


           Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
           Bind<DbContext>().To<NorthwindContext>();
           Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
