using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace _9_DataGrid_Ordering
{
    public class MainGridViewModel
    {
        public ObservableCollection<DataItem> DataItems { get; set; }
        public int SelectedItem { get; set; }
        private PopupView _popupView;
        private PopupViewModel _popupViewModel;
        public MainGridViewModel()
        {
            DataItems = new ObservableCollection<DataItem>();
            DataItems.Add(new DataItem() { Address = 0, Description = "", Value = 0 });
            DataItems.Add(new DataItem() { Address = 1, Description = "", Value = 0 });
            DataItems.Add(new DataItem() { Address = 2, Description = "", Value = 0 });
            DataItems.Add(new DataItem() { Address = 3, Description = "", Value = 0 });
            DataItems.Add(new DataItem() { Address = 4, Description = "", Value = 0 });
            DataItems.Add(new DataItem() { Address = 5, Description = "", Value = 0 });
            DataItems.Add(new DataItem() { Address = 6, Description = "", Value = 0 });
            DataItems.Add(new DataItem() { Address = 7, Description = "", Value = 0 });
            DataItems.Add(new DataItem() { Address = 8, Description = "", Value = 0 });
            DataItems.Add(new DataItem() { Address = 9, Description = "", Value = 0 });
        }

        public void DataGrid_Selected_Handler(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == -1)
            {
                return;
            }
            if (_popupView != null)
            {
                _popupView.Close();
            }

            _popupViewModel = new PopupViewModel(SelectedItem);
            _popupView = new PopupView(_popupViewModel);

            _popupView.ShowDialog();
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
