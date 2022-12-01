using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp.Models
{    public class Item_mast
    {
        public int ItemId { get; set; }
        public string? ItemDescription { get; set; }
    }

    public class Purchase
    {
        public int InventoryNumber { get; set; }
        public int ItemId { get; set; }
        public int PurchaseQuantity { get; set; }
    }

    public class PurchaseUnion
    {
        public int ItemId { get; set; }
        public string? ItemDescription { get; set; }
        public int PurchaseQuantity { get; set; }
    }
}
