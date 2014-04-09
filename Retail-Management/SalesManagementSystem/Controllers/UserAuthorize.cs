using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SalesManagementSystem.Models;
using System.Configuration;

namespace SalesManagementSystem.Controllers
{
    class UserAuthorizeAttribute : AuthorizeAttribute
    {
       
        
        public override void OnAuthorization(AuthorizationContext filterContext) { 
            EntityContext _db = new EntityContext ();
            User user = filterContext.HttpContext.Session["CurrentUser"] as User;

            if (user == null) {
                filterContext.Result = new RedirectResult(ConfigurationManager.AppSettings["Url"] + "/Error/Index/" );
            } 

            var controller = filterContext.RouteData.Values["controller"].ToString(); 
//            var action = filterContext.RouteData.Values["action"].ToString();
//            var path = controller + "/"+ action;
            var path = controller;
            var isAllowed = IsAllowed(user, path);

            if (!isAllowed) { 
                filterContext.RequestContext.HttpContext.Response.Write("无权访问"); 
                filterContext.RequestContext.HttpContext.Response.End();
           
            }
 
        }

        public static bool IsAllowed(User user, string path)
        {
            return true;
            EntityContext _db = new EntityContext();
            var userRolesIds = user.Roles.Select(r => r.RoleID).ToList();
            AllowRule allowRule = _db.AllowRules.Where(ar => ar.Path == path).Single();
            var allowRoles = allowRule.Roles;
            foreach (Role role in allowRoles)
            {
                if (userRolesIds.Contains(role.RoleID))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
