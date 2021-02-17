using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Buying
    {
        public Buying(Store store, Product product, int pricePerOneProduct)
        {
            this.Store = store;
            this.Product = product;
            this.PricePerOneProduct = pricePerOneProduct;
        }

        public Store Store { get; set; }
        public Product Product { get; set; }
        public int PricePerOneProduct { get; set; }
        public int Amount { get; set; }
        public User User { get; set; }
    }
}
