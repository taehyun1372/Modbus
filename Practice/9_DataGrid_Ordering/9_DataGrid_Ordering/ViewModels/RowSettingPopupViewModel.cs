using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using _9_DataGrid_Ordering.Views;
using _9_DataGrid_Ordering.Core;

namespace _9_DataGrid_Ordering.ViewModels
{
    public class RowSettingPopupViewModel : INotifyPropertyChanged
    {
        private MainGridViewModel _mainGridViewModel;
        public RowSettingPopupViewModel(MainGridViewModel mainGridViewModel)
        {
            _mainGridViewModel = mainGridViewModel;
            RowSetting = _mainGridViewModel.RowSetting;
        }

        public void Okay_Click_Handler(object sender, RoutedEventArgs e)
        {
            _mainGridViewModel.RowSetting = this.RowSetting;
        }

        public Features.EnumRowSetting RowSetting
        {
            get
            {
                return _rowSetting;
            }
            set
            {
                _rowSetting = value;
                if (value == Features.EnumRowSetting.Row10)
                {
                    Check10 = true;
                    Check20 = false;
                    Check30 = false;
                }
                else if (value == Features.EnumRowSetting.Row20)
                {
                    Check10 = false;
                    Check20 = true;
                    Check30 = false;
                }
                else if (value == Features.EnumRowSetting.Row30)
                {
                    Check10 = false;
                    Check20 = false;
                    Check30 = true;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private Features.EnumRowSetting _rowSetting;

        public bool Check10
        {
            get
            {
                return _rowSetting == Features.EnumRowSetting.Row10;
            }
            set
            {
                if (value)
                {
                    _rowSetting = Features.EnumRowSetting.Row10;
                    OnPropertyChanged(nameof(Check10));
                }
            }
        }

        private bool _check20;

        public bool Check20
        {
            get
            {
                return _rowSetting == Features.EnumRowSetting.Row20;
            }
            set
            {
                if (value)
                {
                    _rowSetting = Features.EnumRowSetting.Row20;
                    OnPropertyChanged(nameof(Check20));
                }
            }
        }

        private bool _check30;

        public bool Check30
        {
            get
            {
                return _rowSetting == Features.EnumRowSetting.Row30;
            }
            set
            {
                if (value)
                {
                    _rowSetting = Features.EnumRowSetting.Row30;
                    OnPropertyChanged(nameof(Check30));
                }
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    
}
