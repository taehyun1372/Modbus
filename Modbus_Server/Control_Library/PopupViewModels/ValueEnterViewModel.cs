using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Control_Library.ControlViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Control_Library.PopupViewModels
{
    public class ValueEnterViewModel : INotifyPropertyChanged
    {
        private List<CheckBox> _listCheckBox = new List<CheckBox>();
        public List<CheckBox> ListCheckBox
        {
            get
            {
                return _listCheckBox;
            }
            set
            {
                _listCheckBox = value;
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

        public ValueEnterViewModel(DataTableViewModel dataTableViewModel, int rowIndex, int columnIndex, int initialValue = 0)
        {
            _dataTableViewModel = dataTableViewModel;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            Value = initialValue;
        }
        public void OkayClickHandler()
        {
            ValueItem valueItem = _dataTableViewModel.GetValueItemByIndex(RowIndex, ColumnIndex);
            if (valueItem != null)
            {
                valueItem.Content = Value;
            }
        }
        public void UpdateListCheckBox(int value)
        {
            foreach (CheckBox checkBox in ListCheckBox)
            {
                int tag = 0;
                if (int.TryParse(checkBox.Tag.ToString(), out tag))
                {
                    int key = 1 << tag;
                    bool check = (value & key) > 0;
                    checkBox.IsChecked = check;
                }
            }
        }

        public void ValueTextChangedHandler(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int value;
            bool isParseSuccess;
            bool isEmpty = false;
            isParseSuccess = int.TryParse(textBox.Text, out value);
            if (textBox.Text == "")
            {
                isEmpty = true;
                value = 0;
            }
            if (isParseSuccess || isEmpty)
            {
                UpdateListCheckBox(value);
            }
        }

        public void CheckBoxClickedHanlder(object sender, RoutedEventArgs e)
        {
            int total = 0;
            foreach (CheckBox checkBox in ListCheckBox)
            {
                int tag = 0;
                bool? isChecked = checkBox.IsChecked;
                if (int.TryParse(checkBox.Tag.ToString(), out tag))
                {
                    if ((bool)isChecked)
                    {
                        total += 1 << tag;
                    }
                }
            }
            Value = total;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
