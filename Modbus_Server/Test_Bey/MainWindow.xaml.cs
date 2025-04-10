﻿using System;
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
using Control_Library.PopupViewModels;
using Control_Library.PopupViews;
using Control_Library.ControlViewModels;
using Control_Library.ControlViews;

namespace Test_Bey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SetupViewModel _setupViewModel;
        private SetupView _setupView;
        private DataTableViewModel _dataTableViewModel;
        private DataTableView _dataTableView;

        public MainWindow()
        {
            InitializeComponent();

            _dataTableViewModel = new DataTableViewModel();
            _dataTableView = new DataTableView(_dataTableViewModel);
            fmMain.Content = _dataTableView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            _setupViewModel = new SetupViewModel();
            _setupView = new SetupView(_setupViewModel);

            _setupViewModel.SetupFinished += UpdateTextBlocks;

            _setupView.ShowDialog();
        }

        private void UpdateTextBlocks(object sender, SetupFinishedEventArg e)
        {
            tbRow.Text = e.Row.ToString();
            tbQuantity.Text = e.Quantity.ToString();
        }
    }
}
