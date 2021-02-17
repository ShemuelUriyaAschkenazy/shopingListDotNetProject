
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

        }
    }

}
