using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DbAdapter
    {
        public void Save(Category catgory)
        {
            using(var ctx = new ShopingContext())
            {
                ctx.Categories.Add(catgory);
                ctx.SaveChanges();
                var query = from ct in ctx.Categories
                            where ct.CategoryName == "food"
                            select ct;

                var categoty = query.FirstOrDefault<Category>();
            }
        }

        public Category Add(Category obj)
        {
            using(var ctx = new ShopingContext())
            {
                ctx.Categories.Add(obj);
                ctx.SaveChanges();
                return (from c in ctx.Categories where c.CategoryId == obj.CategoryId select c).FirstOrDefault();

            }
        }

        public Store Add(Store obj)
        {
            using (var ctx = new ShopingContext())
            {
                ctx.Stores.Add(obj);
                ctx.SaveChanges();
                return (from s in ctx.Stores where s.StoreId == obj.StoreId select s).FirstOrDefault();
            }
        }

        public User Add(User obj)
        {
            using (var ctx = new ShopingContext())
            {
                ctx.Users.Add(obj);
                ctx.SaveChanges();
                return (from u in ctx.Users where u.UserId == obj.UserId select u).FirstOrDefault();
            }
        }

        public Buying Add(Buying obj)
        {
            using (var ctx = new ShopingContext())
            {
                ctx.Buyings.Add(obj);
                ctx.SaveChanges();
                return (from b in ctx.Buyings where b.BuyingId == obj.BuyingId select b).FirstOrDefault();
            }
        }

        public Product Add(Product obj)
        {
            using (var ctx = new ShopingContext())
            {
                ctx.Products.Add(obj);
                ctx.SaveChanges();
                return (from p in ctx.Products where p.ProductId == obj.ProductId select p).FirstOrDefault();
            }
        }

        public void UpdateProduct (Product obj)
        {
            using (var ctx = new ShopingContext())
            {
                ctx.Products.AddOrUpdate(obj);
                ctx.SaveChanges();
            }
        }

        public List<Product> GetAllProducts () {
            using (var ctx = new ShopingContext())
            {
                return (from p in ctx.Products select p).ToList<Product>();
            }
        }

        public List<Buying> GetAllBuyings()
        {
            using (var ctx = new ShopingContext())
            {
                return (from b in ctx.Buyings select b).OrderByDescending(x => x.Date).ToList<Buying>();
            }
        }

        public List<Store> GetAllStores()
        {
            using (var ctx = new ShopingContext())
            {
                return (from s in ctx.Stores select s).ToList<Store>();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var ctx = new ShopingContext())
            {
                return (from u in ctx.Users select u).ToList<User>();
            }
        }

        public List<Category> GetAllCategories()
        {
            using (var ctx = new ShopingContext())
            {
                return (from c in ctx.Categories select c).ToList<Category>();
            }
        }



        public int GetMaxCategoryId()
        {
            using (var ctx = new ShopingContext())
            {
                return ctx.Categories.Select(c => c.CategoryId).DefaultIfEmpty(0).Max();
            }
        }
        public int GetMaxProductId()
        {
            using (var ctx = new ShopingContext())
            {
                return ctx.Products.Select(p => p.ProductId).DefaultIfEmpty(0).Max();
            }
        }

        public int GetMaxStoreId()
        {
            using (var ctx = new ShopingContext())
            {
                return ctx.Stores.Select(s => s.StoreId).DefaultIfEmpty(0).Max();
            }
        }

        public int GetMaxUserId()
        {
            using (var ctx = new ShopingContext())
            {
                return ctx.Users.Select(u => u.UserId).DefaultIfEmpty(0).Max();
            }
        }

        public int GetMaxBuyingId()
        {
            using (var ctx = new ShopingContext())
            {
                return ctx.Buyings.Select(b => b.BuyingId).DefaultIfEmpty(0).Max();
            }
        }


    }

    public class ShopingContext : DbContext
    {
        public ShopingContext():base("ShopingDB5")
        {
            /*
            //https://stackoverflow.com/questions/32607736/the-entity-framework-provider-type-system-data-entity-sqlserver-sqlproviderserv/32617247
            */
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Buying> Buyings { get; set; }
    }

  

}
