using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace _11_Radio_Button_Behavior
{
    public class SetupPopupViewModel :INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<object, SettingFinishedEventArgs> SettingFinished;
        private int _customValue;
        public int CustomValue
        {
            get
            {
                return _customValue;
            }
            set
            {
                _customValue = value;
                Row = value;
                OnPropertyChanged(nameof(CustomValue));
            }
        }
        private bool _row10;
        public bool Row10
        {
            get
            {
                return _row10;
            }
            set
            {
                _row10 = value;
                Row = 10;
                OnPropertyChanged(nameof(Row10));
            }
        }

        private bool _row20;
        public bool Row20
        {
            get
            {
                return _row20;
            }
            set
            {
                _row20 = value;
                Row = 20;
                OnPropertyChanged(nameof(Row20));
            }
        }

        private bool _row30;
        public bool Row30
        {
            get
            {
                return _row30;
            }
            set
            {
                _row30 = value;
                Row = 30;
                OnPropertyChanged(nameof(Row30));
            }
        }

        private bool _rowCustom;
        public bool RowCustom
        {
            get
            {
                return _rowCustom;
            }
            set
            {
                _rowCustom = value;
                OnPropertyChanged(nameof(RowCustom));
            }
        }

        private int _row;
        public int Row
        {
            get
            {
                return _row;
            }
            set
            {
                _row = value;
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void OkayClickHandler(object sender, RoutedEventArgs e)
        {
            SettingFinished?.Invoke(this, new SettingFinishedEventArgs(Row));
        }
    }

    public class SettingFinishedEventArgs
    {
        public int Row;

        public SettingFinishedEventArgs(int row)
        {
            Row = row;
        }

    }

}
