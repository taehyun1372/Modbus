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
using Control_Library.ControlViewModels;
using Control_Library.ControlViews;
using Control_Library.Core;

namespace Modbus_Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;
        private MainView _mainView;

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            _mainViewModel = mainViewModel;
            MainView mainView = new MainView(mainViewModel);
            _mainView = mainView;

            ccMainArea.Content = mainView;

            mainViewModel.CreateNewTable();

            this.Loaded += (s, e) =>
            {
                mainViewModel.ShowConnectPopup(); //Initially open connection popup
            };

            StatusBarViewModel statusBarViewModel = new StatusBarViewModel(mainViewModel.Slave);
            StatusBarView statusBarView = new StatusBarView(statusBarViewModel);

            ccStatusBar.Content = statusBarView;
        }

        private void mnCreateTable_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.CreateNewTable();
        }

        private void mnDeleteTable_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.DeleteTable();
        }

        private void mnCommunicationLog_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.ShowCommunicationLogPopup();
        }

        private void mnTableSetup_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.ShowTableSetupPopup();
        }

        private void mnConnect_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.ShowConnectPopup();
        }
        
        private void mnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.Slave.Disconnect();
        }
    }
}
