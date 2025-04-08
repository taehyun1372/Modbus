using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace _10_DataGrid_Dynamic_Ordering
{
    public class MainDataGridViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Dictionary<string, int>> _dataItems = new ObservableCollection<Dictionary<string, int>>();
        private ObservableCollection<int> _rowNumbering = new ObservableCollection<int>();
        public ObservableCollection<int> RowNumbering
        {
            get { return _rowNumbering; }
            set
            {
                _rowNumbering = value;
            }
        }

        private List<int> _listDataItems = new List<int>();
        public event EventHandler<EventArgs> DataItemsChanged; 
        private int _rowSetting;


        public int RowSetting
        {
            get
            {
                return _rowSetting;
            }
            set
            {
                _rowSetting = value;
                UpdateRowNumbering();
            }
        }

        private void UpdateRowNumbering()
        {
            if (RowSetting == RowNumbering.Count)
            { 
                return; 
            }
            else if(RowSetting > RowNumbering.Count)
            {
                for (int i = RowSetting; i < RowNumbering.Count; i++)
                {
                    RowNumbering.Add(i);
                }
            }
            else if (RowSetting < RowNumbering.Count)
            {
                for (int i = RowNumbering.Count - 1; i <= RowSetting; i--)
                {
                    RowNumbering.RemoveAt(i);
                }
            }
        }


        public int Quantity 
        { 
            get
            {
                return _listDataItems.Count;
            }
            set
            {
                SetDataGridQuantity(value);
            }
        }

        public void SetDataGridQuantity(int value)
        {
            if (Quantity == value)
            {
                return;
            }
            if (Quantity < value )
            {
                for (int i = Quantity; i < value; i++)
                {
                    _listDataItems.Add(0);
                }
            }
            else if (Quantity > value)
            {
                for (int i = Quantity - 1 ; i >= value; i--)
                {
                    _listDataItems.RemoveAt(i);
                }
            }
            ConvertListToObservableCollection();
        }

        public void ConvertListToObservableCollection()
        {
            DataItems.Clear();
            int count = 0;
            int columnIndex = 0;
            foreach (var item in _listDataItems)
            {
                
                
                if (count >= RowSetting)
                {
                    count = 0;
                    columnIndex++;
                }

                var dic = new Dictionary<string, int>();
                dic.Add(columnIndex.ToString("D4"), item);

                if (columnIndex == 0)
                {
                    DataItems.Add(dic);
                }
                else
                {
                    DataItems[count].Add(columnIndex.ToString("D4"), item);
                }

                count++;
            }
            DataItemsChanged?.Invoke(this, EventArgs.Empty);
        }

        public ObservableCollection<Dictionary<string, int>> DataItems
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

        public void Apply_Clicked_Handler(object sender, RoutedEventArgs e, int quantity)
        {
            Quantity = quantity;
        }

        public MainDataGridViewModel()
        {
            RowSetting = 10;
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
