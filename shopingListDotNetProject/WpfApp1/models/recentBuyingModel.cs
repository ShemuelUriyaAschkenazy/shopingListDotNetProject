
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.models
{
    public class recentBuyingModel
    {
        public List<Buying> buyings { get; set; }
       public List<User> userlist { get; set; }
        public List<Store> storelist { get; set; }

        public List<Product> productlist { get; set; }

        public recentBuyingModel()
        {
            buyings = new List<Buying>();
            //goto bl&dal to get data...
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(1, "milk", new Category(1, "food")),7,new DateTime()));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(2, "milki", new Category(1, "food")), 4, new DateTime()));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(3, "bread", new Category(1, "food")), 10, new DateTime()));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(4, "mei-eden", new Category(1, "food")), 6, new DateTime()));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(5, "milk", new Category(1, "food")), 7, new DateTime()));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(6, "milki", new Category(1, "food")), 4, new DateTime()));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(7, "bread", new Category(1, "food")), 10, new DateTime()));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(8, "mei-eden", new Category(1, "food")), 6, new DateTime()));

            userlist = new List<User>();
            userlist.Add(new User(1, "avraham"));
            userlist.Add(new User(2, "sara"));
            userlist.Add(new User(3, "yonatan"));

            storelist = new List<Store>();
            storelist.Add(new Store(1, "rami-levi"));
            storelist.Add(new Store(2, "ace"));
            storelist.Add(new Store(3, "begood"));

            productlist = new List<Product>();
            productlist.Add(new Product(1, "milk", new Category(1, "food")));
            productlist.Add(new Product(2, "milki", new Category(1, "food")));
            productlist.Add(new Product(3, "bread", new Category(1, "food")));
            productlist.Add(new Product(4, "mei-eden", new Category(1, "food")));
            productlist.Add(new Product(5, "milk", new Category(1, "food")));
            productlist.Add(new Product(6, "milki", new Category(1, "food")));
            productlist.Add(new Product(7, "bread", new Category(1, "food")));
            productlist.Add(new Product(8, "mei-eden", new Category(1, "food")));

        }
    }

}
