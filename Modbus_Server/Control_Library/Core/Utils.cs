using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Control_Library.Core
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return (_canExecute == null) ? true : (_canExecute(parameter));
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void CheckExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Utils
    {
        public static ushort[] ConvertBoolArrayToUshortArray(bool[] bools)
        {
            ushort[] result = new ushort[bools.Length];
            for (int i = 0; i < bools.Length; i++)
            {
                result[i] = (ushort)(bools[i] ? 1 : 0);
            }
            return result;
        }

        public static string ConvertEnumFunctionCodesToReadableString(EnumFunctionCodes functionCode)
        {
            var field = functionCode.GetType().GetField(functionCode.ToString());
            if (field == null) return functionCode.ToString();

            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute?.Description ?? functionCode.ToString();
        }
    }
}
