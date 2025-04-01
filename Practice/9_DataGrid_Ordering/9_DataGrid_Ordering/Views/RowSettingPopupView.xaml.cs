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
using System.Windows.Shapes;
using _9_DataGrid_Ordering.ViewModels;

namespace _9_DataGrid_Ordering.Views
{
    /// <summary>
    /// Interaction logic for PopupView.xaml
    /// </summary>
    public partial class RowSettingPopupView : Window
    {
        private RowSettingPopupViewModel _model;
        public RowSettingPopupView(RowSettingPopupViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }


        private void Okay_Click(object sender, RoutedEventArgs e)
        {
            _model.Okay_Click_Handler(sender, e);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
