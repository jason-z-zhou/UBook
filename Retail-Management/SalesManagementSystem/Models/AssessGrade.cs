using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class AssessGrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int AssessGradeID { get; set; }

        [Display(Name = "评分表")]
        public virtual AssessReport Report { get; set; }
        [Required]
        public int AssessReportID { get; set; }

        [Display(Name = "评分项")]
        public virtual AssessItem Item { get; set; }
        [Required]
        public int AssessItemID { get; set; }

        [Display(Name = "得分")]
        [Required]
        public double Grade { get; set; }

        [Display(Name = "备注")]
        [MaxLength(200)]
        public string Comment { get; set; }
    }
}