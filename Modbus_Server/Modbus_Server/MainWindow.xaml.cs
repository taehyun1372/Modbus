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
            _mainViewModel.ShowCommunicationLog();
        }
    }
}
