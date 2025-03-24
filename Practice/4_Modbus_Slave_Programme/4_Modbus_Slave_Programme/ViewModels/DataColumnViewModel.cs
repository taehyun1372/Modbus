using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace _4_Modbus_Slave_Programme.ViewModels
{
    public class DataColumnViewModel
    {
        public ObservableCollection<DataItem> DataItems { get; set; }

        public DataColumnViewModel()
        {
            DataItems = new ObservableCollection<DataItem>();

            DataItems.Add(new DataItem() { Address = 100, Name = "Test 1", Value = 0 });
            DataItems.Add(new DataItem() { Address = 101, Name = "Test 2", Value = 1 });
            DataItems.Add(new DataItem() { Address = 102, Name = "Test 3", Value = 2 });
            DataItems.Add(new DataItem() { Address = 103, Name = "Test 4", Value = 3 });
            DataItems.Add(new DataItem() { Address = 104, Name = "Test 5", Value = 4 });
            DataItems.Add(new DataItem() { Address = 105, Name = "Test 6", Value = 5 });
            DataItems.Add(new DataItem() { Address = 106, Name = "Test 7", Value = 6 });
            DataItems.Add(new DataItem() { Address = 107, Name = "Test 8", Value = 7 });
        }

    }

    public class DataItem
    {
        public int Address { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
