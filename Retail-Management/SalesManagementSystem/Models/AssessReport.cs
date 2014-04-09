using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class AssessReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int AssessReportID { get; set; }

        [Display(Name = "评分员")]
        public virtual User Reviewer { get; set; }
        [Required]
        public int UserID { get; set; }

        [Display(Name = "销售点")]
        public virtual Store Store { get; set; }
        [Required]
        public int StoreID { get; set; }
        
        [Display(Name = "评分结果")]
        public virtual ICollection<AssessGrade> Grade { get; set; }

        [Display(Name = "评分时间")]
        [Required]
        public DateTime AssessTime { get; set; }
    }
}