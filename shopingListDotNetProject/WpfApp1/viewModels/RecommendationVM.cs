using BE;
using PL.commands;
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
        public ViewRndListAction viewRndListAction { get; set; }
        public ExportToPdfAction exportToPdfAction { get; set; }
        public RecommendationVM(MainWindow main)
        {
            Model = new BuyingModel();
            main.DataContext = this;
            recommendationUC = main.centerOfPageGrid.GetChildOfType<RecommendationUC>();
            viewRndListAction = new ViewRndListAction();
            viewRndListAction.ListButtonClickedEvent += ViewRndListAction_ListButtonClickedEvent;
            exportToPdfAction = new ExportToPdfAction();
            exportToPdfAction.PDFButtonClickedEvent += ExportToPdfAction_PDFButtonClickedEvent;
    
        }

        private void ExportToPdfAction_PDFButtonClickedEvent(DateTime obj)
        {
            DateTime date = recommendationUC.TheSelectedDate.SelectedDate.Value;
            HashSet<int> productSet = Model.getRecommendationList(date.DayOfWeek);
            List<Product> products = new List<Product>();
            products = Model.productlist.Where(x => productSet.Contains(x.ProductId)).ToList();
            ListToPdfCreator listToPdfCreator = new ListToPdfCreator();
            string header = "Recommended shopping list " + date.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
            listToPdfCreator.createPdf<Product>(products, header);
        }

        private void ViewRndListAction_ListButtonClickedEvent(DateTime obj)
        {
            HashSet<int> productSet = Model.getRecommendationList(recommendationUC.TheSelectedDate.SelectedDate.Value.DayOfWeek);
            List<Product> products = new List<Product>();
            products = Model.productlist.Where(x => productSet.Contains(x.ProductId)).ToList();
            recommendationUC.ProductsList.ItemsSource = products;
        }


    }
}
