using BE;
using PL.commands;
using PL.models;
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
        recentBuyingModel model;
        MainWindow main;

        public AddCategoryAction AddAction { get; set; }



        public AddValuesVM(MainWindow main)
        {
            model = new recentBuyingModel();
            this.buyingList = new ObservableCollection<Buying>(model.buyings);
            userlist = new ObservableCollection<User>(model.userlist);
            storelist = new ObservableCollection<Store>(model.storelist);
            productlist = new ObservableCollection<Product>(model.productlist);


            this.main = main;
         

            AddAction = new AddCategoryAction();
            AddAction.AddCategoryClicked += AddAction_AddCategoryClicked;


        }

        private void AddAction_AddCategoryClicked(Category obj)
        {
            BLL.AddingValues class1 = new BLL.AddingValues();
            class1.AddCategoty(obj);
        }

        





    }
}
