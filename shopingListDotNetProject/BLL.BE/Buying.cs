using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Buying
    {
        public Buying(Store store, Product product, int pricePerOneProduct, DateTime date)
        {
            this.Store = store;
            this.Product = product;
            this.PricePerOneProduct = pricePerOneProduct;
            this.Date = date;
        }

        public Store Store { get; set; }
        public Product Product { get; set; }
        public int PricePerOneProduct { get; set; }
        public int Amount { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Buying buying &&
                   EqualityComparer<Store>.Default.Equals(Store, buying.Store) &&
                   EqualityComparer<Product>.Default.Equals(Product, buying.Product) &&
                   PricePerOneProduct == buying.PricePerOneProduct &&
                   Amount == buying.Amount &&
                   EqualityComparer<User>.Default.Equals(User, buying.User) &&
                   Date == buying.Date;
        }
    }
}
