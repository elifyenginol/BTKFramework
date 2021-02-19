using BTKFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");

            LazyLoad();

            Id(x => x.CategoryId).Column("CategoryID");        
            Map(x => x.CategoryName).Column("CategoryName");

        }
    }
}
