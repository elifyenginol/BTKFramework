using BTKFramework.Core.DataAccess.EntityFramework;
using BTKFramework.Northwind.DataAccess.Abstract;
using BTKFramework.Northwind.Entities.ComplexType;
using BTKFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles
                             on ur.UserId equals user.Id
                             where ur.UserId == user.Id
                             select new UserRoleItem { RoleName = r.Name };
                return result.ToList();       
            }
        }
    }
}
