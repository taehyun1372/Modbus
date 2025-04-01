using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using _9_DataGrid_Ordering.Views;
using _9_DataGrid_Ordering.Core;

namespace _9_DataGrid_Ordering.ViewModels
{
    public class MainGridViewModel
    {
        public ObservableCollection<DataItem> DataItems { get; set; }
        public int SelectedItem { get; set; }
        public MainGridViewModel()
        {
            DataItems = new ObservableCollection<DataItem>();
            RowSetting = Features.EnumRowSetting.Row10;
        }

        private Features.EnumRowSetting _rowSetting;
        public Features.EnumRowSetting RowSetting
        {
            get { return _rowSetting; }
            set
            {
                _rowSetting = value;
                UpdateRowSetting(_rowSetting);
            }
        }

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value <= 0)
                {
                    value = 1;
                }
                _quantity = value;
                UpdateQuantitySetting(_quantity);
            }
        }

        public void UpdateQuantitySetting(int quantity)
        {
            
        }

        public void UpdateRowSetting(Features.EnumRowSetting rowSetting)
        {

            if ((int)rowSetting <= 0 ) return;
            if ((int)rowSetting == DataItems.Count) return;
            if ((int)rowSetting < DataItems.Count)
            {
                for (int i = DataItems.Count -1; i >= (int)rowSetting; i--)
                {
                    DataItems.RemoveAt(i);
                }
            }
            if ((int)rowSetting > DataItems.Count)
            {
                for (int i = DataItems.Count; i < (int)rowSetting; i++)
                {
                    DataItems.Add(new DataItem() { Address=i, Description="", Value = 0 });
                }
            }
        }
    }

    public class DataItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _address;
        public int Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
