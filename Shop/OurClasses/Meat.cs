using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.OurClasses
{
    [Serializable]

    public class Meat : Food
    {
        public int Protein { get; set; }
        public Meat(Image productImage, string productName, string productDescription, int productBarcode = 0, double productPrice = 0) : base(productImage, productName, productDescription, productBarcode, productPrice)
        {
            _CategoryType = (int)CategoryType.Meat_Product;
        }
    }
}
