﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.OurClasses
{
    [Serializable]

    abstract public class Drinks : Consumables
    {
        public int Liter { get; set; }
        public Drinks(Image productImage, string productName, string productDescription, int productBarcode = 0, double productPrice = 0) : base(productImage, productName, productDescription, productBarcode, productPrice)
        {
        }
    }
}
