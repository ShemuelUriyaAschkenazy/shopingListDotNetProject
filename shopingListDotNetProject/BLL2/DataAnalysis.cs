﻿using BE;
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

        public DataAnalysis()
        {
            this.dbAdapter = new DbAdapter();
        }

        public float getProbability(int Id1, int Id2)
        {
            //אם מדובר באותו מוצר ההסתברות היא 1
            if (Id1 == Id2) return 1;

            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Product> productlist = dbAdapter.GetAllProducts();
            float count = 0;
            int check = 0;
            //string Id = null;
            //string Id1 = null;
            int j = productlist.Count;
           
           /* for (int i = 0; i < j; i++)
            {
                if (productlist[i].ProductName.ToString() == product1Name)
                {
                    Id = productlist[i].ProductId.ToString();
                }
                if (productlist[i].ProductName.ToString() == product2Name)
                {
                    Id1 = productlist[i].ProductId.ToString();
                }
            }*/

            List<DateTime> datetime = new List<DateTime>();


            buyings = buyings.Where(x => x.ProductId == Id1 || x.ProductId == Id2).ToList();
            for (int i = 0; i < buyings.Count; i++)
            {
                if (!(datetime.Contains(buyings[i].Date)))
                {
                    datetime.Add(buyings[i].Date);

                }
            }
            //אם אחד המוצרים כלל לא מופיע אז ההסתברות 0
            if (datetime.Count == 0)
                return 0;

            Buying A = null;
            Buying B = null;
            
            for (int i = 0; i < buyings.Count; i++)
            {
                
                if (buyings[i].ProductId == Id1 && check == 0)
                {   
                    A = buyings[i];
                    buyings[i].ProductId = -1;
                    check = 1;

                    int k = 0;
                    //Product B must be no earlier than one before A, since the products are arranged by date, and A is the first A on the date.
                    for (k=Math.Max(i-1,0); k<buyings.Count; k++)
                    {
                        if(buyings[k].ProductId == Id2)
                        {
                            B = buyings[k];
                            if (A.Date == B.Date)
                            {
                                count += 1;
                                //ברגע שסיימנו לעבור על מוצר, דואגים שנעבור ישר לתאריך הבא
                                if ((i + 1) < buyings.Count)
                                {
                                    while (buyings[i + 1].Date == A.Date)
                                    { i++;
                                        if (i + 1 == buyings.Count) break;
                                    }
                                }
                                A = null;
                                B = null;
                                check = 0;
                                break; 
                            }

                        }
                        if (k == buyings.Count-1)//לא מצאנו התאמה והגענו לאיטרציה אחרונה
                        {
                            if (i + 1 < buyings.Count)//ברגע שסיימנו לעבור על מוצר, דואגים שנעבור ישר לתאריך הבא
                            while (buyings[i + 1].Date == A.Date)
                            { i++;
                                if (i + 1 == buyings.Count) break;
                            }
                            A = null;
                            B = null;
                            check = 0;
                        }
                    }              
                }
                if (buyings[i].ProductId == Id2)
                {
                    B = buyings[i];
                }
                if (!(A == null) && !(B == null))
                {
                    if (A.Date == B.Date)
                    {
                        count += 1;
                        check = 0;
                        A = null;
                        B = null;
                    }
                }
            }
            float probability = count / datetime.Count;
            return probability;
        }

        public HashSet<int> getRecommendationList(DayOfWeek dayOfWeek)
        {
            List<Buying> buyings = dbAdapter.GetAllBuyings();
            List<Product> productlist = dbAdapter.GetAllProducts();
            HashSet<int> productsIds = new HashSet<int>();
            HashSet<int> ProbabilityProductsIds = new HashSet<int>();
            int j = buyings.Count();
            int k = productlist.Count();
            for (int i = 0; i < j; i++)
            {
                //go through all buyings, and add any product that was bought in the selected day in week.
                if (buyings[i].Date.DayOfWeek == dayOfWeek)
                {
                    productsIds.Add(buyings[i].ProductId);
                }
            }


            //go through productsIds that we found above, and find products that are highly likely to buy them along with them.
            //we add the new findings to a set called ProbabilityProductsIds  
            foreach (int productId in productsIds)
            {

                for (int a = 0; a < productlist.Count(); a++)
                {
                    if (getProbability(productId, productlist[a].ProductId) >= 0.6)
                    {
                        ProbabilityProductsIds.Add(productlist[a].ProductId);
                    }
                }
            }

            //Union the two sets we found, and convert the ids set to a product list.
            HashSet<int> UnionProductSet = ProbabilityProductsIds.Union<int>(productsIds).ToHashSet();
            return UnionProductSet;
        }
    }
}
