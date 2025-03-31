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

namespace _9_DataGrid_Ordering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainGridViewModel _mainGridViewModel;
        private PopupView _popupView;
        private PopupViewModel _popupViewModel;
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
            if (_popupView != null)
            {
                _popupView.Close();
            }

            _popupViewModel = new PopupViewModel(_mainGridViewModel);
            _popupView = new PopupView(_popupViewModel);

            _popupView.ShowDialog();
        }
    }
}
