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
    public class AnalyzeBuyingVM:IVM
    {
        BuyingModel Model;
        AnalyzeBuyingUC AnalyzeBuyingUC;
        public AnalyzeBuyingVM(MainWindow main)
        {


            main.DataContext = this;
            Model = new BuyingModel();
            buyinglist = new ObservableCollection<Buying>(Model.buyings);
            userlist = new ObservableCollection<User>(Model.userlist);
            storelist = new ObservableCollection<Store>(Model.storelist);
            productlist = new ObservableCollection<Product>(Model.productlist);
            categorylist = new ObservableCollection<Category>(Model.categorylist);
            AnalyzeBuyingUC = main.centerOfPageGrid.GetChildOfType<AnalyzeBuyingUC>();

            AnalyzeBuyingUC.productsforselect.ItemsSource = productlist;



            AnalyzeBuyingUC.ShowButtonClickedEvent += Active_ShowButtonClickedEvent;

        }

        private void Active_ShowButtonClickedEvent()
        {

            string product1 = AnalyzeBuyingUC.productname.Text.ToString();
            string product2 = AnalyzeBuyingUC.productname1.Text.ToString();

            AnalyzeBuyingUC.probability.Text = Model.getProbability(product1, product2).ToString();


        }
    }
}
