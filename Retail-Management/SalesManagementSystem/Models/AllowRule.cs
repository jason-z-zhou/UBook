using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class AllowRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int AllowRuleID { get; set; }

        [Required]
        [Display(Name = "路径")]
        [MaxLength(200)]
        public string Path { get; set; }
        
        [Display(Name = "允许角色")]
        public virtual ICollection<Role> Roles { get; set; }
    }
}