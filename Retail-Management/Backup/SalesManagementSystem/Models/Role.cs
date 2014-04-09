using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int RoleID { get; set; }

        [Display(Name = "角色名")]
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }

        [Display(Name = "描述")]
        [MaxLength(200)]
        public string Description { get; set; }
        
        [Display(Name = "用户")]
        public virtual ICollection<User> Users { get; set; }

        [Display(Name = "权限允许规则")]
        public virtual ICollection<AllowRule> AllowRules { get; set; }
    }
}