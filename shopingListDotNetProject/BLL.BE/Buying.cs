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
        public Buying(int buyingId, int storeId, int productId, int pricePerOneProduct, int amount, int userId, DateTime date)
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
        public int PricePerOneProduct { get; set; }
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
