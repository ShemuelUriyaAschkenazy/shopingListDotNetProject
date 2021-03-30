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
    class AddValuesVM:IVM
    {
        BuyingModel Model;
        MainWindow Main;
        AddValuesUC AddValuesUC;

        public AddCategoryAction AddCategoryAction { get; set; }
        public AddProductAction AddProductAction { get; set; }
        public AddStoreAction AddStoreAction { get; set; }
        public AddUserAction AddUserAction { get; set; }
        public AddBuyingAction AddBuyingAction { get; set; }
        public AddValuesVM(MainWindow main)
        {
            Main = main;
            Model = new BuyingModel();
            buyinglist = new ObservableCollection<Buying>(Model.buyings);
            userlist = new ObservableCollection<User>(Model.userlist);
            storelist = new ObservableCollection<Store>(Model.storelist);
            productlist = new ObservableCollection<Product>(Model.productlist);
            categorylist = new ObservableCollection<Category>(Model.categorylist);
            AddValuesUC = main.centerOfPageGrid.GetChildOfType<AddValuesUC>();

            AddCategoryAction = new AddCategoryAction();
            AddCategoryAction.AddCategoryClicked += AddAction_AddCategoryClicked;

            AddProductAction = new AddProductAction();
            AddProductAction.AddProductClicked += AddProductAction_AddProductClicked;

            AddUserAction = new AddUserAction();
            AddUserAction.AddUserClicked += AddUserAction_AddUserClicked;

            AddStoreAction = new AddStoreAction();
            AddStoreAction.AddStoreClicked += AddStoreAction_AddStoreClicked;

            AddBuyingAction = new AddBuyingAction();
            AddBuyingAction.AddBuyingClicked += AddBuyingAction_AddBuyingClicked;

            Model.CategoryListChangedEvent += Model_CategoryListChangedEvent;
            Model.ProductListChangedEvent += Model_ProductListChangedEvent;
            Model.BuyingsListChangedEvent += Model_BuyingsListChangedEvent;
            Model.StoreListChangedEvent += Model_StoreListChangedEvent;
            Model.UserListChangedEvent += Model_UserListChangedEvent;
        }

        private void Model_UserListChangedEvent(User obj)
        {
            userlist.Add(obj);
            AddValuesUC.UserNameTB.Text = "";
        }

        private void Model_StoreListChangedEvent(Store obj)
        {
            storelist.Add(obj);
            AddValuesUC.StoreNameTB.Text = "";
        }

        private void Model_BuyingsListChangedEvent(Buying obj)
        {
            buyinglist.Add(obj);
            
        }

        private void Model_ProductListChangedEvent(Product obj)
        {
            productlist.Add(obj);
            AddValuesUC.ProductNameTB.Text = "";
            AddValuesUC.CategoryCB.SelectedItem = null;

        }

        private void Model_CategoryListChangedEvent(Category obj)
        {
            categorylist.Add(obj);
            AddValuesUC.CategoryNameTB.Text = "";
        }
        
        //on pressing on "הוסף לקטלוג"
        private void AddProductAction_AddProductClicked(Product obj)
        {
            Model.Add(obj);
        }

        //on pressing on "הוסף קטגוריה"
        private void AddAction_AddCategoryClicked(Category obj)
        {
            Model.Add(obj);
        }

        //on pressing on "הוסף מוצר"
        private void AddBuyingAction_AddBuyingClicked(Buying obj)
        {
            Model.Add(obj);
        }

        private void AddStoreAction_AddStoreClicked(Store obj)
        {
            Model.Add(obj);
        }

        private void AddUserAction_AddUserClicked(User obj)
        {
            Model.Add(obj);
        }





    }
}
