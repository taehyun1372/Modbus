using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Control_Library.ControlViewModels
{
    public class DataTableViewModel : INotifyPropertyChanged
    {
        public event EventHandler<EventArgs> DataItemsChanged;
        private const int MAXROWCOUNTS = 100;
        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                UpdateDataTableList();
            }
        }

        private ObservableCollection<Dictionary<string, DataItem>> _dataItems = new ObservableCollection<Dictionary<string, DataItem>>();
        public ObservableCollection<Dictionary<string, DataItem>> DataItems
        {
            get
            {
                return _dataItems;
            }
            set
            {
                _dataItems = value;
            }
        }

        private List<DataItem> _listDataItems = new List<DataItem>();
        private List<DataItem> ListDataItems
        {
            get
            {
                return _listDataItems;
            }
            set
            {
                _listDataItems = value;
            }
        }

        private Color _indexColumnColor;
        public Color IndexColumnColor
        {
            get
            {
                return _indexColumnColor;
            }
            set
            {
                _indexColumnColor = value;
                OnPropertyChanged(nameof(IndexColumnColor));
            }
        }

        private int _indexColumnWidth;
        public int IndexColumnWidth
        {
            get
            {
                return _indexColumnWidth;
            }
            set
            {
                _indexColumnWidth = value;
                OnPropertyChanged(nameof(IndexColumnWidth));
            }
        }

        private ObservableCollection<Index> _rowIndex = new ObservableCollection<Index>();
        public ObservableCollection<Index> RowIndex
        {
            get
            {
                return _rowIndex;
            }
            set
            {
                _rowIndex = value;
            }
        }

        private int _rowCounts;
        public int RowCounts
        {
            get
            {
                return _rowCounts;
            }
            set
            {
                if (value < 0) value = 0;
                else if (value > MAXROWCOUNTS) value = MAXROWCOUNTS;
                _rowCounts = value;
                UpdateRowIndex();
                OnPropertyChanged(nameof(RowCounts));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DataTableViewModel()
        {
            IndexColumnColor = Colors.AliceBlue;
            RowCounts = 10;
        }

        private void UpdateDataTableList()
        {
            if (Quantity == ListDataItems.Count)
            {
                return;
            }
            else if (Quantity > ListDataItems.Count)
            {
                for (int i = ListDataItems.Count; i < Quantity; i++)
                {
                    ListDataItems.Add(new DataItem() { Name = "", Value = 0 });
                }
            }
            else if (Quantity < ListDataItems.Count)
            {
                for (int i = ListDataItems.Count - 1; i >= Quantity; i--)
                {
                    ListDataItems.RemoveAt(i);
                }
            }

            ConvertDataItemListToDictionary();
        }

        private void ConvertDataItemListToDictionary()
        {
            DataItems.Clear();
            int rowIndex = 0;
            int columnIndex = 0;
            if (rowIndex >= RowCounts)
            {
                rowIndex = 0;
                columnIndex++;
            }

            foreach (var item in _listDataItems)
            {
                var dic = new Dictionary<string, DataItem>();

                dic.Add(columnIndex.ToString("D4"), item);

                if (columnIndex == 0)
                {
                    DataItems.Add(dic);
                }
                else
                {
                    DataItems[rowIndex].Add(columnIndex.ToString("D4"), item);
                }
                rowIndex++;
            }
            DataItemsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateRowIndex()
        {
            //Row Index Update
            if (RowCounts == RowIndex.Count)
            {
                return;
            }
            else if (RowCounts > RowIndex.Count)
            {
                for (int i = RowIndex.Count; i < RowCounts; i++)
                {
                    RowIndex.Add(new Index() { Value = i });
                }
            }
            else if (RowCounts < RowIndex.Count)
            {
                for (int i = RowIndex.Count - 1; i >= RowCounts; i--)
                {
                    RowIndex.RemoveAt(i);
                }
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

    public class Index
    {
        public int Value { get; set; }
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
