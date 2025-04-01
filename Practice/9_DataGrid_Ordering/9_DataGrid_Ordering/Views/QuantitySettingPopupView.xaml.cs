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
using System.Windows.Shapes;
using _9_DataGrid_Ordering.ViewModels;
using _9_DataGrid_Ordering.Core;

namespace _9_DataGrid_Ordering.Views
{
    /// <summary>
    /// Interaction logic for QuantitySettingPopupView.xaml
    /// </summary>
    public partial class QuantitySettingPopupView : Window
    {
        private QuantitySettingPopupViewModel _model;
        public QuantitySettingPopupView(QuantitySettingPopupViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }

        private void Okay_Click(object sender, RoutedEventArgs e)
        {
            _model.Okay_Click_Handler(sender, e);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _model.Cancel_Click_Handler(sender, e);
        }
    }
}
