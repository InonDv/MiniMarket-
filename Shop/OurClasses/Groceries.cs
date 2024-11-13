using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.OurClasses
{
    [Serializable]

    public class Groceries
    {
        public enum CategoryType
        {
            Meat_Product = 1, Dairy_Product = 2, Soft_Drinks = 3, Coffee = 4, Shower_Products = 5, Dental_Products = 6,Vegetables = 7
        }
        public Image _ProductImage { get; set; }
        public int _ProductBarcode = 0;
        public int _CategoryType = 0;
        public double _ProductPrice { get; set; } = 0.0;
        public string _ProductName { get; set; } = string.Empty;
        public string _ProductDescription { get; set; } = string.Empty;

        public static Groceries[] OurCart = new Groceries[31];


        public Groceries(Image productImage,string productName, string productDescription ,int productBarcode = 0, double productPrice = 0)
        {
            _ProductImage = productImage;
            _ProductBarcode = productBarcode;
            _ProductPrice = productPrice;
            _ProductName = productName;
            _ProductDescription = productDescription;
        }
    }
}
