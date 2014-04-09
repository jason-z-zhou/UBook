using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Web.Mvc;

namespace SalesManagementSystem.Models
{
    [Bind(Exclude = "Roles")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int UserID { get; set; }

        [Required]
        [Display(Name = "用户名")]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "密码密文")]
        [MaxLength(32)]
        public string PasswordHash { get; set; }

        [Required]
        [Display(Name = "密码")]
        [NotMapped]
        public string Password { get { return "********"; } set { PasswordHash = MD5Hash(value); } }

        [Display(Name = "名字")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Display(Name = "姓氏")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Display(Name = "联系电话")]
        [MaxLength(20)]
        public string Tel { get; set; }

        [Display(Name = "电子邮箱")]
        [MaxLength(200)]
        public string Email { get; set; }

        [Display(Name = "备注")]
        [MaxLength(200)]
        public string Comment { get; set; }

        [Display(Name = "所属销售点")]
        public virtual ICollection<Store> StoresBelonged { get; set; }

        [Display(Name = "检查销售点")]
        public virtual ICollection<Store> StoresCharged { get; set; }

        [Display(Name = "所属角色")]
        public virtual ICollection<Role> Roles { get; set; }

        [Display(Name = "收件箱")]
        public virtual ICollection<Message> Inbox { get; set; }

        [Display(Name = "发件箱")]
        public virtual ICollection<Message> Outbox { get; set; }

        public string MD5Hash(string Password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "md5").ToLower();
        }

        public bool VerifyPassword(string Password)
        {
            return (PasswordHash == MD5Hash(Password));
        }
    }
}