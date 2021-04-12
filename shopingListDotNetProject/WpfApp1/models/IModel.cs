using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.models
{
    public abstract class IModel
    {
        public BLAddingVal BLAddingVal;

        public List<Buying> buyings { get; set; }
        public List<User> userlist { get; set; }
        public List<Store> storelist { get; set; }
        public List<Product> productlist { get; set; }
        public List<Category> categorylist { get; set; }

        public event Action CategoryListChangedEvent;
        public event Action ProductListChangedEvent;
        public event Action  StoreListChangedEvent;
        public event Action  UserListChangedEvent;
        public event Action BuyingsListChangedEvent;

        public IModel()
        {
            BLAddingVal = new BLAddingVal();

            buyings = BLAddingVal.GetAllBuyings();

            userlist = BLAddingVal.GetAllUsers();

            storelist = BLAddingVal.GetAllStores();

            productlist = BLAddingVal.GetAllProducts();

            categorylist = BLAddingVal.GetAllCategories();

            BLAddingVal.BuyingListChangedEvent += BLAddingVal_BuyingListChangedEvent;
            BLAddingVal.CategoryListChangedEvent += BLAddingVal_CategoryListChangedEvent;
            BLAddingVal.UserListChangedEvent += BLAddingVal_UserListChangedEvent;
            BLAddingVal.StoreListChangedEvent += BLAddingVal_StoreListChangedEvent;
            BLAddingVal.ProductListChangedEvent += BLAddingVal_ProductListChangedEvent;
        }

        private void BLAddingVal_ProductListChangedEvent()
        {
            productlist = BLAddingVal.GetAllProducts();
            if (ProductListChangedEvent != null) ProductListChangedEvent();
        }

        private void BLAddingVal_StoreListChangedEvent()
        {
            storelist = BLAddingVal.GetAllStores();
            if (StoreListChangedEvent != null) StoreListChangedEvent();
        }

        private void BLAddingVal_UserListChangedEvent()
        {
            userlist = BLAddingVal.GetAllUsers();
            if (UserListChangedEvent != null) UserListChangedEvent();
        }

        private void BLAddingVal_CategoryListChangedEvent()
        {
            categorylist = BLAddingVal.GetAllCategories();
            if (CategoryListChangedEvent != null) CategoryListChangedEvent();
        }

        private void BLAddingVal_BuyingListChangedEvent()
        {
            buyings = BLAddingVal.GetAllBuyings();
            if (BuyingsListChangedEvent != null) BuyingsListChangedEvent();
        }

        public void Add(Product obj)
        {
            BLAddingVal.Add(obj);
        }

        public void Add(Category obj)
        {
            BLAddingVal.Add(obj);
        }

        public void Add(Store obj)
        {
            BLAddingVal.Add(obj);
        }

        public void Add(User obj)
        {
           BLAddingVal.Add(obj);            
        }

        public void Add(Buying obj)
        {
            BLAddingVal.Add(obj);
        }

        public void Update(Product obj)
        {
            BLAddingVal.Update(obj);
        }

    }
}
