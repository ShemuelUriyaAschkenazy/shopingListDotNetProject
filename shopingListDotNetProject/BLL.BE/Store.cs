using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Store
    {
        public Store(int storeId, string storeName)
        {
            this.storeId = storeId;
            this.storeName = storeName;
        }

        int storeId { get; set; }
        string storeName { get; set; }
    }
}
