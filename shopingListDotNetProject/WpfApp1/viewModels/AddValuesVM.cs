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
using System.Windows.Forms;

namespace PL.viewModels
{
    class AddValuesVM:IVM
    {
        
        MainWindow Main;
        AddValuesUC AddValuesUC;
        string chosenFile = "";

        public AddCategoryAction AddCategoryAction { get; set; }
        public AddProductAction AddProductAction { get; set; }
        public AddStoreAction AddStoreAction { get; set; }
        public AddUserAction AddUserAction { get; set; }
        public AddBuyingAction AddBuyingAction { get; set; }
        public AddPictureAction AddPictureAction { get; set; }
        public AddValuesVM(MainWindow main)
        {
            Main = main;
            Model = new BuyingModel();
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

            AddPictureAction = new AddPictureAction();
            AddPictureAction.AddPictureClicked += AddPictureAction_AddPictureClicked;

            AddValuesUC.choosePicture += AddValuesUC_choosePicture;
        }

        private void AddPictureAction_AddPictureClicked(Product obj)
        {
            obj.ImagePath = chosenFile;
            Model.Update(obj);
        }

        private void AddValuesUC_choosePicture()
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                chosenFile= openFileDialog.FileName;
                AddValuesUC.PicturePathTB.Text = chosenFile;
            }
        }

        //on pressing on "הוסף לקטלוג"
        private void AddProductAction_AddProductClicked(Product obj)
        {
            Model.Add(obj);
            AddValuesUC.ProductNameTB.Text = "";
            AddValuesUC.CategoryCB.SelectedValue = null;
        }

        //on pressing on "הוסף קטגוריה"
        private void AddAction_AddCategoryClicked(Category obj)
        {
            Model.Add(obj);
            AddValuesUC.CategoryNameTB.Text = "";
        }

        //on pressing on "הוסף מוצר"
        private void AddBuyingAction_AddBuyingClicked(Buying obj)
        {
            Model.Add(obj);
            AddValuesUC.PriceTB.Text = "";
            AddValuesUC.AmountTB.Text = "";
            AddValuesUC.ProductCB.SelectedValue = null;
            AddValuesUC.StoreCB.SelectedValue = null;
            AddValuesUC.UserCB.SelectedValue = null;
            AddValuesUC.BuyingDateDatePicker.SelectedDate = null;
        }

        private void AddStoreAction_AddStoreClicked(Store obj)
        {
            Model.Add(obj);
            AddValuesUC.StoreNameTB.Text = "";
        }

        private void AddUserAction_AddUserClicked(User obj)
        {
            Model.Add(obj);
            AddValuesUC.UserNameTB.Text = "";
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
