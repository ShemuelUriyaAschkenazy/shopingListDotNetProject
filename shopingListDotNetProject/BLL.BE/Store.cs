﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Store
    {
        public Store(int storeId, string storeName)
        {
            this.StoreId = storeId;
            this.StoreName = storeName;
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
    }
}