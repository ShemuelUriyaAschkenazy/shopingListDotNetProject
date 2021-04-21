
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.models
{
    public class RecentBuyingModel : IModel
    {
        public List<Buying> RecentBuyings { get; set; }
        public event Action<int> progressChanged;


        public RecentBuyingModel()
        {
            RecentBuyings = new List<Buying>();
            BLAddingVal.progressChanged += BLAddingVal_progressChanged;
        }

        private void BLAddingVal_progressChanged(int obj)
        {
            progressChanged?.Invoke(obj);
        }

    public List<Buying> retrieveRecentBuyings()
        {
            RecentBuyings= BLAddingVal.GetRecentBuyings();
            return RecentBuyings;
        }




        public void Add(List<Buying> list)
        {
            BLAddingVal.Add(list);
        }
    }

}
