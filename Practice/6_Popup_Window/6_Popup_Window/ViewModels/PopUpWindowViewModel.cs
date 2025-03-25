using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _6_Popup_Window.ViewModels
{
    public class PopUpWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Address { get; set; }
        private bool[] _bits = new bool[16];
        private MainViewModel _mainViewModel;

        public PopUpWindowViewModel(MainViewModel mainViewModel, int address)
        {
            _mainViewModel = mainViewModel;
            Address = address;
        }

        public bool Bit0
        {
            get
            {
                return _bits[0];
            }
            set
            {
                _bits[0] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit0)));
            }
        }
        public bool Bit1
        {
            get
            {
                return _bits[1];
            }
            set
            {
                _bits[1] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit1)));
            }
        }

        public bool Bit2
        {
            get
            {
                return _bits[2];
            }
            set
            {
                _bits[2] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit2)));
            }
        }

        public bool Bit3
        {
            get
            {
                return _bits[3];
            }
            set
            {
                _bits[3] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit3)));
            }
        }

        public bool Bit4
        {
            get
            {
                return _bits[4];
            }
            set
            {
                _bits[4] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit4)));
            }
        }

        public bool Bit5
        {
            get
            {
                return _bits[5];
            }
            set
            {
                _bits[5] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit5)));
            }
        }

        public bool Bit6
        {
            get
            {
                return _bits[6];
            }
            set
            {
                _bits[6] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit6)));
            }
        }

        public bool Bit7
        {
            get
            {
                return _bits[7];
            }
            set
            {
                _bits[7] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit7)));
            }
        }

        public bool Bit8
        {
            get
            {
                return _bits[8];
            }
            set
            {
                _bits[8] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit8)));
            }
        }

        public bool Bit9
        {
            get
            {
                return _bits[9];
            }
            set
            {
                _bits[9] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit9)));
            }
        }

        public bool Bit10
        {
            get
            {
                return _bits[10];
            }
            set
            {
                _bits[10] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit10)));
            }
        }

        public bool Bit11
        {
            get
            {
                return _bits[11];
            }
            set
            {
                _bits[11] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit11)));
            }
        }

        public bool Bit12
        {
            get
            {
                return _bits[12];
            }
            set
            {
                _bits[12] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit12)));
            }
        }

        public bool Bit13
        {
            get
            {
                return _bits[13];
            }
            set
            {
                _bits[13] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit13)));
            }
        }

        public bool Bit14
        {
            get
            {
                return _bits[14];
            }
            set
            {
                _bits[14] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit14)));
            }
        }

        public bool Bit15
        {
            get
            {
                return _bits[15];
            }
            set
            {
                _bits[15] = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Bit15)));
            }
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
            int value = 0;
            value = BitsToInt(_bits);
            UpdateDataValue(value);
        }

        public int BitsToInt(bool[] bits)
        {
            int accuValue = 0;
            for (int i = 0; i < 16; i++)
            {
                short tempValue = 0b_0000_0000_0000_0001;
                if (bits[i] == true)
                {
                    var j = tempValue << i;
                    accuValue += j;
                }
            }
            return accuValue;
        }

        public void UpdateDataValue(int value)
        {
            _mainViewModel.DataItems[Address].Value = value; 
        }
    }
}
