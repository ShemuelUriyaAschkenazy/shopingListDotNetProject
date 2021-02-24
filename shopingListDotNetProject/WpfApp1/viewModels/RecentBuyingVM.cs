using BE;
using PL.commands;
using PL.commands.PL.commands;
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
    class RecentBuyingVM : IVM
    {
        recentBuyingModel Model;
        RecentBuyingUC RecentBuyingUC;
        public SaveAction SaveAction { get; set; }


        public RecentBuyingVM(MainWindow main)
        {
            main.DataContext = this;
            Model = new recentBuyingModel();
            buyinglist = new ObservableCollection<Buying>(Model.buyings);
            userlist = new ObservableCollection<User>(Model.userlist);
            storelist = new ObservableCollection<Store>(Model.storelist);
            productlist = new ObservableCollection<Product>(Model.productlist);
            categorylist = new ObservableCollection<Category>(Model.categorylist);
            RecentBuyingUC = main.centerOfPageGrid.GetChildOfType<RecentBuyingUC>();

            RecentBuyingUC.StoreColumn.ItemsSource = storelist;
            RecentBuyingUC.UserColumn.ItemsSource = userlist;
            RecentBuyingUC.ProductColumn.ItemsSource = productlist;





            Model.CategoryListChangedEvent += Model_CategoryListChangedEvent;
            Model.ProductListChangedEvent += Model_ProductListChangedEvent;
            Model.BuyingsListChangedEvent += Model_BuyingsListChangedEvent;
            Model.StoreListChangedEvent += Model_StoreListChangedEvent;
            Model.UserListChangedEvent += Model_UserListChangedEvent;

            SaveAction = new SaveAction();
            SaveAction.SaveButtonClicked += SaveAction_SaveButtonClicked;
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

        private void SaveAction_SaveButtonClicked()
        {
            //Model.Add(IEnumerable<Buying>);
        }





    }
}
