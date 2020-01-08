using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models.Entities
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ExpireDate { get; set; }
        public int QTY { get; set; }
        public string Brand { get; set; }
        public int ItemCost { get; set; }
        public int RetailPrice { get; set; }
        public string CatogaryName { get; set; }
        public string LocationName { get; set; }
        public string Position { get; set; }
        public string mesurementName { get; set; }
        public int CatogaryID { get; set; }
        public int LocationID { get; set; }
        public int PositionID { get; set; }
        public int mesurementID { get; set; }
    }
}
