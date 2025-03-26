using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using _6_Popup_Window.Views;

namespace _6_Popup_Window.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PopUpWindowViewModel _popupModel;
        private PopUpWindowView _popupView;

        public ObservableCollection<DataItem> DataItems { get; set; }

        private DataItem _selectedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public DataItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                UpdateSelectedIndex(value);
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public MainViewModel()
        {
            DataItems = new ObservableCollection<DataItem>();

            for (int i = 0; i < 10; i++)
            {
                DataItems.Add(new DataItem(i));
            }
        }
        private int SelectedIndex { get; set; }
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void UpdateSelectedIndex(DataItem item)
        {
            SelectedIndex = DataItems.IndexOf(item);
        }

        public void dgMain_SelectionChanged_Handler(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedIndex == -1)
            {
                return;
            }

            if (_popupModel != null || _popupView != null)
            {
                _popupView.Close();
            }

            _popupModel = new PopUpWindowViewModel(this, SelectedIndex);
            _popupView = new PopUpWindowView(_popupModel);
            _popupView.ShowDialog ();
        }


    }

    public class DataItem : INotifyPropertyChanged
    {
        public DataItem(int address)
        {
            Description = "";
            Value = 0;
            Address = address;
        }
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
