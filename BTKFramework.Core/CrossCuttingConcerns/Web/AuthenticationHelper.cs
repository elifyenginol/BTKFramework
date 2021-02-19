using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace BTKFramework.Core.CrossCuttingConcerns.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(Guid id,string userName,string email,DateTime expriation,string[] roles,
            bool rememberMe,string firstName,string lastName)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expriation, rememberMe,
                CreateAuthTags(email, roles, firstName, lastName,id));
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        private static string CreateAuthTags(string email, string[] roles, string firstName, string lastName,Guid id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
               
                if (i<roles.Length-1)
                {
                   stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("|");
            stringBuilder.Append(firstName);
            stringBuilder.Append("|");
            stringBuilder.Append(lastName);
            stringBuilder.Append("|");
            stringBuilder.Append(id);
            

            return stringBuilder.ToString();



        }
    }
}
