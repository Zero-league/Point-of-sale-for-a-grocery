using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Models.Entities
{
    public class InventoryDto
    {
        public string ItemName { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public int QTY { get; set; }
        public string Brand { get; set; }
        public int ItemCost { get; set; }
        public int RetailPrice { get; set; }
    }
}
