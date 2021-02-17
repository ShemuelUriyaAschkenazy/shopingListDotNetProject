using BE;
using PL.models;
using PL.userControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PL.viewModels
{
    public class generalVM: IVM <Buying>  
    {
        recentBuyingModel model;
        MainWindow main;
        ObservableCollection<User> userlist;
        ObservableCollection<Store> storelist;


        public generalVM(MainWindow main)
        {
            model = new recentBuyingModel();

            this.coll = new ObservableCollection<Buying>(model.buyings);
            this.coll.CollectionChanged += RecentBuying_CollectionChanged;
            userlist = new ObservableCollection<User>(model.userlist);
            storelist = new ObservableCollection<Store>(model.storelist);


            this.main = main;
            main.AddDataMenu.ImportDataEvent += AddDataMenu_ImportDataEvent;
            
            
        }

        private void AddDataMenu_ImportDataEvent()
        {
            recentBuyingUC uc = new recentBuyingUC();
            uc.recentBuyingsDataGrid.ItemsSource = coll;
            uc.UserColumn.ItemsSource = userlist;
            uc.StoreColumn.ItemsSource = storelist;
            Grid.SetRow(uc, 2);
            main.centerOfPageGrid.Children.Add(uc);
            
        }

        private void RecentBuying_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //עדכוו הנתונים במודל
        }

        
    }
}
