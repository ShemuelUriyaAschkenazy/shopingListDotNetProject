using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddNewUC.xaml
    /// </summary>
    public partial class AddValuesUC : UserControl
    {
        public AddValuesUC()
        {
            InitializeComponent();
        }

        
        private void PreviewTextInput_Numbers(object sender, TextCompositionEventArgs e)
        {
            // from: https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
            e.Handled = IsTextAllowed_OnlyNumbers(e.Text);
        }

        private static readonly Regex _regex = new Regex("[^0-9.]+"); //regex that matches disallowed text
        private static bool IsTextAllowed_OnlyNumbers(string text)
        {
            return _regex.IsMatch(text);
        }
    }
}
