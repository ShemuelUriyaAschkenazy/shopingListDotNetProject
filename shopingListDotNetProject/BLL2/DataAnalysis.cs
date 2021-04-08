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


            buyings = buyings.Where(x => x.ProductId.ToString() == Id || x.ProductId.ToString() == Id1).ToList();
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
                
                if (buyings[i].ProductId.ToString() == Id && check == 0)
                {   
                    A = buyings[i];
                    buyings[i].ProductId = -1;
                    check = 1;

                    int k = 0;
                    //Product B must be no earlier than one before A, since the products are arranged by date, and A is the first A on the date.
                    for (k=Math.Max(i-1,0); k<buyings.Count; k++)
                    {
                        if(buyings[k].ProductId.ToString() == Id1)
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
                if (buyings[i].ProductId.ToString() == Id1)
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
    }
}
