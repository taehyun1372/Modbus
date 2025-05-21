using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _30_Content_Control_Navigation
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<object> _exectute;
        public Predicate<object> _canExectute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _exectute = execute;
            _canExectute = canExecute;
        }

        public void CheckCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return (_canExectute == null) ? true : _canExectute(parameter);
        }

        public void Execute(object parameter)
        {
            _exectute(parameter);
        }
    }

    public class DummyClass
    {
        public int Id { get; set; }
    }
}
