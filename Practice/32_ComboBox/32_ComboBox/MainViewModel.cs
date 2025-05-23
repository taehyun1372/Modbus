using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace _32_ComboBox
{
    public enum FunctionCode
    {
        Coils = 0,
        DiscreteInputs = 1,
        HoldingRegisters = 2,
        InputRegisters = 3
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private FunctionCode _functionCode;
        public FunctionCode FunctionCode
        {
            get
            {
                return _functionCode;
            }
            set
            {
                _functionCode = value;
                OnPropertyChanged(nameof(FunctionCode));
            }
        }

        public IEnumerable<FunctionCode> FunctionCodes
        {
            get
            {
                return (IEnumerable<FunctionCode>)Enum.GetValues(typeof(FunctionCode));
            }
        }

        public MainViewModel()
        {
            FunctionCode = FunctionCode.HoldingRegisters;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
