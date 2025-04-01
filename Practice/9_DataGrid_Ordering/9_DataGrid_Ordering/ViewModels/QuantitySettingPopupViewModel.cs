using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9_DataGrid_Ordering.Views;
using _9_DataGrid_Ordering.Core;
using System.Windows;
using System.ComponentModel;

namespace _9_DataGrid_Ordering.ViewModels
{
    public class QuantitySettingPopupViewModel : INotifyPropertyChanged
    {
        private int _quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public QuantitySettingPopupViewModel(MainGridViewModel mainGridViewModel)
        {
            Quantity = mainGridViewModel.Quantity;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Okay_Click_Handler(object sender, RoutedEventArgs e)
        {
        }

        public void Cancel_Click_Handler(object sender, RoutedEventArgs e)
        {

        }
    }
}
