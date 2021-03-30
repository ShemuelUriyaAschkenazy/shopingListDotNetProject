using System;
using System.Collections.Generic;

namespace BE
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string productName, int categotyId)
        {
            ProductName = productName;
            CategotyId = categotyId;
        }

        public Product(int productId, string productName, int categotyId)
        {
            ProductId = productId;
            ProductName = productName;
            CategotyId = categotyId;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategotyId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   ProductId == product.ProductId &&
                   ProductName == product.ProductName &&
                   CategotyId == product.CategotyId;
        }
    }
}
