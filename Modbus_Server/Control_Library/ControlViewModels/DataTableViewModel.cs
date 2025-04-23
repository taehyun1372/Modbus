using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Windows;
using Control_Library.PopupViewModels;
using Control_Library.PopupViews;

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
        public const int DEFAULT_START_ADDRESS = 0;

        private ValueEnterView _valueEnterView;
        private ValueEnterViewModel _valueEnterViewModel;

        private int _startAddress = DEFAULT_START_ADDRESS;
        public int StartAddress
        {
            get
            {
                return _startAddress;
            }
            set
            {
                _startAddress = value;
                TranformDataItemList();
            }
        }

        public int StartRowIndex
        {
            get
            {
                return _startAddress % RowCounts;
            }
        }

        public int EndRowIndex
        {
            get
            {
                return (StartRowIndex + Quantity) - ((ColCounts -1) * RowCounts) - 1;
            }
        }

        public int ColCounts
        {
            get
            {
                return (((StartRowIndex + Quantity) - 1) / RowCounts) + 1;
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

        private Brush _indexColumnColor = new SolidColorBrush(Colors.Transparent);
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
                        NameItem = new NameItem() { Content = "" },
                        ValueItem = new ValueItem() { Content = 0 },
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

            for (int rowIndex = 0; rowIndex < RowCounts; rowIndex++)
            {
                dynamic item = new ExpandoObject();
                var expandoDict = (IDictionary<string, object>)item;

                for (int colIndex = 0; colIndex <= ColCounts; colIndex++)
                {
                    var skipCondition = false;

                    if (colIndex == 0) //If this is the first column, it is index column
                    {
                        expandoDict["RowIndex"] = rowIndex;
                        skipCondition = true;
                    }

                    if (colIndex == 1) //If this is the second column, we need to consider staring index
                    {
                        if( rowIndex < StartRowIndex)
                        {
                            expandoDict["IsFirstColumnReadOnly"] = true;
                            skipCondition = true;
                        }
                        else
                        {
                            expandoDict["IsFirstColumnReadOnly"] = false;
                        }
                    }

                    if (colIndex == ColCounts) //If it is the last column, exceeded end row index.
                    {
                        if (rowIndex > EndRowIndex)
                        {
                            expandoDict["IsLastColumnReadOnly"] = true;
                            skipCondition = true;
                        }
                        else if (ColCounts == 1 && rowIndex < StartRowIndex)
                        {
                            expandoDict["IsLastColumnReadOnly"] = true;
                            skipCondition = true;
                        }
                        else
                        {
                            expandoDict["IsLastColumnReadOnly"] = false;
                        }
                    }

                    if (skipCondition)
                    {
                        continue;
                    }
                    else
                    {
                        expandoDict[$"Name{colIndex}"] = ListDataItems[(colIndex - 1) * RowCounts + rowIndex - StartRowIndex].NameItem;
                        expandoDict[$"Value{colIndex}"] = ListDataItems[(colIndex - 1) * RowCounts + rowIndex - StartRowIndex].ValueItem;
                    }
                }
                DataItems.Add(item);
            }
            DataItemsChanged?.Invoke(this, new DataItemsChangedEventArg() { ColCounts = ColCounts});
        }

        public void MainTableMouseDoubleClickHandler(int rowIndex, int columnIndex)
        {
            int value = GetValueItemByIndex(rowIndex, columnIndex).Content;
            _valueEnterViewModel = new ValueEnterViewModel(this, rowIndex, columnIndex, value);
            _valueEnterView = new ValueEnterView(_valueEnterViewModel);
            _valueEnterView.Show();
        }

        public ValueItem GetValueItemByIndex(int rowIndex, int columnIndex)
        {
            ValueItem valueItem = null;
            int logicalColumnIndex = (columnIndex + 1) / 2;
            int index = (logicalColumnIndex - 1) * RowCounts + rowIndex - StartRowIndex;
            if (ListDataItems[index].ValueItem != null)
            {
                valueItem = ListDataItems[index].ValueItem;
            }
            return valueItem;
        }

        public bool VerifyEnabledCellByIndex(int rowIndex, int columnIndex)
        {
            bool enabled = true;

            if (columnIndex == 0)
            {
                enabled = false;
            }

            int logicalColumnIndex = (columnIndex + 1) / 2;
            
            if (logicalColumnIndex == 1 && rowIndex < StartRowIndex)
            {
                enabled = false;
            }

            if (logicalColumnIndex == ColCounts && rowIndex > EndRowIndex)
            {
                enabled = false;
            }
            return enabled;
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

        private NameItem _nameItem;
        public NameItem NameItem
        {
            get
            {
                return _nameItem;
            }
            set
            {
                _nameItem = value;
                OnPropertyChanged(nameof(NameItem));
            }
        }

        private ValueItem _valueItem;
        public ValueItem ValueItem
        {
            get
            {
                return _valueItem;
            }
            set
            {
                _valueItem = value;
                OnPropertyChanged(nameof(ValueItem));
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

    public class NameItem : INotifyPropertyChanged
    {
        public string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class ValueItem : INotifyPropertyChanged
    {
        private int _content;
        public int Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
