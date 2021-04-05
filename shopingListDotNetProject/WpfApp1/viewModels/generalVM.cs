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
using System.Windows.Controls;
using System.Windows.Input;

namespace PL.viewModels
{
    public class GeneralVM: IVM
    {
        MainWindow Main;

        
     
        public GeneralVM(MainWindow main)
        {
            Model = new BuyingModel();
            //this.buyinglist = new ObservableCollection<Buying>();
            //userlist = new ObservableCollection<User>(Model.userlist);
            //storelist = new ObservableCollection<Store>(Model.storelist);
            //productlist = new ObservableCollection<Product>(Model.productlist);
            //categorylist = new ObservableCollection<Category>(Model.categorylist);
            
            this.Main = main;
            main.TopMenu.OpenRecommendationPanelClickedEvent += TopMenu_OpenRecommendationPanelClickedEvent;
            main.TopMenu.OpenAddPanelClickedEvent += TopMenu_OpenAddPanelClickedEvent;
            main.TopMenu.OpenWatchPanelClickedEvent += TopMenu_OpenWatchPanelClickedEvent;



            //main.AddDataMenu.ImportDataEvent += AddDataMenu_ImportDataEvent;
            //main.AddDataMenu.AddValuesEvent += AddDataMenu_AddValuesEvent;
        }

        private void TopMenu_OpenWatchPanelClickedEvent()
        {
            WatchPanelLeftMenuUC WatchPanelLeftMenuUC = new WatchPanelLeftMenuUC();
            WatchPanelLeftMenuUC.HistoryButtonClickedEvent += WatchPanelLeftMenuUC_HistoryButtonClickedEvent;
            WatchPanelLeftMenuUC.DataSectionsButtonClickedEvent += WatchPanelLeftMenuUC_DataSectionsButtonClickedEvent;
            Main.LeftMenuesGrid.Children.Clear();
            Main.LeftMenuesGrid.Children.Add(WatchPanelLeftMenuUC);
        }

       

        private void TopMenu_OpenAddPanelClickedEvent()
        {
            AddDataLeftMenuUC AddDataLeftMenuUC = new AddDataLeftMenuUC();
            AddDataLeftMenuUC.ImportDataEvent += AddDataMenu_ImportDataEvent;
            AddDataLeftMenuUC.AddValuesEvent += AddDataMenu_AddValuesEvent;
            Main.LeftMenuesGrid.Children.Clear();
            Main.LeftMenuesGrid.Children.Add(AddDataLeftMenuUC);
        }

        private void WatchPanelLeftMenuUC_HistoryButtonClickedEvent()
        {
            WatchDataUC uc = new WatchDataUC();
            Grid.SetRow(uc, 2);
            Main.centerOfPageGrid.Children.Clear();
            Main.centerOfPageGrid.Children.Add(uc);
            Main.CurrentVM = new WatchDataVM(Main);
        }

        private void WatchPanelLeftMenuUC_DataSectionsButtonClickedEvent()
        {
            DataSectionsUC uc = new DataSectionsUC();
            Grid.SetRow(uc, 2);
            Main.centerOfPageGrid.Children.Clear();
            Main.centerOfPageGrid.Children.Add(uc);
            Main.CurrentVM = new DataSectionsVM(Main, uc);
            Main.DataContext = Main.CurrentVM;
        }

        private void TopMenu_OpenRecommendationPanelClickedEvent()
        {
           // throw new NotImplementedException();
        }

        private void AddDataMenu_ImportDataEvent()
        {
            RecentBuyingUC uc = new RecentBuyingUC();
            Grid.SetRow(uc, 2);
            Main.centerOfPageGrid.Children.Clear();
            Main.centerOfPageGrid.Children.Add(uc);
            Main.CurrentVM = new RecentBuyingVM(Main);
        }

        private void AddDataMenu_AddValuesEvent()
        {
            AddValuesUC uc = new AddValuesUC();
            Main.centerOfPageGrid.Children.Clear();
            Main.centerOfPageGrid.Children.Add(uc);
            Main.CurrentVM = new AddValuesVM(Main);
            Main.DataContext = Main.CurrentVM;
        }





    }
}
