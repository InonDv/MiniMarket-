using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Shop.OurClasses
{
    [Serializable]

    public class My_Cart
    {
        public static double TotalPrice = 0;
        public static List<My_Cart> MyCart { get; set; } = new List<My_Cart>();
        public void AddToCart(My_Cart item)
        {
            MyCart.Add(item);
        }
        public void RemoveFromCart(My_Cart anyItem)
        {
            MyCart.Remove(anyItem);
        }
        public Groceries OurGroceries { get; set; }
        public int AmountOfItems { get; set; } = 0;
        public double CalculatePriceOfProduct()
        {
            return OurGroceries._ProductPrice * AmountOfItems;
        }
    }
}
