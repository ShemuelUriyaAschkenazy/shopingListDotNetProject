using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BLL.BE2;
using LiveCharts;
using LiveCharts.Wpf;

namespace PL.userControls
{
    public partial class DataSectionsUC : UserControl
    {
        public event Action scalingChangedEvent;
        public event Action dataTypeChangedEvent;

        public DataSectionsUC()
        {
            InitializeComponent();
            
            scalingCB.ItemsSource = Enum.GetValues(typeof(time));
            scalingCB.SelectedItem = time.daily;
            timeFirstCB.ItemsSource = Enum.GetValues(typeof(month));
            timeFirstCB.SelectedItem = month.Jan;

        }

        private void PreviewTextInput_YearNumber(object sender, TextCompositionEventArgs e)
        {
            // from: https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
            e.Handled = IsTextAllowed_OnlyNumbers(e.Text);
        }

        private static readonly Regex _regex = new Regex("[^0-9]"); //regex that matches disallowed text
        private static bool IsTextAllowed_OnlyNumbers(string text)
        {
          
            return _regex.IsMatch(text);
        }

        private void scalingCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (scalingChangedEvent != null) scalingChangedEvent();
         }

        private void DataTypeSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataTypeChangedEvent != null)
                dataTypeChangedEvent();
        }
    }
}