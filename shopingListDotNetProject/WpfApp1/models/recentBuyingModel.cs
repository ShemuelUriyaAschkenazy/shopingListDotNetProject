
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.models
{
    public class recentBuyingModel
    {
        BLAddingVal BLAddingVal;
        public List<Buying> buyings { get; set; }
       public List<User> userlist { get; set; }
        public List<Store> storelist { get; set; }

        public List<Product> productlist { get; set; }
        public List<Category> categorylist { get; set; }

        public event Action<Category> CategoryListChangedEvent;
        public event Action<Product> ProductListChangedEvent;
        public event Action<Store> StoreListChangedEvent;
        public event Action<User> UserListChangedEvent;
        public event Action<Buying> BuyingsListChangedEvent;

        public recentBuyingModel()
        {
            BLAddingVal = new BLAddingVal();

            buyings = new List<Buying>();
            //goto bl&dal to get data...
            buyings.Add(new Buying(1, 1, 1,3, 1,1,new DateTime()));
            buyings.Add(new Buying(2, 1, 1, 3, 1, 2, new DateTime()));
            buyings.Add(new Buying(3, 1, 1, 3, 1, 2, new DateTime()));
            buyings.Add(new Buying(4, 1, 1, 3, 1, 3, new DateTime()));
            buyings.Add(new Buying(5, 1, 1, 3, 1, 2, new DateTime()));
            buyings.Add(new Buying(6, 1, 1, 3, 1, 2, new DateTime()));


            userlist = new List<User>();
            userlist.Add(new User(1, "avraham"));
            userlist.Add(new User(2, "sara"));
            userlist.Add(new User(3, "yonatan"));

            storelist = new List<Store>();
            storelist.Add(new Store(1, "rami-levi"));
            storelist.Add(new Store(2, "ace"));
            storelist.Add(new Store(3, "begood"));

            productlist = new List<Product>();
            productlist.Add(new Product(1, "milk", 1));
            productlist.Add(new Product(2, "milki", 2));
            productlist.Add(new Product(3, "bread", 3));
            productlist.Add(new Product("mei-eden", 4));
            productlist.Add(new Product("milk", 5));
            productlist.Add(new Product("milki", 6));
            productlist.Add(new Product("bread", 1));
            productlist.Add(new Product("mei-eden", 1));

            categorylist = new List<Category>();
            categorylist.Add(new Category(1, "food"));
            categorylist.Add(new Category(2, "clothes"));
            categorylist.Add(new Category(3, "furniture"));
            categorylist.Add(new Category(4, "communication"));
        }

       

        public void Add(Product obj)
        {
            Product p = BLAddingVal.Add(obj);
            productlist.Add(p);
            if (ProductListChangedEvent!=null) ProductListChangedEvent(p);
            
        }

        public void Add(Category obj)
        {
            Category c = BLAddingVal.Add(obj);
            categorylist.Add(c);
            if (CategoryListChangedEvent != null)  CategoryListChangedEvent(c);
        }

        public void Add(Store obj)
        {
            Store s = BLAddingVal.Add(obj);
            storelist.Add(s);
            if (StoreListChangedEvent != null) StoreListChangedEvent(s);
        }

        public void Add(User obj)
        {
            User u = BLAddingVal.Add(obj);
            userlist.Add(u);
            if (UserListChangedEvent != null) UserListChangedEvent(u);
        }

        public void Add(Buying obj)
        {
            Buying b = BLAddingVal.Add(obj);
            buyings.Add(b);
            if (BuyingsListChangedEvent != null) BuyingsListChangedEvent(b);
        }
    }

}
