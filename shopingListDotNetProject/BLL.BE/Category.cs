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

        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }

        public Category(int categoryId, string categoryName)
        {
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Category categoty &&
                   CategoryId == categoty.CategoryId &&
                   CategoryName == categoty.CategoryName;
        }
    }
}
