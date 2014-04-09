using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using SalesManagementSystem.Models;



namespace SalesManagementSystem.ViewModels
{
    public class ChangePassword
    {
        public int UserID { get; set; }
       [Display (Name = "新密码")]
        public string NewPassword { get; set; }
       [Display (Name = "确认密码")]
        public string ConfirmPassword { get; set; }
        
    }

}