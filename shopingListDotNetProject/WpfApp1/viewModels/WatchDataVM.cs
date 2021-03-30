using BE;
using PL.models;
using PL.userControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.viewModels
{
    public class WatchDataVM : IVM
    {
        BuyingModel Model;
        WatchDataUC WatchDataUC;


        public WatchDataVM(MainWindow main)
        {
            main.DataContext = this;
            Model = new BuyingModel();
            buyinglist = new ObservableCollection<Buying>(Model.buyings);
            userlist = new ObservableCollection<User>(Model.userlist);
            storelist = new ObservableCollection<Store>(Model.storelist);
            productlist = new ObservableCollection<Product>(Model.productlist);
            categorylist = new ObservableCollection<Category>(Model.categorylist);
            WatchDataUC = main.centerOfPageGrid.GetChildOfType<WatchDataUC>();

            WatchDataUC.StoreColumn.ItemsSource = storelist;
            WatchDataUC.UserColumn.ItemsSource = userlist;
            WatchDataUC.ProductColumn.ItemsSource = productlist;





            Model.CategoryListChangedEvent += Model_CategoryListChangedEvent;
            Model.ProductListChangedEvent += Model_ProductListChangedEvent;
            Model.BuyingsListChangedEvent += Model_BuyingsListChangedEvent;
            Model.StoreListChangedEvent += Model_StoreListChangedEvent;
            Model.UserListChangedEvent += Model_UserListChangedEvent;
        }

        private void Model_UserListChangedEvent(User obj)
        {
            userlist.Add(obj);
        }

        private void Model_StoreListChangedEvent(Store obj)
        {
            storelist.Add(obj);
        }

        private void Model_BuyingsListChangedEvent(Buying obj)
        {
            buyinglist.Add(obj);
        }

        private void Model_ProductListChangedEvent(Product obj)
        {
            productlist.Add(obj);
        }

        private void Model_CategoryListChangedEvent(Category obj)
        {
            categorylist.Add(obj);
        }

    }

}

