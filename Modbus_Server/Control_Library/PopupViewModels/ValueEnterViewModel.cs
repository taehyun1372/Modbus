using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Control_Library.ControlViewModels;
using System.ComponentModel;

namespace Control_Library.PopupViewModels
{
    public class ValueEnterViewModel : INotifyPropertyChanged
    {
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
        private int _rowIndex;
        public int RowIndex
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

        private int _columnIndex;
        public int ColumnIndex
        {
            get
            {
                return _columnIndex;
            }
            set
            {
                _columnIndex = value;
            }
        }
        private DataTableViewModel _dataTableViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public ValueEnterViewModel(DataTableViewModel dataTableViewModel, int rowIndex, int columnIndex)
        {
            _dataTableViewModel = dataTableViewModel;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            Value = 0;
        }
        public void OkayClickHandler()
        {
            ValueItem valueItem = _dataTableViewModel.GetValueItemByIndex(RowIndex, ColumnIndex);
            if (valueItem != null)
            {
                valueItem.Content = Value;
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
