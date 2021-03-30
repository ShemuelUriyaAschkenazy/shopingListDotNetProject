using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Buying
    {
        public Buying()
        {
        }

        public Buying(int productId, int storeId, int amount, double pricePerOneProduct)
        {
            ProductId = productId;
            StoreId = storeId;
            Amount = amount;
            PricePerOneProduct = pricePerOneProduct;
        }

        public Buying(int storeId, int productId, double pricePerOneProduct, int amount, int userId, DateTime date)
        {
            StoreId = storeId;
            ProductId = productId;
            PricePerOneProduct = pricePerOneProduct;
            Amount = amount;
            UserId = userId;
            Date = date;
        }

        public Buying(int buyingId, int storeId, int productId, double pricePerOneProduct, int amount, int userId, DateTime date)
        {
            BuyingId = buyingId;
            StoreId = storeId;
            ProductId = productId;
            PricePerOneProduct = pricePerOneProduct;
            Amount = amount;
            UserId = userId;
            Date = date;
        }

        public int Id { get; set; }
        public int BuyingId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public double PricePerOneProduct { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Buying buying &&
                   Id == buying.Id &&
                   BuyingId == buying.BuyingId &&
                   StoreId == buying.StoreId &&
                   ProductId == buying.ProductId &&
                   PricePerOneProduct == buying.PricePerOneProduct &&
                   Amount == buying.Amount &&
                   UserId == buying.UserId &&
                   Date == buying.Date;
        }
    }
}
