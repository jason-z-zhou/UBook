using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;
using System.Configuration;

namespace SalesManagementSystem.Attribute
{
    /// <summary>
    /// 权限控制
    /// </summary>
    public class UserAuthorizeAttibute : AuthorizeAttribute
 
    {
        public override void OnAuthorization(AuthorizationContext filterContext) { 
            EntityContext _db = new EntityContext ();
            var user = filterContext.HttpContext.Session["CurrentUser"] as User;

            if (user == null) {
                filterContext.Result = new RedirectResult(ConfigurationManager.AppSettings["Url"] + "/Error/Index/" );
            } 

            var controller = filterContext.RouteData.Values["controller"].ToString(); 
            var action = filterContext.RouteData.Values["action"].ToString();
            var path = controller + "/"+ action;
            var isAllowed = IsAllowed(user, path);

            if (!isAllowed) { 
                filterContext.RequestContext.HttpContext.Response.Write("无权访问"); 
                filterContext.RequestContext.HttpContext.Response.End();
            }
 
        }

        private bool IsAllowed(User user, string path)
        {
            EntityContext _db = new EntityContext();
            var userRolesIds = user.Roles.Select(r => r.RoleID).ToList();
            var allowRoles = _db.AllowRules.Where(ar => ar.Path == path).Select(ar => ar.Roles).ToList();

            foreach (Role role in allowRoles) {
                if (userRolesIds.Contains(role.RoleID ))
                {
                    return true ;
                } 
            }
            return false;
          
        }
    }
}