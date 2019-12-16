using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        public string ExpireDate { get; set; }
        [Required]
        public int QTY { get; set; }
        public string Brand { get; set; }
        [Required]
        public int ItemCost { get; set; }
        public int RetailPrice { get; set; }
        [ForeignKey("ItemCatogaryId")]
        public ItemCatogary ItemCatogary { get; set; }
        [ForeignKey("ItemLocationId")]
        public ItemLocation ItemLocation { get; set; }
        [ForeignKey("UnitmesurementId")]
        public Unitmesurement Unitmesurement { get; set; }
        public int ItemCatogaryId { get; set; }
        public int ItemLocationId { get; set; }
        public int UnitmesurementId { get; set; }


    }
}
