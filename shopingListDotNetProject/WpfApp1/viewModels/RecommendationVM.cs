using BE;
using PL.models;
using PL.userControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.viewModels
{
    public class RecommendationVM : IVM
    {
        BuyingModel Model;
        RecommendationUC recommendationUC;
        public RecommendationVM(MainWindow main)
        {
            Model = new BuyingModel();
            main.DataContext = this;
            recommendationUC = main.centerOfPageGrid.GetChildOfType<RecommendationUC>();
            recommendationUC.PDFButtonClickedEvent += Active_PDFButtonClickedEvent;
            recommendationUC.ListButtonClickedEvent += Active_ListButtonClickedEvent;

        }
        private void Active_PDFButtonClickedEvent()
        {
            DateTime date = recommendationUC.TheSelectedDate.SelectedDate.Value;
            HashSet<int> productSet = Model.getRecommendationList(date.DayOfWeek);
            List<Product> products = new List<Product>();
            products = Model.productlist.Where(x => productSet.Contains(x.ProductId)).ToList();
            ListToPdfCreator listToPdfCreator = new ListToPdfCreator();
            string header = "Recommended shopping list "+date.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
            listToPdfCreator.createPdf<Product>(products, header);


        }
        private void Active_ListButtonClickedEvent()
        {
            HashSet<int> productSet = Model.getRecommendationList(recommendationUC.TheSelectedDate.SelectedDate.Value.DayOfWeek);
            List<Product> products = new List<Product>();
            products= Model.productlist.Where(x => productSet.Contains(x.ProductId)).ToList();
            recommendationUC.ProductsList.ItemsSource = products;
        }

    }
}
