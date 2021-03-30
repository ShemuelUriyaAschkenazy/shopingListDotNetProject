
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.models
{
    public class BuyingModel
    {
        BLAddingVal BLAddingVal;
        public List<Buying> buyings { get; set; }
        public List<Buying> RecentBuyings { get; set; }
        public List<User> userlist { get; set; }
        public List<Store> storelist { get; set; }
        public List<Product> productlist { get; set; }
        public List<Category> categorylist { get; set; }

        public event Action<Category> CategoryListChangedEvent;
        public event Action<Product> ProductListChangedEvent;
        public event Action<Store> StoreListChangedEvent;
        public event Action<User> UserListChangedEvent;
        public event Action<Buying> BuyingsListChangedEvent;

        public BuyingModel()
        {
           
            BLAddingVal = new BLAddingVal();

            buyings = BLAddingVal.GetAllBuyings();

            RecentBuyings = BLAddingVal.GetRecentBuyings();

            userlist = BLAddingVal.GetAllUsers();

            storelist = BLAddingVal.GetAllStores();

            productlist = BLAddingVal.GetAllProducts();

            categorylist = BLAddingVal.GetAllCategories();
        }



        public void Add(Product obj)
        {
            Product p = BLAddingVal.Add(obj);
            productlist.Add(p);
            if (ProductListChangedEvent != null) ProductListChangedEvent(p);

        }

        public void Add(Category obj)
        {
            Category c = BLAddingVal.Add(obj);
            categorylist.Add(c);
            if (CategoryListChangedEvent != null) CategoryListChangedEvent(c);
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
