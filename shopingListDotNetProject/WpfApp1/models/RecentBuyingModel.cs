
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.models
{
    public class RecentBuyingModel : IModel
    {
        public List<Buying> RecentBuyings { get; set; }
        public RecentBuyingModel()
        {
            RecentBuyings = BLAddingVal.GetRecentBuyings();
        }

        public void Add(List<Buying> list)
        {
            BLAddingVal.Add(list);
        }
    }

}
