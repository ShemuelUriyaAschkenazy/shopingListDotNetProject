using BE;
using BLL.BE2;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL2
{
    public class Queries
    {
        DbAdapter dbAdapter;
        public Queries()
        {
            dbAdapter = new DbAdapter();
        }
        
        //return how much from a product, the user buys each period of time
        public double[] getDailyProductPurchases(int productId, int year, int month)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Buying> relevantBuyings = buyings.Where(x => x.ProductId == productId && x.Date.Year == year&& x.Date.Month==month).ToList();

            int daysInMonth = DateTime.DaysInMonth(year, month);
            double[] dayPurchases = new double[daysInMonth];
            
            foreach (var b in relevantBuyings)
            {
                //we use -1 to produce zero-indexed array
                dayPurchases[b.Date.Day - 1]+=b.Amount;
            }
            return dayPurchases;
        }

        public double[] getMonthlyProductPurchases(int productId, int year)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Buying> relevantBuyings = buyings.Where(x => x.ProductId == productId).ToList();
            double[] monthPurchases = new double[12];

            foreach (var b in relevantBuyings)
            {
                //we use -1 to produce zero-indexed array
                monthPurchases[b.Date.Month -1] += b.Amount;
            }
            return monthPurchases;
        }

        public double[] getAnnualProductPurchases(int productId, int fromYear, int untilYear)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Buying> relevantBuyings = buyings.Where(x => x.ProductId == productId).ToList();
            double[] annualPurchases = new double[(untilYear-fromYear) +1];

            foreach (var b in relevantBuyings)
            {

                annualPurchases[b.Date.Year - fromYear] += b.Amount;
            }
            return annualPurchases;
        }




    }
}
