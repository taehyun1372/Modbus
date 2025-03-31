using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;

namespace _9_DataGrid_Ordering
{
    public class PopupViewModel : INotifyPropertyChanged
    {
        private MainGridViewModel _mainGridViewModel;
        public PopupViewModel(int selectedItem, MainGridViewModel mainGridViewModel)
        {
            _mainGridViewModel = mainGridViewModel;
            SelectedItem = selectedItem;
        }
        public int SelectedItem { get; set; }

        public void Okay_Click_Handler(object sender, RoutedEventArgs e)
        {
            if (Check10)
            {

            }

            _mainGridViewModel.Update_Columns();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private bool _check10;

        public bool Check10
        {
            get
            {
                return _check10;
            }
            set
            {
                _check10 = value;
                OnPropertyChanged(nameof(Check10));
            }
        }

        private bool _check20;

        public bool Check20
        {
            get
            {
                return _check20;
            }
            set
            {
                _check20 = value;
                OnPropertyChanged(nameof(Check20));
            }
        }

        private bool _check30;

        public bool Check30
        {
            get
            {
                return _check30;
            }
            set
            {
                _check30 = value;
                OnPropertyChanged(nameof(_check30));
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    
}
