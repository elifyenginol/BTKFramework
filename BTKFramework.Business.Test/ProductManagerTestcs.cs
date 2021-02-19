using BTKFramework.Northwind.Business.Concrete.Managers;
using BTKFramework.Northwind.DataAccess.Abstract;
using BTKFramework.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Business.Test
{
    [TestClass]
    class ProductManagerTestcs
    {
        
        
            [ExpectedException(typeof(ValidationException))]
            [TestMethod]
            public void ProductValidation_Check()
            {
                Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

                productManager.Add(new Product());
            }
        }
    }

