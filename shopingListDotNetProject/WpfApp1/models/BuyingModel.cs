
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

        public float getProbability(int productId1,int productId2)
        {
            return dataAnalysis.getProbability(productId1, productId2);
        }

        public double[] getDailyStorePurchases_PerOneProduct(int storeId, int year, int month)
        {
            return queries.getDailyStorePurchases_PerOneProduct(storeId, year, month);
        }

        public double[] getDailyVisitsInStore(int storeId, int year, int month)
        {
            return queries.getDailyVisitsInStore(storeId, year, month);
           }

    
        public double[] getMonthlyStorePurchases_PerOneProduct(int storeId, int year)
        {
            return queries.getMonthlyStorePurchases_PerOneProduct(storeId, year);
        }

        
        public double[] getMonthlyVisitsInTheStore(int storeId, int year)
        {
            return queries.getMonthlyVisitsInTheStore(storeId,year);
        }

        //calculate the annual amount of products that bought in the store 
        public double[] getAnnualStorePurchases_PerOneProduct(int storeId, int fromYear, int untilYear)
        {
            return queries.getAnnualStorePurchases_PerOneProduct(storeId, fromYear,untilYear);
        }

        //return how many days in the year you visit in the store 
        public double[] getAnnualVisitsInTheStore(int storeId, int fromYear, int untilYear)
        {
            return queries.getAnnualVisitsInTheStore(storeId, fromYear, untilYear);
        }

        //calculate the daily amount of products that bought in the store 
        public double[] getDailyCategoryPurchases_PerOneProduct(int categoryId, int year, int month)
        {
            return queries.getDailyCategoryPurchases_PerOneProduct(categoryId, year, month);
        }

        public double[] getMonthlyCategotyPurchases(int categoryId, int year)
        {
            return queries.getMonthlyCategotyPurchases(categoryId, year);
        }

        public double[] getAnnualCategoryPurchases(int categoryId, int fromYear, int untilYear)
        {
            return queries.getAnnualCategoryPurchases(categoryId, fromYear, untilYear);
        }

        public double[] getDailyTotalCost(int year, int month)
        {
            return queries.getDailyTotalCost(year, month);
        }

        public double[] getMonthlyTotalCost(int year)
        {
            return queries.getMonthlyTotalCost(year);
        }

        public double[] getAnnualTotalCost(int fromYear, int untilYear)
        {
            return queries.getAnnualTotalCost(fromYear, untilYear);
        }



    }

}
