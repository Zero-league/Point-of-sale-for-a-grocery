﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class ExpenseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string ExpenseName { get; set; }

        [ForeignKey("ExpId")]
        public Expenses expenses { get; set; }
        public int ExpId { get; set; }
    }
}
