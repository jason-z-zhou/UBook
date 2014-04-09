using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class AssessItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int AssessItemID { get; set; }

        [Display(Name = "评分项名")]
        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }

        [Display(Name = "评分项描述")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Display(Name = "评分项总分")]
        [Required]
        public double Score { get; set; }
    }
}