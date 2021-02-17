
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

        public recentBuyingModel()
        {
            buyings = new List<Buying>();
            //goto bl&dal to get data...
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(1, "milk", new Categoty(1, "food")),7));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(1, "milki", new Categoty(1, "food")), 4));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(1, "bread", new Categoty(1, "food")), 10));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(1, "mei-eden", new Categoty(1, "food")), 6));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(1, "milk", new Categoty(1, "food")), 7));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(1, "milki", new Categoty(1, "food")), 4));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(1, "bread", new Categoty(1, "food")), 10));
            buyings.Add(new Buying(new Store(1, "rami-levi"), new Product(1, "mei-eden", new Categoty(1, "food")), 6));

            userlist = new List<User>();
            userlist.Add(new User(1, "avraham"));
            userlist.Add(new User(2, "sara"));
            userlist.Add(new User(3, "yonatan"));

            storelist = new List<Store>();
            storelist.Add(new Store(1, "rami-levi"));
            storelist.Add(new Store(2, "ace"));
            storelist.Add(new Store(3, "begood"));

        }
    }

}
