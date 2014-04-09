using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class Commodity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int CommodityID { get; set; }

        [Display(Name = "商品名")]
        [Required]
        [MaxLength(50)]
        public string CommodityName { get; set; }

        [Display(Name = "单价")]
        [Required]
        public double Price { get; set; }

        [Display(Name = "描述")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Display(Name = "所属商品类型")]
        public virtual Category Category { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}