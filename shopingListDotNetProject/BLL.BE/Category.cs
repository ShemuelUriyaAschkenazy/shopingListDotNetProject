using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Category
    {
        public Category()
        {
        }

        public Category(int categoryId, string categoryName)
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
        }

        public int id { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Category categoty &&
                   categoryId == categoty.categoryId &&
                   categoryName == categoty.categoryName;
        }
    }
}
