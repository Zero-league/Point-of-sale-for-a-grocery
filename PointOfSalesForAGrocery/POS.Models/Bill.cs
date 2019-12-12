using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        public int Discount { get; set; }

        [Required]
        public int Amount { get; set; }
        public string SalesPerson { get; set; }
    }
}
