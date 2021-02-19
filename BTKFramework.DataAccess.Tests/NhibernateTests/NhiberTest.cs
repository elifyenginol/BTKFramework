using BTKFramework.Northwind.DataAccess.Concrete.NHibernate;
using BTKFramework.Northwind.DataAccess.Concrete.NHibernate.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BTKFramework.DataAccess.Tests.NhibernateTests
{
    [TestClass]
    public class NhiberTest
    {
        [ TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal= new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList();

            Assert.AreEqual(78, result.Count);
        }
        [TestMethod]
        public void Get_all_with_parameters_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
