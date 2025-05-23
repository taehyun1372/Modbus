using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace _32_ComboBox
{
    public enum FunctionCode
    {
        [Description("Coil Status")]
        Coils = 0,

        [Description("Input Status")]
        DiscreteInputs = 1,

        [Description("Holding Register")]
        HoldingRegisters = 2,

        [Description("Input Register")]
        InputRegisters = 3
    }

    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute?.Description ?? value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private FunctionCode _function;
        public FunctionCode Function
        {
            get
            {
                return _function;
            }
            set
            {
                _function = value;
                OnPropertyChanged(nameof(Function));
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
            Function = FunctionCode.HoldingRegisters;

            var type = Function.GetType();
            Console.WriteLine(type);

            var field = Function.GetType().GetField(Function.ToString());
            Console.WriteLine(field);

            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            Console.WriteLine(attribute.Description);
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
