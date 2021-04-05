using BE;
using PL.models;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace PL.viewModels
{
    public abstract class IVM
    {
        public IModel Model { get; set; }
        public ObservableCollection<Buying> buyinglist { get; set; }
        public ObservableCollection<User> userlist { get; set; }
        public ObservableCollection<Store> storelist { get; set; }
        public ObservableCollection<Product> productlist { get; set; }
        public ObservableCollection<Category> categorylist { get; set; }


    }



}