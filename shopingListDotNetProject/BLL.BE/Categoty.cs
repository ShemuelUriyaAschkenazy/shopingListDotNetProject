using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Categoty
    {
        public Categoty(int categoryId, string categoryName)
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
        }

        int categoryId { get; set; }
        string categoryName { get; set; }
    }
}
