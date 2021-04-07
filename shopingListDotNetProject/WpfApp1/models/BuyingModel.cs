
using BE;
using BLL;
using BLL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.models
{
    public class BuyingModel:IModel
    {
        Queries queries = new BLL2.Queries();
        DataAnalysis dataAnalysis = new DataAnalysis();
        public double[] getDailyProductPurchases(int productId, int year, int month)
        {
            return queries.getDailyProductPurchases(productId,year,month);
        }
        public double[] getAnnualProductPurchases(int productId, int year1, int year2)
        {
            return queries.getAnnualProductPurchases(productId, year1, year2);
        }
        public double[] getMonthlyProductPurchases(int productId, int year)
        {
            return queries.getMonthlyProductPurchases(productId, year);
        }

        public float getProbability(string product1,string product2)
        {
            return dataAnalysis.getProbability(product1, product2);
        }

    }

}
