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

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private taskManager taskManager;
        public IVM GeneralVM { get; set; }
        public IVM CurrentVM { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //initialize VM
            taskManager = new taskManager(this);
            this.DataContext = GeneralVM;
        }

        

    }

}
