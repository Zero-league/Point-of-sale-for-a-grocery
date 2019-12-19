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
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public float Discount { get; set; }
        [Required]
        public float GroceAmount { get; set; }
        [Required]
        public float NetAmount { get; set; }
        public string SalesPerson { get; set; }
    }
}
