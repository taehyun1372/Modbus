using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace _29_Relay_Command
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (_test1Command != null)
                {
                    var relayComamnd = (RelayCommand)_test1Command;
                    relayComamnd.CheckExecute();
                }
                OnPropertyChanged(nameof(Value));
            }
        }

        private ICommand _test1Command;

        public ICommand Test1Command
        {
            get
            {
                if (_test1Command == null)
                {
                    _test1Command = new RelayCommand(_ => MessageBox.Show($"{this.Value}"), _ => this.Value > 100);
                }
                return _test1Command;
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public class MyICommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private MainViewModel _model;

            public MyICommand(MainViewModel model)
            {
                _model = model;
            }

            public bool CanExecute(object parameter)
            {
                return (_model.Value == 100);
            }

            public void Execute(object parameter)
            {
                MessageBox.Show("Something");
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
