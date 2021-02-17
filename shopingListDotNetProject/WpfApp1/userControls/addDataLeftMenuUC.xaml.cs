﻿using BE;
using PL.viewModels;
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
    /// Interaction logic for addDataLeftMenuUC.xaml
    /// </summary>
    public partial class addDataLeftMenuUC : UserControl
    {
        public event Action ImportDataEvent;
        public addDataLeftMenuUC()
        {
            InitializeComponent();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImportDataEvent != null)
                ImportDataEvent();
        }
    }
}