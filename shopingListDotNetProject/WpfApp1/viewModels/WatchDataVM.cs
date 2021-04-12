using BE;
using PL.models;
using PL.userControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PL.viewModels
{
    public class WatchDataVM : IVM, INotifyPropertyChanged
    {
        WatchDataUC watchDataUC;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public int ProductId {get; set;}

        private string _ProductImagePath;
        public string ProductImagePath {
            get { return _ProductImagePath; }
            set
            {
                _ProductImagePath = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ProductImagePath)));
            }
        }

        public WatchDataVM(MainWindow main)
        {
            main.DataContext = this;
            Model = new BuyingModel();
            ProductImagePath = "C:\\Users\\uriya\\Downloads\\milk.jpg";

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

            watchDataUC = main.centerOfPageGrid.GetChildOfType<WatchDataUC>();
            watchDataUC.StoreColumn.ItemsSource = storelist;
            watchDataUC.UserColumn.ItemsSource = userlist;
            watchDataUC.ProductColumn.ItemsSource = productlist;

            watchDataUC.RowSelectionChanged += WatchDataUC_RowSelectionChanged;

            watchDataUC.DataContext = main.DataContext;
        }

        private void WatchDataUC_RowSelectionChanged()
        {
            watchDataUC.DataContext = this;
            //WatchDataUC.BuyingsDataGrid.RowDetailsTemplate.
            if (watchDataUC.BuyingsDataGrid.SelectedItem!=null)
            ProductImagePath = Model.productlist.Find(x=>x.ProductId==((Buying)watchDataUC.BuyingsDataGrid.SelectedItem).ProductId).ImagePath;
            //ProductImagePath= "C:\\Users\\uriya\\Downloads\\milk.jpg";
            //patternImage = new BitmapImage(new Uri("C:\\Users\\uriya\\Downloads\\milk.jpg"));
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

