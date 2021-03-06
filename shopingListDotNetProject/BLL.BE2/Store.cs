﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Store
    {
        public Store()
        {
        }

        public Store(string storeName)
        {
            StoreName = storeName;
        }

        public Store(int storeId, string storeName)
        {
            this.StoreId = storeId;
            this.StoreName = storeName;
        }

        public int Id { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Store store &&
                   StoreId == store.StoreId &&
                   StoreName == store.StoreName;
        }
    }
}
