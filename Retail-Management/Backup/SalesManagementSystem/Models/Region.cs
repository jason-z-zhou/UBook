using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegionID { get; set; }

        [Display(Name = "片区名")]
        [Required]
        [MaxLength(100)]
        public string RegionName { get; set; }

        [Display(Name = "片区地址")]
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Display(Name = "销售点")]
        public virtual ICollection<Store> Stores { get; set; }
    }
}