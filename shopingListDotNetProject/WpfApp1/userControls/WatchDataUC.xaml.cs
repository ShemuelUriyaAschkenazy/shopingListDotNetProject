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
    /// Interaction logic for WatchDataUC.xaml
    /// </summary>
    public partial class WatchDataUC : UserControl
    {
        public string ProductImagePath
        {
            get { return (string)GetValue(ProductImagePathProperty); }
            set { SetValue(ProductImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProductImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductImagePathProperty =
            DependencyProperty.Register("ProductImagePath", typeof(string), typeof(WatchDataUC));

        public WatchDataUC()
        {
            InitializeComponent();
            this.rightGrid.DataContext = this;

        }

        public event Action RowSelectionChanged;

        private void BuyingsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RowSelectionChanged?.Invoke();
        }

        void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                    row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }
    }
}
