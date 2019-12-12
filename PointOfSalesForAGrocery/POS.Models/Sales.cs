using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POS.Models
{
    public class Sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemsId { get; set; }

        [Required]
        public string ItemsName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int RetailPrice { get; set; }
        
        public string SalesPerson { get; set; }

        [ForeignKey("BillId")]
        public Bill ParentBill { get; set; }
        public int BillId { get; set; }
    }
}
