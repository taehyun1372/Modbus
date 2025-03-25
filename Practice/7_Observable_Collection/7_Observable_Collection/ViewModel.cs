using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace _7_Observable_Collection
{
    public class ViewModel
    {
        public ObservableCollection<DataItem> DataItems { get; set; }
        

        public ViewModel()
        {
            DataItems = new ObservableCollection<DataItem>();
            for (int i = 0; i < 10; i++)
            {
                DataItems.Add(new DataItem());
            }
        }
    }

    public class DataItem
    {
        public DataItem()
        {
            Address = 0;
            Name = "";
            Value = 0;
        }
        public int Address { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

}
