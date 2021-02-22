using BE;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace PL.viewModels
{
    public class IVM
    {
        public ObservableCollection<Buying> buyingList;
        public ObservableCollection<User> userlist;
        public ObservableCollection<Store> storelist;
        public ObservableCollection<Product> productlist;
    }
}