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

        public BLAddingVal()
        {
            //var ensureDllIsCopied = new Google.Apis.Drive.v3.DriveService();
            dbAdapter = new DbAdapter();
            GoogleDriveAPI = new GoogleDriveAPI();

        }

        public void Save(Category category)
        {
            dbAdapter.Save(category);
        }

        public Category Add(Category obj)
        {
            obj.CategoryId = dbAdapter.GetMaxCategoryId() + 1;
            return dbAdapter.Add(obj);
        }

        public Product Add(Product obj)
        {
            obj.ProductId = dbAdapter.GetMaxProductId() + 1;
            return dbAdapter.Add(obj);
        }

        public User Add(User obj)
        {
            obj.UserId = dbAdapter.GetMaxUserId() + 1;
            return dbAdapter.Add(obj);
        }

        public Store Add(Store obj)
        {
            obj.StoreId = dbAdapter.GetMaxStoreId() + 1;
            return dbAdapter.Add(obj);
        }

     

        public Buying Add(Buying obj)
        {
            obj.BuyingId = dbAdapter.GetMaxBuyingId() + 1;
            return dbAdapter.Add(obj);
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
                RecentBuying.Add(new Buying(int.Parse(buyingString[0]), int.Parse(buyingString[1]), int.Parse(buyingString[2]), double.Parse(buyingString[3])));
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
