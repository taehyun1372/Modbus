using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace _30_Content_Control_Navigation
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private MainViewModel _model1;
        private MainViewModel _model2;
        private MainViewModel _model3;


        private MainView _view1;
        private MainView _view2;
        private MainView _view3;
        private object _view4;

        private object _view;

        public object View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                OnPropertyChanged(nameof(View));
            }
        }

        private RelayCommand _firstCommand;
        public ICommand FirstCommand
        {
            get
            {
                if (_firstCommand == null) _firstCommand = new RelayCommand(param => View = _view1);
                return _firstCommand;
            }
        }

        private RelayCommand _secondCommand;
        public ICommand SecondCommand
        {
            get
            {
                if (_secondCommand == null) _secondCommand = new RelayCommand(param => View = _view2);
                return _secondCommand;
            }
        }

        private RelayCommand _thirdCommand;
        public ICommand ThirdCommand
        {
            get
            {
                if (_thirdCommand == null) _thirdCommand = new RelayCommand(param => View = _view3);
                return _thirdCommand;
            }
        }

        private RelayCommand _fourthCommand;
        public ICommand FourthCommand
        {
            get
            {
                if (_fourthCommand == null) _fourthCommand = new RelayCommand(param => View = _view4);
                return _fourthCommand;
            }
        }


        public MainWindowViewModel()
        {
            _model1 = new MainViewModel() { DisplayName = "First Page" };
            _model2 = new MainViewModel() { DisplayName = "Second Page" };
            _model3 = new MainViewModel() { DisplayName = "Third Page" };

            _view1 = new MainView(_model1);
            _view2 = new MainView(_model2);
            _view3 = new MainView(_model3);
            _view4 = new DummyClass();

            View = _view1;
        }



        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
