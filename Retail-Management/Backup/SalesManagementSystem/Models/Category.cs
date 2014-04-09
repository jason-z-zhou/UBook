using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int CategoryID { get; set; }

        [Display(Name = "商品类型名")]
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        [Display(Name = "描述")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Display(Name = "商品")]
        public virtual ICollection<Commodity> Commodities { get; set; }
    }
}