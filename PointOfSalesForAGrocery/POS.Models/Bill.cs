using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POS.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }

        public DateTime DateTime { get; set; }
        public int Discount { get; set; }

        [Required]
        public int Amount { get; set; }
        public string SalesPerson { get; set; }
    }
}
