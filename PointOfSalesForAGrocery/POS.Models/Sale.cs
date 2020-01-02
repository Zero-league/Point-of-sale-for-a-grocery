using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string ItemsName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int RetailPrice { get; set; }

        public string SalesPerson { get; set; }

        [ForeignKey("BillId")]
        public virtual Bill ParentBill { get; set; }
        public int BillId { get; set; }
    }
}
