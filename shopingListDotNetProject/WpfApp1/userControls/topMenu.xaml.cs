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
    /// Interaction logic for topMenu.xaml
    /// </summary>
    public partial class TopMenu : UserControl
    {
        public TopMenu()
        {
            InitializeComponent();
        }

        public event Action OpenAddPanelClickedEvent;
        public event Action OpenWatchPanelClickedEvent;
        public event Action OpenRecommendationPanelClickedEvent;

        private void OpenAddPanel_Click(object sender, RoutedEventArgs e)
        {
            if (OpenAddPanelClickedEvent != null)
                OpenAddPanelClickedEvent();
        }

        private void OpenWatchPanel_Click(object sender, RoutedEventArgs e)
        {
            if (OpenWatchPanelClickedEvent != null)
                OpenWatchPanelClickedEvent();
        }

        private void OpenRecommendationPanel_Click(object sender, RoutedEventArgs e)
        {
            if (OpenRecommendationPanelClickedEvent != null)
                OpenRecommendationPanelClickedEvent();
        }
    }
}
