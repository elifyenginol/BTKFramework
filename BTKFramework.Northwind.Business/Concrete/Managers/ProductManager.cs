using BTKFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using BTKFramework.Northwind.Business.Abstract;
using BTKFramework.Northwind.Business.ValidationRules.FluentValidation;
using BTKFramework.Northwind.DataAccess.Abstract;
using BTKFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTKFramework.Core.Aspects.PostSharp;
using BTKFramework.Core.DataAccess;
using System.Transactions;
using BTKFramework.Core.Aspects.PostSharp.ValidationAspects;
using BTKFramework.Core.Aspects.PostSharp.TransactionAspect;
using BTKFramework.Core.Aspects.PostSharp.CacheAspect;
using BTKFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using System.Data.Entity.Infrastructure.Interception;
using BTKFramework.Core.Aspects.PostSharp.LogAspect;
using BTKFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using BTKFramework.Core.Aspects.PostSharp.PerformanceAspects;
using System.Threading;
using BTKFramework.Core.Aspects.PostSharp.AuthorizationAspects;
using AutoMapper;
using BTKFramework.Core.Utilities.Mappings;

namespace BTKFramework.Northwind.Business.Concrete.Managers
{
   
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IMapper _mapper;

        public IProductDal Object { get; }

        public ProductManager(IProductDal productDal,IMapper mapper) 
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public ProductManager(IProductDal @object)
        {
            Object = @object;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
       
        //[LogAspect(typeof(FileLogger))]
        [PerformancaCounterAspect(2)]
        [SecuredOperation(Roles="Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            //Thread.Sleep(3000);

            //return _productDal.GetList().Select(p=>new Product
            //{ 
            //    CategoryId=p.CategoryId,
            //    ProductId=p.ProductId,
            //    ProductName=p.ProductName,
            //    QuantityPerUnit=p.QuantityPerUnit,
            //    UnitPrice=p.UnitPrice
            //}).ToList();

            var products = _mapper.Map<List<Product>>(_productDal.GetList());          
            return products;
        }

       

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            // Business Codes
            _productDal.Update(product2);
        }
    }
}
