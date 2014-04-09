using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesManagementSystem.Models;
using SalesManagementSystem.Controllers;

namespace SalesManagementSystem.Helpers
{
    public static class MenuHelper
    {
        public static HtmlString MainDropdownMenu(this HtmlHelper helper)
        {
            UrlHelper url = new UrlHelper(helper.ViewContext.RequestContext);
            var user = (User)HttpContext.Current.Session["CurrentUser"];
            string userfullname = user == null ? "" : user.LastName + user.FirstName;
            string result = @"            <nav>
				<ul id=""main-navigation"" class=""clearfix"">
                    <li class=""fr dropdown""> 
                        <a href=""#"" class=""with-profile-image""><span><img src=""" + url.Content("~/Content/images/profile-image.png") + @"""/></span>" + userfullname + @"</a> 
                        <ul> 
                            <li><a href=""" + url.Action("ChangePersonelInfo", "User") + @""">修改个人资料</a></li>
                            <li><a href=""" + url.Action("ModifyPassword", "User") + @""">修改密码</a></li>
                            <li><a href=""" + url.Action("LogOut", "Session") + @""">登出</a></li> 
                        </ul> 
                    </li> 
				</ul>
            </nav>";
            return new HtmlString(result);
        }

        public static HtmlString MainSidebar(this HtmlHelper helper)
        {
            UrlHelper url = new UrlHelper(helper.ViewContext.RequestContext);
            var user = (User)HttpContext.Current.Session["CurrentUser"];
            string controller = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            string result = @"                <nav>
                    <ul>
" + (UserAuthorizeAttribute.IsAllowed(user, "Home") ? @"                        <li" + (controller.Equals("Home", StringComparison.OrdinalIgnoreCase) ? @" class=""current""" : "") + @"><a href=""" + url.Action("Index", "Home") + @""">帮助</a></li>
" : "") + (UserAuthorizeAttribute.IsAllowed(user, "Home") ? @"                        <li" + (controller.Equals("User", StringComparison.OrdinalIgnoreCase) ? @" class=""current""" : "") + @"><a href=""" + url.Action("Index", "User") + @""">用户</a></li>
" : "") + (UserAuthorizeAttribute.IsAllowed(user, "Home") ? @"                        <li" + (controller.Equals("Category", StringComparison.OrdinalIgnoreCase) ? @" class=""current""" : "") + @"><a href=""" + url.Action("Index", "Category") + @""">商品类型</a></li>
" : "") + (UserAuthorizeAttribute.IsAllowed(user, "Home") ? @"                        <li" + (controller.Equals("Commodity", StringComparison.OrdinalIgnoreCase) ? @" class=""current""" : "") + @"><a href=""" + url.Action("Index", "Commodity") + @""">商品</a></li>
" : "") + (UserAuthorizeAttribute.IsAllowed(user, "Home") ? @"                        <li" + (controller.Equals("Region", StringComparison.OrdinalIgnoreCase) ? @" class=""current""" : "") + @"><a href=""" + url.Action("Index", "Region") + @""">片区</a></li>
" : "") + (UserAuthorizeAttribute.IsAllowed(user, "Home") ? @"                        <li" + (controller.Equals("Store", StringComparison.OrdinalIgnoreCase) ? @" class=""current""" : "") + @"><a href=""" + url.Action("Index", "Store") + @""">销售点</a></li>
" : "") + (UserAuthorizeAttribute.IsAllowed(user, "Home") ? @"                        <li" + (controller.Equals("SalesRecord", StringComparison.OrdinalIgnoreCase) ? @" class=""current""" : "") + @"><a href=""" + url.Action("Index", "SalesRecord") + @""">销售记录</a></li>
" : "") + (UserAuthorizeAttribute.IsAllowed(user, "Home") ? @"                        <li" + (controller.Equals("AssessItem", StringComparison.OrdinalIgnoreCase) ? @" class=""current""" : "") + @"><a href=""" + url.Action("Index", "AssessItem") + @""">评分条目</a></li>
" : "") + (UserAuthorizeAttribute.IsAllowed(user, "Home") ? @"                        <li" + (controller.Equals("AssessReport", StringComparison.OrdinalIgnoreCase) ? @" class=""current""" : "") + @"><a href=""" + url.Action("Index", "AssessReport") + @""">评分报告</a></li>
" : "") + @"                    </ul>
                </nav>";
            return new HtmlString(result);
        }
    }
}