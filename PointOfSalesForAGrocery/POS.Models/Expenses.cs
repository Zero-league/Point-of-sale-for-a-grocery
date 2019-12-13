using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POS.Models
{
    public class Expenses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpId { get; set; }

        [ForeignKey("ExpeId")]
        public ExpenseType expenseType { get; set; }
        public int ExpeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public double Payment { get; set; }

    }
}
