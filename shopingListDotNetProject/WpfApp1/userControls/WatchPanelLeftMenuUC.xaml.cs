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
    /// Interaction logic for WatchPanelLeftMenuUC.xaml
    /// </summary>
    public partial class WatchPanelLeftMenuUC : UserControl
    {
        public event Action HistoryButtonClickedEvent;
        public event Action DataSectionsButtonClickedEvent;
        public event Action AnalyzeButtonClickedEvent;

        public WatchPanelLeftMenuUC()
        {
            InitializeComponent();
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryButtonClickedEvent != null)
                HistoryButtonClickedEvent();
        }

        private void SeeGraphsButton(object sender, RoutedEventArgs e)
        {
            if (DataSectionsButtonClickedEvent != null)
                DataSectionsButtonClickedEvent();
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnalyzeButtonClickedEvent != null)
                AnalyzeButtonClickedEvent();
        }
    }
}
