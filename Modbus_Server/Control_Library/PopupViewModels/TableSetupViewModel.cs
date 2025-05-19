using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace Control_Library.PopupViewModels
{
    public class TableSetupViewModel : INotifyPropertyChanged
    {
        private int _rowCounts;
        public int RowCounts
        {
            get { return _rowCounts; }
            set
            {
                _rowCounts = value;
                OnPropertyChanged(nameof(RowCounts));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public event Action<object, SetupFinishedEventArg> SetupFinished;
        public event PropertyChangedEventHandler PropertyChanged;

        public TableSetupViewModel()
        {
            RowCounts = 10;
            Quantity = 10;
        }

        public void OkayClickedHandler(object sender, RoutedEventArgs e)
        {
            SetupFinished?.Invoke(this, new SetupFinishedEventArg(RowCounts, Quantity));
        }

        public void CancelClickedHandler(object sender, RoutedEventArgs e)
        {

        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class SetupFinishedEventArg
    {
        public int Row { get; set; }
        public int Quantity { get; set; }

        public SetupFinishedEventArg(int row, int quantity)
        {
            Row = row;
            Quantity = quantity;
        }
    }
        

}
