using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BLL
{
    public class BLAddingVal
    {
        private DbAdapter dbAdapter;
        private GoogleDriveAPI GoogleDriveAPI;

        public event Action BuyingListChangedEvent;
        public event Action CategoryListChangedEvent;
        public event Action UserListChangedEvent;
        public event Action StoreListChangedEvent;
        public event Action ProductListChangedEvent;
        public event Action<int> progressChanged;


        public BLAddingVal()
        {
            //var ensureDllIsCopied = new Google.Apis.Drive.v3.DriveService();
            dbAdapter = new DbAdapter();
            GoogleDriveAPI = new GoogleDriveAPI();
            GoogleDriveAPI.progressChanged += GoogleDriveAPI_progressChanged;
        }

        private void GoogleDriveAPI_progressChanged(int obj)
        {
            progressChanged?.Invoke(obj);
        }

        public void Save(Category category)
        {
            dbAdapter.Save(category);
        }

        public void Add(Category obj)
        {
            obj.CategoryId = dbAdapter.GetMaxCategoryId() + 1;
            dbAdapter.Add(obj);
            if (CategoryListChangedEvent != null) CategoryListChangedEvent();


        }

        public void Add(Product obj)
        {
            obj.ProductId = dbAdapter.GetMaxProductId() + 1;
            dbAdapter.Add(obj);
            if (ProductListChangedEvent != null) ProductListChangedEvent();

        }

        public void Add(User obj)
        {
            obj.UserId = dbAdapter.GetMaxUserId() + 1;
            dbAdapter.Add(obj);
            if (UserListChangedEvent != null) UserListChangedEvent();

        }

        public void Add(Store obj)
        {
            obj.StoreId = dbAdapter.GetMaxStoreId() + 1;
            dbAdapter.Add(obj);
            if (StoreListChangedEvent != null) StoreListChangedEvent();

        }



        public void Add(Buying obj)
        {
            obj.BuyingId = dbAdapter.GetMaxBuyingId() + 1;
            dbAdapter.Add(obj);
            BuyingListChangedEvent?.Invoke();

        }

        public void Add(List<Buying> list)
        {
            int lastId = dbAdapter.GetMaxBuyingId();
            List<Buying> SavedList = new List<Buying>();
            foreach (var obj in list)
            {
                obj.BuyingId = ++lastId;
                SavedList.Add(dbAdapter.Add(obj));
            }
            if (BuyingListChangedEvent != null) BuyingListChangedEvent();
        }

        public void Update (Product obj)
        {
            dbAdapter.UpdateProduct(obj);
            if (ProductListChangedEvent != null) ProductListChangedEvent();
        }
        public List<Buying> GetAllBuyings()
        {
            return dbAdapter.GetAllBuyings();
        }

        public List<Buying> GetRecentBuyings()
        {
           List<Buying> RecentBuying = new List<Buying>();
           List<string> list = GoogleDriveAPI.DownloadFiles();
            foreach (string s in list)
            {
                var buyingString= s.Split(',');
                RecentBuying.Add(new Buying(int.Parse(buyingString[1]), int.Parse(buyingString[0]), double.Parse(buyingString[3]), int.Parse(buyingString[2]),1, DateTime.Parse(buyingString[4])));
        }
            return RecentBuying;
        }

        public List<Store> GetAllStores()
        {
            return dbAdapter.GetAllStores();
        }

        public List<Category> GetAllCategories()
        {
            return dbAdapter.GetAllCategories();
        }

        public List<Product> GetAllProducts()
        {
            return dbAdapter.GetAllProducts();
        }

        public List<User> GetAllUsers()
        {
            return dbAdapter.GetAllUsers();
        }

        
    }
}
