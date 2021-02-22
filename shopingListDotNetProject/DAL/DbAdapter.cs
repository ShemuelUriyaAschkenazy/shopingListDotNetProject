using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DbAdapter
    {
        public void Save(Category catgory)
        {
            using(var ctx = new CategoryContext())
            {
                ctx.Categories.Add(catgory);
                ctx.SaveChanges();
                var query = from ct in ctx.Categories
                            where ct.categoryName == "food"
                            select ct;

                var categoty = query.FirstOrDefault<Category>();


                
            }
        }

        public void AddCategory(Category obj)
        {
            using(var ctx = new CategoryContext())
            {
                //ctx.Categories.Add(obj);
                //ctx.SaveChanges();
                //var categoty = query.ToList<Category>();
                var maxCategoryId = ctx.Database.SqlQuery<int>("select max(CategoryId) from Categories").First();

                var integer = maxCategoryId + 4;
                
                //var categoty2 = query.FirstOrDefault<Category>();



            }
        }


    }

    public class CategoryContext : DbContext
    {
        public CategoryContext():base("ShopingDB1")
        {

            /*
            //https://stackoverflow.com/questions/32607736/the-entity-framework-provider-type-system-data-entity-sqlserver-sqlproviderserv/32617247
            */
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Category> Categories { get; set; }
    }


}
