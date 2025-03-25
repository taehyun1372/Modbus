using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;

namespace _6_Popup_Window.ViewModels
{
    public class MainViewModel
    {

        public ObservableCollection<DataItem> DataItems { get; set; }

        public MainViewModel()
        {
            DataItems = new ObservableCollection<DataItem>();

            for (int i = 0; i < 10; i++)
            {
                DataItems.Add(new DataItem(i));
            }

            //Test
            DataItems[5].Value = 10;
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
