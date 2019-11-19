using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models
{
    class SoldItems
    {
        public DateTime DateTime { get; set; }
        public int BillId { get; set; }
        public string ItemsName { get; set; }
        public int ItemsId { get; set; }
        public int Quantity { get; set; }
        public int RetailPrice { get; set; }
        public int Total { get; set; }
        public string SalesPerson { get; set; }
    }
}
