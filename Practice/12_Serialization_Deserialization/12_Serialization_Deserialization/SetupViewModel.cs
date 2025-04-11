using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace _12_Serialization_Deserialization
{
    public class SetupViewModel : INotifyPropertyChanged
    {
        public enum FunctionTypes
        {
            coil = 0,
            status = 1,
            inputRegister = 2,
            holdingRegister = 3
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private FunctionTypes _functontype;
        public FunctionTypes FunctionType
        {
            get
            {
                return _functontype;
            }
            set
            {
                _functontype = value;
                if (value == FunctionTypes.coil)
                {
                    Coil = true;
                    Status = false;
                    InputRegister = false;
                    HoldingRegister = false;
                }
                else if(value == FunctionTypes.status)
                {
                    Coil = false;
                    Status = true;
                    InputRegister = false;
                    HoldingRegister = false;
                }
                else if (value == FunctionTypes.inputRegister)
                {
                    Coil = false;
                    Status = false;
                    InputRegister = true;
                    HoldingRegister = false;
                }
                else if (value == FunctionTypes.holdingRegister)
                {
                    Coil = false;
                    Status = false;
                    InputRegister = false;
                    HoldingRegister = true;
                }
            }
        }

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
                OnPropertyChanged(nameof(RowSetting));
            }
        }

        private int _quantitySetting;
        public int QuantitySetting
        {
            get
            {
                return _quantitySetting;
            }
            set
            {
                _quantitySetting = value;
                OnPropertyChanged(nameof(QuantitySetting));
            }
        }

        private bool _coil;
        public bool Coil
        {
            get
            {
                return _coil;
            }
            set
            {
                _coil = value;
                if (value)
                {
                    _functontype = FunctionTypes.coil;
                }
                
                OnPropertyChanged(nameof(Coil));
            }
        }

        private bool _status;
        public bool Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                if (value)
                {
                    _functontype = FunctionTypes.status;
                }
                    
                OnPropertyChanged(nameof(Status));
            }
        }

        private bool _inputRegister;
        public bool InputRegister
        {
            get
            {
                return _inputRegister;
            }
            set
            {
                _inputRegister = value;
                if (value)
                {
                    _functontype = FunctionTypes.inputRegister;
                }
                
                OnPropertyChanged(nameof(InputRegister));
            }
        }

        private bool _holidngRegister;
        public bool HoldingRegister
        {
            get
            {
                return _holidngRegister;
            }
            set
            {
                _holidngRegister = value;
                if (value)
                {
                    _functontype = FunctionTypes.holdingRegister;
                }
                
                OnPropertyChanged(nameof(HoldingRegister));
            }
        }

        private bool _pLCAddress;
        public bool PLCAddress
        {
            get
            {
                return _pLCAddress;
            }
            set
            {
                _pLCAddress = value;
                OnPropertyChanged(nameof(PLCAddress));
            }
        }

        private bool _addressVisible;
        public bool AddressVisible
        {
            get
            {
                return _addressVisible;
            }
            set
            {
                _addressVisible = value;
                OnPropertyChanged(nameof(AddressVisible));
            }
        }

        public SetupViewModel()
        {
            RowSetting = 10;
            QuantitySetting = 5;
            FunctionType = FunctionTypes.holdingRegister;
            PLCAddress = true;
            AddressVisible = false;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
