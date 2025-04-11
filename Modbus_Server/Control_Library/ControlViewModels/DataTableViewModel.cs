using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Control_Library.ControlViewModels
{
    public class DataTableViewModel : INotifyPropertyChanged
    {
        private const int MAXROWCOUNTS = 100;
        private Color _indexColumnColor;
        public Color IndexColumnColor
        {
            get
            {
                return _indexColumnColor;
            }
            set
            {
                _indexColumnColor = value;
                OnPropertyChanged(nameof(IndexColumnColor));
            }
        }


        private int _indexColumnWidth;
        public int IndexColumnWidth
        {
            get
            {
                return _indexColumnWidth;
            }
            set
            {
                _indexColumnWidth = value;
                OnPropertyChanged(nameof(IndexColumnWidth));
            }
        }

        private ObservableCollection<Index> _rowIndex = new ObservableCollection<Index>();
        public ObservableCollection<Index> RowIndex
        {
            get
            {
                return _rowIndex;
            }
            set
            {
                _rowIndex = value;
            }
        }

        private int _rowCounts;
        public int RowCounts
        {
            get
            {
                return _rowCounts;
            }
            set
            {
                if (value < 0) value = 0;
                else if (value > MAXROWCOUNTS) value = MAXROWCOUNTS;
                _rowCounts = value;
                UpdateRowIndex();
                OnPropertyChanged(nameof(RowCounts));
            }
        }

        private void UpdateRowIndex()
        {
            if (RowCounts == RowIndex.Count)
            {
                return;
            }
            else if (RowCounts > RowIndex.Count)
            {
                for (int i = RowIndex.Count; i < RowCounts; i++)
                {
                    RowIndex.Add(new Index() { Value = i});
                }
            }
            else if (RowCounts < RowIndex.Count)
            {
                for (int i = RowIndex.Count - 1; i >= RowCounts; i--)
                {
                    RowIndex.RemoveAt(i);
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public DataTableViewModel()
        {
            IndexColumnColor = Colors.AliceBlue;
            RowCounts = 10;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Index
    {
        public int Value { get; set; }
    }

    public class DataItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

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
                OnPropertyChanged(nameof(Value));
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
