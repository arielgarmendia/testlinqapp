using ConsoleTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    internal class Purchases
    {
        public Purchases()
        {
            List<Item_mast> itemlist = new List<Item_mast>            
            {
                new Item_mast { ItemId = 1, ItemDescription = "Biscuit  " },
                new Item_mast { ItemId = 2, ItemDescription = "Chocolate" },
                new Item_mast { ItemId = 3, ItemDescription = "Butter   " },
                new Item_mast { ItemId = 4, ItemDescription = "Brade    " },
                new Item_mast { ItemId = 5, ItemDescription = "Honey    " }
            };

            List<Purchase> purchaselist = new List<Purchase>
            {
                new Purchase { InventoryNumber=100, ItemId = 3,  PurchaseQuantity = 800 },
                new Purchase { InventoryNumber=101, ItemId = 2,  PurchaseQuantity = 650 },
                new Purchase { InventoryNumber=102, ItemId = 3,  PurchaseQuantity = 900 },
                new Purchase { InventoryNumber=103, ItemId = 4,  PurchaseQuantity = 700 },
                new Purchase { InventoryNumber=104, ItemId = 3,  PurchaseQuantity = 900 },
                new Purchase { InventoryNumber=105, ItemId = 4,  PurchaseQuantity = 650 },
                new Purchase { InventoryNumber=106, ItemId = 1,  PurchaseQuantity = 458 }
            };

            var query = from item in itemlist
                        join purchase in purchaselist on item.ItemId equals purchase.ItemId into itemPurchaseJoin
                        from x in itemPurchaseJoin.DefaultIfEmpty()
                        select new
                        {
                            item.ItemId,
                            item.ItemDescription,
                            quantity = x?.PurchaseQuantity ?? 0
                        };

            Console.WriteLine("Item ID \t\t Item Name \t\t Purchase Quantity");
            Console.WriteLine("-------------------------------------------------------");

            foreach (var item in query)
            {
                Console.WriteLine("{0} \t\t\t {1} \t\t\t {2}", item.ItemId, item.ItemDescription, item.quantity);
            }
        }
    }
}
