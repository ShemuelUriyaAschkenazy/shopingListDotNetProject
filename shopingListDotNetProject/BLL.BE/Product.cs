using System;

namespace BE
{
    public class Product
    {
        public Product(int productId, string productName, Categoty categoty)
        {
            this.productId = productId;
            this.productName = productName;
            this.categoty = categoty;
        }

        int productId { get; set; }
        string productName { get; set; }
        Categoty categoty { get; set; }


    }
}
