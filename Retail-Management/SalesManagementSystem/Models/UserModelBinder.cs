using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesManagementSystem.Models
{
    public class UserModelBinder : IModelBinder
    {
        private readonly IModelBinder binder;

        public UserModelBinder(IModelBinder binder)
        {
            this.binder = binder;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var user = (User)binder.BindModel(controllerContext, bindingContext);
            AddRoles(user, controllerContext);
            return user;
        }

        private static void AddRoles(User user, ControllerContext controllerContext)
        {
            var roles = new List<Role> { };
            foreach (var role in GetRoles(controllerContext))
            {
                roles.Add(role);
            }
            user.Roles = roles;
        }
        
        private static IEnumerable<Role> GetRoles(ControllerContext controllerContext)
        {
            var roles = controllerContext.HttpContext.Request["Roles"];
            if (roles == null) yield break;
            using (EntityContext db = new EntityContext())
            {
                foreach (var roleId in roles.Split(','))
                {
                    yield return new Role() { RoleID = Int32.Parse(roleId)};
                }
            }
        }

    }
}