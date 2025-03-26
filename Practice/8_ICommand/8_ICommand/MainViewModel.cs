using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace _8_ICommand
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _inputString;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _checkBoxAvailable;
        public bool CheckBoxAvailable
        {
            get
            {
                return _checkBoxAvailable;
            }
            set
            {
                _checkBoxAvailable = value;
                OnPropertyChanged(nameof(CheckBoxAvailable));
            }
        }

        public string InputString
        {
            get
            {
                return _inputString;
            }
            set
            {
                _inputString = value;
                OnPropertyChanged(nameof(InputString));
                if (string.IsNullOrEmpty(_inputString))
                {
                    ((MyICommand)ButtonICommand).CheckExecute(false);
                    CheckBoxAvailable = false;
                }
                else
                {
                    ((MyICommand)ButtonICommand).CheckExecute(true);
                    CheckBoxAvailable = true;
                }
            }
        }

        public void CheckBoxEventHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Input String : {InputString}");
        }

        private ICommand _buttonICommand;
        public ICommand ButtonICommand
        {
            get
            {
                if (_buttonICommand == null)
                {
                    _buttonICommand = new MyICommand(this);
                }



                return _buttonICommand;
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public MainViewModel()
        {
            InputString = "Default Text";
        }
    }
    public class MyICommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private bool _canExecute;
        private MainViewModel _model;
        public MyICommand(MainViewModel model)
        {
            _model = model;
        }

        public void CheckExecute(bool canExecute)
        {
            _canExecute = canExecute;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show($"Input String : {_model.InputString}");
        }
    }
}
