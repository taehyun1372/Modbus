using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _9_DataGrid_Ordering.Views;
using _9_DataGrid_Ordering.ViewModels;

namespace _9_DataGrid_Ordering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainGridViewModel _mainGridViewModel;
        private RowSettingPopupView _rowSettingPopupView;
        private RowSettingPopupViewModel _rowSettingPopupViewModel;

        private QuantitySettingPopupView _quantitySettingPopupView;
        private QuantitySettingPopupViewModel _quantitySettingPopupViewModel;


        public MainWindow()
        {
            InitializeComponent();
            MainGridViewModel model = new MainGridViewModel();
            _mainGridViewModel = model;
            MainGridView view = new MainGridView(model);
            fmMain.Content = view;

        }

        private void btnRowSetting_Click(object sender, RoutedEventArgs e)
        {
            if (_rowSettingPopupView != null)
            {
                _rowSettingPopupView.Close();
            }

            _rowSettingPopupViewModel = new RowSettingPopupViewModel(_mainGridViewModel);
            _rowSettingPopupView = new RowSettingPopupView(_rowSettingPopupViewModel);

            _rowSettingPopupView.ShowDialog();
        }

        private void btnQuantitySetting_Click(object sender, RoutedEventArgs e)
        {
            if (_quantitySettingPopupView != null)
            {
                _quantitySettingPopupView.Close();
            }

            _quantitySettingPopupViewModel = new QuantitySettingPopupViewModel(_mainGridViewModel);
            _quantitySettingPopupView = new QuantitySettingPopupView(_quantitySettingPopupViewModel);

            _quantitySettingPopupView.ShowDialog();
        }
    }
}
