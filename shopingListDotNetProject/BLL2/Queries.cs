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
            List<Buying> relevantBuyings = buyings.Where(x => x.ProductId == productId && x.Date.Year>=fromYear && x.Date.Year<=untilYear).ToList();
            double[] annualPurchases = new double[(untilYear-fromYear) +1];

            foreach (var b in relevantBuyings)
            {

                annualPurchases[b.Date.Year - fromYear] += b.Amount;
            }
            return annualPurchases;
        }
        
        //calculate the daily amount of products that bought in the store 
        public double[] getDailyStorePurchases_PerOneProduct(int storeId, int year, int month)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Buying> relevantBuyings = buyings.Where(x => x.StoreId == storeId && x.Date.Year == year && x.Date.Month == month).ToList();

            int daysInMonth = DateTime.DaysInMonth(year, month);
            double[] dayPurchases = new double[daysInMonth];

            foreach (var b in relevantBuyings)
            {
                //we use -1 to produce zero-indexed array
                dayPurchases[b.Date.Day - 1] += b.Amount;
            }
            return dayPurchases;
        }

        //return the days you visit in the store 
        public double[] getDailyVisitsInStore(int storeId, int year, int month)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Buying> relevantBuyings = buyings.Where(x => x.StoreId == storeId && x.Date.Year == year && x.Date.Month == month).ToList();

            int daysInMonth = DateTime.DaysInMonth(year, month);
            double[] dayPurchases = new double[daysInMonth];

            foreach (var b in relevantBuyings)
            {
                //we use -1 to produce zero-indexed array
                dayPurchases[b.Date.Day - 1] = 1;
            }
            return dayPurchases;
        }

        //calculate the monthly amount of products that bought in the store 
        public double[] getMonthlyStorePurchases_PerOneProduct(int storeId, int year)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Buying> relevantBuyings = buyings.Where(x => x.StoreId == storeId).ToList();
            double[] monthPurchases = new double[12];

            foreach (var b in relevantBuyings)
            {
                //we use -1 to produce zero-indexed array
                monthPurchases[b.Date.Month - 1] += b.Amount;
            }
            return monthPurchases;
        }

        //return how many days in the month you visit in the store 
        public double[] getMonthlyVisitsInTheStore(int storeId, int year)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Buying> relevantBuyings = buyings.Where(x => x.StoreId == storeId).ToList();
            double[] monthPurchases = new double[12];

            bool[,] dayInMonth = new bool[12,31];
            foreach (var b in relevantBuyings)
            {

                //if the specific day in month is not seen yet, we add 1 (buying) to this day 
                if (dayInMonth[b.Date.Month - 1, b.Date.Day - 1] == false)
                {
                    monthPurchases[b.Date.Month - 1] += 1;
                    dayInMonth[b.Date.Month - 1, b.Date.Day - 1] = true;
                }
            }
            return monthPurchases;
        }

        //calculate the annual amount of products that bought in the store 
        public double[] getAnnualStorePurchases_PerOneProduct(int storeId, int fromYear, int untilYear)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Buying> relevantBuyings = buyings.Where(x => x.StoreId == storeId && x.Date.Year >= fromYear && x.Date.Year <= untilYear).ToList();
            double[] annualPurchases = new double[(untilYear - fromYear) + 1];

            List<DateTime> dateTimes = new List<DateTime>();
            foreach (var b in relevantBuyings)
            {
                bool flag = false;
                for (int i=0; i<dateTimes.Count(); i++) { if (b.Date.DateEquals(b.Date)) flag = true; }
                if (!flag) //date not in datetimes 
                {
                    annualPurchases[b.Date.Year - fromYear] += b.Amount;
                }
            }
            return annualPurchases;
        }

        //return how many days in the month you visit in the store 
        public double[] getAnnualVisitsInTheStore(int storeId, int fromYear, int untilYear)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Buying> relevantBuyings = buyings.Where(x => x.StoreId == storeId && x.Date.Year >= fromYear && x.Date.Year <= untilYear).ToList();
            double[] annualPurchases = new double[(untilYear - fromYear) + 1];

            foreach (var b in relevantBuyings)
            {

                annualPurchases[b.Date.Year - fromYear] += b.Amount;
            }
            return annualPurchases;
        }

    }
}
