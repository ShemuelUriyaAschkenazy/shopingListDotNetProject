using BE;
using BLL.BE2;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using PL.commands;
using PL.models;
using PL.userControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PL.viewModels
{
    public class DataSectionsVM: IVM
    {
        private MainWindow main;
        private DataSectionsUC uc;
        public ViewGraphAction viewGraphAction { get; set; }

        public DataSectionsVM(MainWindow main, DataSectionsUC uc)
        {
            this.uc = uc;
            this.main = main;
            Model = new BuyingModel();
            buyinglist = new ObservableCollection<Buying>(Model.buyings);
            userlist = new ObservableCollection<User>(Model.userlist);
            storelist = new ObservableCollection<Store>(Model.storelist);
            productlist = new ObservableCollection<Product>(Model.productlist);
            categorylist = new ObservableCollection<Category>(Model.categorylist);

            viewGraphAction = new ViewGraphAction();
            viewGraphAction.viewGrapghClickedAction += ViewGraphAction_viewGrapghClickedAction;

            Model.CategoryListChangedEvent += Model_CategoryListChangedEvent;
            Model.ProductListChangedEvent += Model_ProductListChangedEvent;
            Model.BuyingsListChangedEvent += Model_BuyingsListChangedEvent;
            Model.StoreListChangedEvent += Model_StoreListChangedEvent;
            Model.UserListChangedEvent += Model_UserListChangedEvent;

            uc.scalingChangedEvent += Uc_scalingChangedEvent;

            uc.parameterCB.SelectedValue = productlist[0];
            int[] yearList= new int[100];
            for (int i=0; i<100; i++)
            {
                yearList[i] = i + 1990;
            }
            uc.timeSecondCB.ItemsSource = yearList;
            uc.timeSecondCB.SelectedItem = DateTime.Now.Year;
            uc.chartAxisX.Title = uc.timeFirstCB.SelectedValue.ToString();
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = (uc.parameterCB.SelectedValue as Product).ProductName,
                    Values = new ChartValues<double>((Model as BuyingModel).getDailyProductPurchases(1,2021,1) as IEnumerable<double>)
       
                }
         
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
            YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
           /* SeriesCollection.Add(new LineSeries
            {
                Title = "Series 4",
                Values = new ChartValues<double> {5,3,2,4,3,4,5,6,7},
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });

            //modifying any series values will also animate and update the chart
            SeriesCollection[3].Values.Add(5d);*/
            
        }

        

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void Model_UserListChangedEvent()
        {
            userlist.Clear();
            foreach (var u in Model.userlist)
            {
                userlist.Add(u);
            }
        }

        private void Model_StoreListChangedEvent()
        {
            storelist.Clear();
            foreach (var u in Model.storelist)
            {
                storelist.Add(u);
            }
        }

        private void Model_BuyingsListChangedEvent()
        {
            buyinglist.Clear();
            foreach (var obj in Model.buyings)
            {
                buyinglist.Add(obj);
            }
        }

        private void Model_ProductListChangedEvent()
        {
            productlist.Clear();
            foreach (var obj in Model.productlist)
            {
                productlist.Add(obj);
            }
        }

        private void Model_CategoryListChangedEvent()
        {
            categorylist.Clear();
            foreach (var obj in Model.categorylist)
            {
                categorylist.Add(obj);
            }
        }

        private void Uc_scalingChangedEvent()
        {
            //daily
            if ((time)uc.scalingCB.SelectedItem == time.daily)
            {
                uc.timeFirstLabel.Content = "Month";
                uc.timeFirstCB.ItemsSource = Enum.GetValues(typeof(month));
                uc.timeFirstCB.SelectedItem = month.Jan;
                uc.timeSecondLabel.Content = "Year";

                uc.timeFirstLabel.Visibility = Visibility.Visible;
                uc.timeFirstCB.Visibility = Visibility.Visible;

                
            }
            //annual
            else if ((time)uc.scalingCB.SelectedItem == time.annual)
            {
                uc.timeFirstLabel.Content = "From";
                int[] yearList = new int[100];
                for (int i = 0; i < 100; i++)
                {
                    yearList[i] = i + 1990;
                }
                uc.timeFirstCB.ItemsSource = yearList;
                uc.timeFirstCB.SelectedItem = DateTime.Now.Year;
               
                uc.timeSecondCB.SelectedItem = DateTime.Now.Year;
                uc.timeSecondLabel.Content = "To";

                uc.timeFirstLabel.Visibility = Visibility.Visible;
                uc.timeFirstCB.Visibility = Visibility.Visible;
            }
            else //monthly
            {
                uc.timeSecondLabel.Content = "Year";
                uc.timeFirstLabel.Visibility = Visibility.Hidden;
                uc.timeFirstCB.Visibility = Visibility.Hidden;
            }
        }
        private void ViewGraphAction_viewGrapghClickedAction()
        {
            if ((time)uc.scalingCB.SelectedItem == time.daily) {
                
                int productId = (uc.parameterCB.SelectedValue as Product).ProductId;
                int year = (int)uc.timeSecondCB.SelectedItem;
                int month =(int)uc.timeFirstCB.SelectedItem;
                SeriesCollection[0] = new LineSeries
                {
                    Values = new ChartValues<double>((Model as BuyingModel).getDailyProductPurchases(productId, year, month) as IEnumerable<double>),
                    Title = (uc.parameterCB.SelectedValue as Product).ProductName

                };
                string[] labels = new string[DateTime.DaysInMonth(year, month)];
                for (int i=0; i<labels.Length; i++) { labels[i] = (i + 1).ToString(); }
                uc.chartAxisX.Labels = labels;
                uc.chartAxisX.Title = uc.timeFirstCB.SelectedItem.ToString();
            }
            else if ((time)uc.scalingCB.SelectedItem == time.annual)
            {
                int productId = (uc.parameterCB.SelectedValue as Product).ProductId;
                int year1 = (int)uc.timeFirstCB.SelectedItem;
                int year2 = (int)uc.timeSecondCB.SelectedItem;


                SeriesCollection[0] = new LineSeries
                {
                    Values = new ChartValues<double>((Model as BuyingModel).getAnnualProductPurchases(productId, year1, year2) as IEnumerable<double>),
                    Title = (uc.parameterCB.SelectedValue as Product).ProductName

                };
                string[] labels = new string[year2-year1+1];
                for (int i = 0; i < labels.Length; i++) { labels[i] = (i + year1).ToString(); }
                uc.chartAxisX.Labels = labels;
                uc.chartAxisX.Title = uc.timeFirstCB.SelectedItem.ToString()+"-"+ uc.timeSecondCB.SelectedItem.ToString();
            }
            else
            {
                int productId = (uc.parameterCB.SelectedValue as Product).ProductId;
                int year = (int)uc.timeSecondCB.SelectedItem;

                SeriesCollection[0] = new LineSeries
                {
                    Values = new ChartValues<double>((Model as BuyingModel).getMonthlyProductPurchases(productId, year) as IEnumerable<double>),
                    Title = (uc.parameterCB.SelectedValue as Product).ProductName

                };
                uc.chartAxisX.Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                uc.chartAxisX.Title = uc.timeSecondCB.SelectedItem.ToString();


            }


        }

    }
}
