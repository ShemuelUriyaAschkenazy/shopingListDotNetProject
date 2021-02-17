using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace PL.viewModels
{
    public class IVM<T>
    {
        public ObservableCollection<T> coll;
    }
}