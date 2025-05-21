using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using Control_Library.ControlViewModels;

namespace Control_Library.PopupViewModels
{
    public class TableSetupViewModel : INotifyPropertyChanged
    {
        private DataTableViewModel _dataTable;
        public DataTableViewModel DataTable
        {
            get
            {
                return _dataTable;
            }
            set
            {
                _dataTable = value;
            }
        }

        private int _startAddress;
        public int StartAddress
        {
            get
            {
                return _startAddress;
            }
            set
            {
                _startAddress = value;
                OnPropertyChanged(nameof(StartAddress));
            }
        }

        private int _rowCounts;
        public int RowCounts
        {
            get { return _rowCounts; }
            set
            {
                if (_rowCounts == value) return;
                _rowCounts = value;
                OnPropertyChanged(nameof(RowCounts));

                //Radio button sync
                if (_rowCounts == 10)
                {
                    IsRowCounts10 = true;
                }
                else if (_rowCounts == 20)
                {
                    IsRowCounts20 = true;
                }
                else if (_rowCounts == 30)
                {
                    IsRowCounts30 = true;
                }
                else if (_rowCounts == Quantity)
                {
                    IsRowCountsFitQuantity = true;
                }
                else
                {
                    IsRowCountsCustom = true;
                    CustomRowCounts = _rowCounts;
                }
            }
        }

        private int _customRowCounts;
        public int CustomRowCounts
        {
            get
            {
                return _customRowCounts;
            }
            set
            {
                if (_customRowCounts == value) return;
                _customRowCounts = value;
                OnPropertyChanged(nameof(CustomRowCounts));
                if (IsRowCountsCustom) RowCounts = value;
            }
        }

        private bool _isRowCounts10;
        public bool IsRowCounts10
        {
            get
            {
                return _isRowCounts10;
            }
            set
            {
                _isRowCounts10 = value;
                if (_isRowCounts10) RowCounts = 10;
                OnPropertyChanged(nameof(IsRowCounts10));
            }
        }

        private bool _isRowCounts20;
        public bool IsRowCounts20
        {
            get
            {
                return _isRowCounts20;
            }
            set
            {
                _isRowCounts20 = value;
                if (_isRowCounts20) RowCounts = 20;
                OnPropertyChanged(nameof(IsRowCounts20));
            }
        }

        private bool _isRowCounts30;
        public bool IsRowCounts30
        {
            get
            {
                return _isRowCounts30;
            }
            set
            {
                _isRowCounts30 = value;
                if (_isRowCounts30) RowCounts = 30;
                OnPropertyChanged(nameof(IsRowCounts30));
            }
        }

        private bool _isRowCountsFitQuantity;
        public bool IsRowCountsFitQuantity
        {
            get
            {
                return _isRowCountsFitQuantity;
            }
            set
            {
                _isRowCountsFitQuantity = value;
                if (_isRowCountsFitQuantity) RowCounts = Quantity;
                OnPropertyChanged(nameof(IsRowCountsFitQuantity));
            }
        }

        private bool _isRowCountsCustom;
        public bool IsRowCountsCustom
        {
            get
            {
                return _isRowCountsCustom;
            }
            set
            {
                _isRowCountsCustom = value;
                if (_isRowCountsCustom) CustomRowCounts = RowCounts;
                OnPropertyChanged(nameof(IsRowCountsCustom));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity == value) return;
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));

                //Radio button sync
                if (_quantity == 10)
                {
                    IsQuantity10 = true;
                }
                else if (_quantity == 20)
                {
                    IsQuantity20 = true;
                }
                else if (_quantity == 30)
                {
                    IsQuantity30 = true;
                }
                else
                {
                    IsQuantityCustom = true;
                    CustomQuantity = _quantity;
                }
            }
        }

        private int _customQuantity;
        public int CustomQuantity
        {
            get
            {
                return _customQuantity;
            }
            set
            {
                if (_customQuantity == value) return;
                _customQuantity = value;
                OnPropertyChanged(nameof(CustomQuantity));
                if (IsQuantityCustom) Quantity = value;
            }
        }

        private bool _isQuantity10;
        public bool IsQuantity10
        {
            get
            {
                return _isQuantity10;
            }
            set
            {
                _isQuantity10 = value;
                if (_isQuantity10) Quantity = 10;
                OnPropertyChanged(nameof(IsQuantity10));
            }
        }

        private bool _isQuantity20;
        public bool IsQuantity20
        {
            get
            {
                return _isQuantity20;
            }
            set
            {
                _isQuantity20 = value;
                if (_isQuantity20) Quantity = 20;
                OnPropertyChanged(nameof(IsQuantity20));
            }
        }

        private bool _isQuantity30;
        public bool IsQuantity30
        {
            get
            {
                return _isQuantity30;
            }
            set
            {
                _isQuantity30 = value;
                if (_isQuantity30) Quantity = 30;
                OnPropertyChanged(nameof(IsQuantity30));
            }
        }

        private bool _isQuantityCustom;
        public bool IsQuantityCustom
        {
            get
            {
                return _isQuantityCustom;
            }
            set
            {
                _isQuantityCustom = value;
                if (_isQuantityCustom) CustomQuantity = Quantity;
                OnPropertyChanged(nameof(IsQuantityCustom));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TableSetupViewModel(DataTableViewModel dataTable)
        {
            DataTable = dataTable;
            Quantity = DataTable.Quantity;
            RowCounts = DataTable.RowCounts;
            StartAddress = DataTable.StartAddress;
        }

        public void OnOkayClicked(object sender, RoutedEventArgs e)
        {
            if (IsRowCountsFitQuantity)
            {
                DataTable.RowCounts = Quantity;
            }
            else
            {
                DataTable.RowCounts = RowCounts;
            }
            
            DataTable.Quantity = Quantity;
            DataTable.StartAddress = StartAddress;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
