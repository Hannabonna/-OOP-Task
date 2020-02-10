using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;


namespace Learn_Oop
{
    public class Cart : Item
    {
        static string cartPath = @"/Users/gigaming/Projects/Learn_Oop/Learn_Oop/item.txt";
        public int Item_id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        static List<Item> itemCart = new List<Item>();

        public Cart AddItem(int id, int price, int quantity = 1)
        {
            var i = new Cart();
            i.Item_id = id;
            i.Price = price;
            i.Quantity = quantity;
            itemCart.Add(i);
            return this;
        }

        public Cart RemoveItem(int id)
        {
            var i = itemCart;
            var newItem = new List<Item>();
            foreach (var x in i)
            {
                if (x.Item_id != id)
                {
                    newItem.Add(x);
                }
            }
            itemCart = newItem;
            return this;
        }

        public Cart AddDiscount(int id)
        {
            var i = itemCart;
            foreach (var x in i)
            {
                x.Price = x.Price * id / 100;
            }
            itemCart = i;
            return this;
        }

        public static int TotalItems()
        {
            return itemCart.Count();
        }

        public static int TotalQuantity()
        {
            int total = 0;
            foreach (var x in itemCart)
            {
                total += x.Quantity;
            }
            return total;
        }

        public static int TotalPrice()
        {
            int total = 0;
            foreach (var x in itemCart)
            {
                total += x.Price * x.Quantity;
            }
            return total;
        }

        public static string ShowAllItems()
        {
            var allItems = new List<string>();
            foreach (var x in itemCart)
            {
                allItems.Add(x.Item_id.ToString());
            }
            allItems.Distinct();
            return String.Join(",", allItems);
        }

        public static void Checkout()
        {
            List<string> lines = new List<string>();

            lines.Add("item_id,price,quantity");

            foreach (var x in itemCart)
            {
                lines.Add($"{x.Item_id},{x.Price},{x.Quantity}");
            }
            File.WriteAllLines(cartPath, lines);
        }
    }
}