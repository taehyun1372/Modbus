using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections.Specialized;
using WpfApp1.Core;

namespace WpfApp1.ViewModels
{
    public class DataColumnViewModel
    {
        private ObservableCollection<DataItem> _dataItems = new ObservableCollection<DataItem>();
        public ObservableCollection<DataItem> DataItems
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

        public DataColumnViewModel(ServerDataManager manager)
        {

            DataItems.Add(new DataItem() { Address = 1, Name = "Test 1", Value = 1 });
            DataItems.Add(new DataItem() { Address = 2, Name = "Test 2", Value = 2 });
            DataItems.Add(new DataItem() { Address = 3, Name = "Test 3", Value = 3 });
            DataItems.Add(new DataItem() { Address = 4, Name = "Test 4", Value = 4 });
            DataItems.Add(new DataItem() { Address = 5, Name = "Test 5", Value = 5 });
            DataItems.Add(new DataItem() { Address = 6, Name = "Test 6", Value = 6 });
            DataItems.Add(new DataItem() { Address = 7, Name = "Test 7", Value = 7 });
            DataItems.Add(new DataItem() { Address = 8, Name = "Test 8", Value = 8 });

            foreach (var item in DataItems)
            {
                item.DataChanged += manager.DataChangeHandler;
            }

            DataItems.CollectionChanged += DummyMethod;
        }

        public void DummyMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("A value changed");
        }
    }
    public class DataItem
    {
        public event EventHandler<DataChangedEventArgs> DataChanged;

        public int Address { get; set; }

        public string Name { get; set; }

        public ushort _value = 0;
        public ushort Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnValueChanged(_value);
            }
        }

        public void OnValueChanged(int value)
        {
            DataChanged?.Invoke(this, new DataChangedEventArgs(Value, Address));
        }
    }

    public class DataChangedEventArgs
    {
        public ushort Value { get; }
        public int Address { get; }
        public DataChangedEventArgs(ushort value, int address)
        {
            Value = value;
            Address = address;
        }
    }
}
