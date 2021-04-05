
using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.models
{
    public class BuyingModel:IModel
    {
        BLL2.Queries queries = new BLL2.Queries();
        public double[] getDailyProductPurchases(int productId, int year, int month)
        {
            return queries.getDailyProductPurchases(productId,year,month);
        }


    }

}
