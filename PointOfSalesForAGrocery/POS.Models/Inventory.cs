using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace POS.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ItemName { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public int QTY { get; set; }
        public string Brand { get; set; }
        public int ItemCost { get; set; }
        public int RetailPrice { get; set; }
        [ForeignKey("ItemCatogaryId")]
        public ICollection<ItemCatogary> ItemCatogary { get; set; }
        [ForeignKey("ItemLocationId")]
        public ICollection<ItemLocation> ItemLocation { get; set; }
        [ForeignKey("UnitmesurementId")]
        public ICollection<Unitmesurement> Unitmesurement { get; set; }
        public int ItemCatogaryId { get; set; }
        public int ItemLocationId { get; set; }
        public int UnitmesurementId { get; set; }


    }
}
