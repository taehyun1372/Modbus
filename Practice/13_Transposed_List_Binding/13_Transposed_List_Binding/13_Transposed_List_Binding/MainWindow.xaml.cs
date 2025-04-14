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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;

namespace _13_Transposed_List_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            DataContext = this;


            DataItems = new ObservableCollection<ExpandoObject>();
            for (int rowIndex = 0; rowIndex < 10; rowIndex++)
            {
                dynamic item1 = new ExpandoObject();
                var expandoDict = (IDictionary<string, object>)item1;

                for (int colIndex = 0; colIndex < 3; colIndex++)
                {
                    expandoDict[$"Name{colIndex}"] = $"Test{colIndex}{rowIndex}";
                    expandoDict[$"Value{colIndex}"] = colIndex * 10 + rowIndex;
                }
                DataItems.Add(item1);

            }

            for (int colIndex = 0; colIndex < 3; colIndex++)
            {
                dgMainTable.Columns.Add(new DataGridTextColumn
                {
                    Header = $"Name{colIndex}",
                    Binding = new Binding($"Name{colIndex}")
                });

                dgMainTable.Columns.Add(new DataGridTextColumn
                {
                    Header = $"Value{colIndex}",
                    Binding = new Binding($"Value{colIndex}")
                });
            }
        }

        private ObservableCollection<ExpandoObject> _dataItems;
        public ObservableCollection<ExpandoObject> DataItems
        { 
            get
            {
                return _dataItems;
            }
            set
            {
                _dataItems = value;
            }
        }
    }

    public class DataItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name1;
        public string Name1
        {
            get
            { 
                return _name1; 
            }
            set
            {
                _name1 = value;
                OnPropertyChanged(nameof(Name1));
            }
        }

        private int _value1;
        public int Value1
        {
            get
            {
                return _value1;
            }
            set
            {
                _value1 = value;
                OnPropertyChanged(nameof(Value1));
            }
        }

        private string _name2;
        public string Name2
        {
            get
            {
                return _name2;
            }
            set
            {
                _name2 = value;
                OnPropertyChanged(nameof(Name2));
            }
        }

        private int _value2;
        public int Value2
        {
            get
            {
                return _value2;
            }
            set
            {
                _value2 = value;
                OnPropertyChanged(nameof(Value2));
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(name, new PropertyChangedEventArgs(name));
        }
    }
}
