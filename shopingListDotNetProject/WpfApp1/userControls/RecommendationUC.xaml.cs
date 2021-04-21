using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.userControls
{
    /// <summary>
    /// Interaction logic for RecommendationUC.xaml
    /// </summary>
    public partial class RecommendationUC : UserControl
    {
        public event Action PDFButtonClickedEvent;
        public event Action ListButtonClickedEvent;
        public RecommendationUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PDFButtonClickedEvent != null)
            {
                PDFButtonClickedEvent();
            }

        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListButtonClickedEvent != null)
            {
                ListButtonClickedEvent();
            }

        }
    }
}
