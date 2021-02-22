using System;
using System.Collections.Generic;

namespace BE
{
    public class Product
    {
        public Product(int productId, string productName, Category categoty)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Categoty = categoty;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Category Categoty { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   ProductId == product.ProductId &&
                   ProductName == product.ProductName &&
                   EqualityComparer<Category>.Default.Equals(Categoty, product.Categoty);
        }
    }
}
