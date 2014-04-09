using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class SalesRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int SalesRecordID { get; set; }

        [Display(Name = "销售日期")]
        [Required]
        public DateTime Date { get; set; }


        [Display(Name = "销售量")]
        [Required]
        public int Volume { get; set; }

        [Display(Name = "销售产品")]
        public virtual Commodity Commodity { get; set; }
        [Required]
        public int CommodityID { get; set; }

        [Display(Name = "销售点")]
        public virtual Store Store { get; set; }
        [Required]
        public int StoreID { get; set; }
    }
}