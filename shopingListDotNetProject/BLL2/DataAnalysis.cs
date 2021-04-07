using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL2
{
    public class DataAnalysis
    {
        DbAdapter dbAdapter;
        public float getProbability(string product1Name, string product2Name)
        {
            dbAdapter = new DbAdapter();
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Product> productlist = dbAdapter.GetAllProducts();
            float count = 0;
            int check = 0;
            string Id = null;
            string Id1 = null;
            int j = productlist.Count;
           
            for (int i = 0; i < j; i++)
            {
                if (productlist[i].ProductName.ToString() == product1Name)
                {
                    Id = productlist[i].ProductId.ToString();
                }
                if (productlist[i].ProductName.ToString() == product2Name)
                {
                    Id1 = productlist[i].ProductId.ToString();
                }
            }

            List<DateTime> datetime = new List<DateTime>();


            for (int i = 0; i < buyings.Count; i++)
            {
                if (!(datetime.Contains(buyings[i].Date)))
                {
                    datetime.Add(buyings[i].Date);

                }
            }
            Buying A = null;
            Buying B = null;
            Buying C = null;
            for (int i = 0; i < buyings.Count; i++)
            {
                if (buyings[i].ProductId.ToString() == Id && check == 0)
                {
                    A = buyings[i];
                    buyings[i].ProductId = -1;
                    check = 1;
                }
                if (buyings[i].ProductId.ToString() == Id1)
                {
                    B = buyings[i];
                }
                if (!(A == null) && !(B == null))
                {
                    if (A.Date == B.Date)
                    {
                        count += 1;
                    }

                }

            }
            float probability = count / datetime.Count();
            return probability;
            //AnalyzeBuyingUC.probability.Text = probability.ToString();


        }

    }
}
