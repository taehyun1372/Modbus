using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace _10_DataGrid_Dynamic_Ordering
{
    public class MainDataGridViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Dictionary<string, string>> _dataItems = new ObservableCollection<Dictionary<string, string>>();
        public ObservableCollection<Dictionary<string, string>> DataItems
        {
            get
            {
                return _dataItems;
            }
            set
            {
                _dataItems = value;
                OnPropertyChanged(nameof(DataItems));
            }
        }

        public MainDataGridViewModel()
        {
            var dic1 = new Dictionary<string, string> { {"Name", "Alice" }, { "Age", "25"} };

            var dic2 = new Dictionary<string, string> { { "Name", "Bob" }, { "Age", "30" } };

            var dic3 = new Dictionary<string, string> { { "Name", "Charlie" }, { "Age", "35" } };

            DataItems.Add(dic1);
            DataItems.Add(dic2);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DataItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
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
