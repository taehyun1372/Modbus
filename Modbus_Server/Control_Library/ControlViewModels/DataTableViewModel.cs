using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace Control_Library.ControlViewModels
{
    public class DataTableViewModel : INotifyPropertyChanged
    {
        public event EventHandler<DataItemsChangedEventArg> DataItemsChanged;
        private const int MAX_ROW_COUNTS = 100;
        private const int DEFAULT_INDEX_COLUMN_WIDTH = 20;
        private const int DEFAULT_ROW_COUNTS = 10;
        private const int DEFAULT_NAME_COLUMN_WIDTH = 70;
        private const int DEFAULT_VALUE_COLUMN_WIDTH = 70;
        public const int DEFAULT_QUANTITY = 10;
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

        private ObservableCollection<ExpandoObject> _dataItems = new ObservableCollection<ExpandoObject>();
        public ObservableCollection<ExpandoObject> DataItems
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

        private int _nameColumnWidth = DEFAULT_NAME_COLUMN_WIDTH;

        public int NameColumnWidth
        {
            get
            {
                return _nameColumnWidth;
            }
            set
            {
                _nameColumnWidth = value;
            }
        }

        private int _valueColumnWidth = DEFAULT_VALUE_COLUMN_WIDTH;

        public int ValueColumnWidth
        {
            get
            {
                return _valueColumnWidth;
            }
            set
            {
                _valueColumnWidth = value;
            }
        }

        private Brush _indexColumnColor = new SolidColorBrush(Colors.LightGray);
        public Brush IndexColumnColor
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

        private int _indexColumnWidth = DEFAULT_INDEX_COLUMN_WIDTH;
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

        private int _rowCounts = DEFAULT_ROW_COUNTS;
        public int RowCounts
        {
            get
            {
                return _rowCounts;
            }
            set
            {
                if (value < 0) value = 0;
                else if (value > MAX_ROW_COUNTS) value = MAX_ROW_COUNTS;
                _rowCounts = value;
                TranformDataItemList();
                OnPropertyChanged(nameof(RowCounts));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DataTableViewModel()
        {
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
                    ListDataItems.Add(new DataItem() 
                    {
                        Name = new Name() { Content = "" }, 
                        Value = new Value() { Content = 0 } 
                    });
                }
            }
            else if (Quantity < ListDataItems.Count)
            {
                for (int i = ListDataItems.Count - 1; i >= Quantity; i--)
                {
                    ListDataItems.RemoveAt(i);
                }
            }
            TranformDataItemList();
        }

        private void TranformDataItemList()
        {
            DataItems.Clear();
            int colCounts = ((Quantity - 1) / RowCounts) + 1;
            int endRowIndex = (Quantity - 1 ) % RowCounts;

            for (int rowIndex = 0; rowIndex < RowCounts; rowIndex++)
            {
                dynamic item = new ExpandoObject();
                var expandoDict = (IDictionary<string, object>)item;

                for (int colIndex = 0; colIndex < colCounts; colIndex++)
                {
                    if (colIndex == 0) //If this is the first row
                    {
                        expandoDict["RowIndex"] = rowIndex;
                    }

                    if (rowIndex > endRowIndex && colIndex == colCounts - 1) //If it is the last column, exceeded end row index.
                    {
                        continue;
                    }

                    expandoDict[$"Name{colIndex}"] = ListDataItems[colIndex * RowCounts + rowIndex].Name;
                    expandoDict[$"Value{colIndex}"] = ListDataItems[colIndex * RowCounts + rowIndex].Value;
                }
                DataItems.Add(item);
            }
            DataItemsChanged?.Invoke(this, new DataItemsChangedEventArg() { ColCounts = colCounts});
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

        private Name _name;
        public Name Name
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

        private Value _value;
        public Value Value
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

    public class DataItemsChangedEventArg
    {
        public int ColCounts;
    }

    public class Name
    {
        public string Content { get; set; }
    }

    public class Value
    {
        public int Content { get; set; }
    }
}
