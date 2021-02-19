using BTKFramework.Core.DataAccess;
using BTKFramework.Northwind.Entities.ComplexType;
using BTKFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //Ürüne özgü methodlarımızı burada yazarız bağımlılığı kaldırmak için IEntityRepository implement ettik
        List<ProductDetail> GetProductDetails();
    }
}
