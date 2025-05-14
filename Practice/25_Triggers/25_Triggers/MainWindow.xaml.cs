using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace _25_Triggers
{

    public class DataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    OnPropertyChanged(nameof(IsRunning));
                }
            }
        }

        private int _speed;
        public int Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }
    }

    public partial class MainWindow : Window
    {

        private DataModel _dataModel;
        public MainWindow()
        {
            InitializeComponent();
            _dataModel = new DataModel();
            this.DataContext = _dataModel;
            
            _dataModel.IsRunning = true;  // Initial value of IsRunning
            _dataModel.Speed = 20;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the value of IsRunning
            _dataModel.IsRunning = !_dataModel.IsRunning;
        }
    }
}
