﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Control_Library.Core
{
    class RelayCommand : ICommand
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
}
