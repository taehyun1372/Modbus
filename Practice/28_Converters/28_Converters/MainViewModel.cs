using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace _28_Converters
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private bool _is10;
        public bool Is10
        {
            get
            {
                return _is10;
            }
            set
            {
                _is10 = value;
                if (_is10)
                {
                    Quantity = 10;
                }
                OnPropertyChanged(nameof(Is10));
            }
        }

        private bool _is20;
        public bool Is20
        {
            get
            {
                return _is20;
            }
            set
            {
                _is20 = value;
                if (_is20)
                {
                    Quantity = 20;
                }
                OnPropertyChanged(nameof(Is20));
            }
        }

        private bool _is30;
        public bool Is30
        {
            get
            {
                return _is30;
            }
            set
            {
                _is30 = value;
                if (_is30)
                {
                    Quantity = 30;
                }
                OnPropertyChanged(nameof(Is30));
            }
        }

        private bool _isCustom;
        public bool IsCustom
        {
            get
            {
                return _isCustom;
            }
            set
            {
                _isCustom = value;
                if (_isCustom)
                {
                    Quantity = CustomQuantity; 
                }

                OnPropertyChanged(nameof(IsCustom));
            }
        }

        private int _customQuantity;
        public int CustomQuantity
        {
            get
            {
                return _customQuantity;
            }
            set
            {
                _customQuantity = value;
                if (_isCustom)
                {
                    Quantity = _customQuantity;
                }
                OnPropertyChanged(nameof(CustomQuantity));
            }
        }

        public MainViewModel()
        {
            Is10 = true;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }


}
