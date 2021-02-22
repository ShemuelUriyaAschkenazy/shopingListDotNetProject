using BE;
using BLL;
using PL.commands;
using PL.models;
using PL.userControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PL.viewModels
{
    public class generalVM: IVM
    {
        recentBuyingModel model;
        MainWindow main;
     
        public SaveAction SaveAction { get; set; }
        


        public generalVM(MainWindow main)
        {
            model = new recentBuyingModel();
            this.buyingList = new ObservableCollection<Buying>(model.buyings);
            userlist = new ObservableCollection<User>(model.userlist);
            storelist = new ObservableCollection<Store>(model.storelist);
            productlist = new ObservableCollection<Product>(model.productlist);


            this.main = main;
            main.AddDataMenu.ImportDataEvent += AddDataMenu_ImportDataEvent;
            main.AddDataMenu.AddValuesEvent += AddDataMenu_AddValuesEvent;

            SaveAction = new SaveAction();
            SaveAction.SaveButtonClicked += SaveAction_SaveButtonClicked;

      
        }

       

        private void SaveAction_SaveButtonClicked()
        {
            model.buyings.AddRange(buyingList);
            MessageBox.Show(model.buyings.Count.ToString());
            //Class1 class1 = new Class1();
            //class1.Save(new Category(1, "food"));
        }

        private void AddDataMenu_ImportDataEvent()
        {
            recentBuyingUC uc = new recentBuyingUC();
            uc.recentBuyingsDataGrid.ItemsSource = buyingList;
            uc.UserColumn.ItemsSource = userlist;
            uc.StoreColumn.ItemsSource = storelist;
            uc.ProductColumn.ItemsSource = productlist;
            Grid.SetRow(uc, 2);
            main.centerOfPageGrid.Children.Clear();
            main.centerOfPageGrid.Children.Add(uc);
        }

        private void AddDataMenu_AddValuesEvent()
        {
            AddNewUC uc = new AddNewUC();
            main.centerOfPageGrid.Children.Clear();
            main.centerOfPageGrid.Children.Add(uc);
            main.CurrentVM = new AddValuesVM(main);
            main.DataContext = main.CurrentVM;
        }





    }
}
