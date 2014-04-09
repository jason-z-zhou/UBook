using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int StoreID { get; set; }

        [Display(Name = "销售点名")]
        [Required]
        [MaxLength(100)]
        public string StoreName { get; set; }

        [Display(Name = "创建时间")]
        [Required]
        public DateTime CreationTime { get; set; }

        [Display(Name = "详细地址")]
        [MaxLength(200)]
        [Required]
        public string Address { get; set; }

        [Display(Name = "经度")]
        [Required]
        public double Longitude { get; set; }

        [Display(Name = "纬度")]
        [Required]
        public double Latitude { get; set; }

        [Display(Name = "备注")]
        [MaxLength(200)]
        public string Comment { get; set; }

        [Display(Name = "营销点检查员")]
        public virtual ICollection<User> Inspectors { get; set; }

        [Display(Name = "销售点负责人")]
        public virtual ICollection<User> Employees { get; set; }

        [Display(Name = "所属片区")]
        public virtual Region Region { get; set; }
        [Required]
        public int RegionID { get; set; }
    }
}