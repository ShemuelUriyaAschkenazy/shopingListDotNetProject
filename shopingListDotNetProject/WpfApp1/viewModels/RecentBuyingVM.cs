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
        RecentBuyingUC RecentBuyingUC;
        public SaveAction SaveAction { get; set; }
        public ObservableCollection<Buying> RecentBuyingList { get; set; }

        public RecentBuyingVM(MainWindow main)
        {


            main.DataContext = this;
            Model = new RecentBuyingModel();
            RecentBuyingList = new ObservableCollection<Buying>((Model as RecentBuyingModel).RecentBuyings);

            buyinglist = new ObservableCollection<Buying>(Model.buyings);
            userlist = new ObservableCollection<User>(Model.userlist);
            storelist = new ObservableCollection<Store>(Model.storelist);
            productlist = new ObservableCollection<Product>(Model.productlist);
            categorylist = new ObservableCollection<Category>(Model.categorylist);

            Model.CategoryListChangedEvent += Model_CategoryListChangedEvent;
            Model.ProductListChangedEvent += Model_ProductListChangedEvent;
            Model.BuyingsListChangedEvent += Model_BuyingsListChangedEvent;
            Model.StoreListChangedEvent += Model_StoreListChangedEvent;
            Model.UserListChangedEvent += Model_UserListChangedEvent;

            RecentBuyingUC = main.centerOfPageGrid.GetChildOfType<RecentBuyingUC>();
            RecentBuyingUC.StoreColumn.ItemsSource = storelist;
            RecentBuyingUC.UserColumn.ItemsSource = userlist;
            RecentBuyingUC.ProductColumn.ItemsSource = productlist;


            SaveAction = new SaveAction();
            SaveAction.SaveButtonClicked += SaveAction_SaveButtonClicked;
        }

        private void SaveAction_SaveButtonClicked()
        {
            (Model as RecentBuyingModel).Add(RecentBuyingList.ToList());
        }


        private void Model_UserListChangedEvent()
        {
            userlist.Clear();
            foreach (var u in Model.userlist)
            {
                userlist.Add(u);
            }
        }

        private void Model_StoreListChangedEvent()
        {
            storelist.Clear();
            foreach (var u in Model.storelist)
            {
                storelist.Add(u);
            }
        }

        private void Model_BuyingsListChangedEvent()
        {
            buyinglist.Clear();
            foreach (var obj in Model.buyings)
            {
                buyinglist.Add(obj);
            }
        }

        private void Model_ProductListChangedEvent()
        {
            productlist.Clear();
            foreach (var obj in Model.productlist)
            {
                productlist.Add(obj);
            }
        }

        private void Model_CategoryListChangedEvent()
        {
            categorylist.Clear();
            foreach (var obj in Model.categorylist)
            {
                categorylist.Add(obj);
            }
        }


    }
}
