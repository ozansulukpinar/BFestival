using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BFest.UI.MVC.CustomFilter
{
    public class CustomFilterAdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //kullanıcı girişi varken nasıl davranacağını belirtiriz
            if (HttpContext.Current.Session["admin"] != null)
            {
                return true;
            }
            return false;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //kullanıcı girişi yokken nasıl davranacağını belirtiriz
            filterContext.Result = new RedirectResult("/Admin/Login");
        }
    }
}