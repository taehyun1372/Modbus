using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading;

namespace _3_DataGrid_Binding.ViewModels
{
    public class DataGridViewModel
    {
        private ObservableCollection<DataItem> _dataSet = new ObservableCollection<DataItem>();
        private ObservableCollection<DataItem> _prevDataSet = new ObservableCollection<DataItem>();
        public ObservableCollection<DataItem> DataSet
        {
            get
            {
                return _dataSet;

            }
            set
            {
                _dataSet = value;
            }
        }

        public DataGridViewModel()
        {
            //Initialise.. 
            DataSet.Add(new DataItem() { Address = 1, Name = "Test 1", Value = 0 });
            DataSet.Add(new DataItem() { Address = 2, Name = "Test 2", Value = 1 });
            DataSet.Add(new DataItem() { Address = 3, Name = "Test 3", Value = 2 });
            DataSet.Add(new DataItem() { Address = 4, Name = "Test 4", Value = 3 });
            DataSet.Add(new DataItem() { Address = 5, Name = "Test 5", Value = 4 });
            DataSet.Add(new DataItem() { Address = 6, Name = "Test 6", Value = 5 });
            DataSet.Add(new DataItem() { Address = 7, Name = "Test 7", Value = 6 });
            DataSet.Add(new DataItem() { Address = 8, Name = "Test 8", Value = 7 });
            DataSet.Add(new DataItem() { Address = 9, Name = "Test 9", Value = 8 });

            //Initial Sync
            Syncronise();

            Thread th = new Thread(() => Process());
            th.Start();
        }

        private void Syncronise()
        {
            _prevDataSet.Clear();
            foreach (var item in _dataSet)
            {
                _prevDataSet.Add(new DataItem() { Address = item.Address, Name = item.Name, Value = item.Value });
            }
        }

        private void Process()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (CheckChanged())
                {
                    MessageBox.Show(StringFormatting(DataSet));
                    Syncronise();
                }
            }
        }

        private bool CheckChanged()
        {
            bool changed = false;

            for (int i=0 ; i < 9; i++ )
            {
                if (_dataSet[i].Name != _prevDataSet[i].Name)
                {
                    changed = true;
                }

                if (_dataSet[i].Address != _prevDataSet[i].Address)
                {
                    changed = true;
                }

                if (_dataSet[i].Value != _prevDataSet[i].Value)
                {
                    changed = true;
                }
            }
            return changed;
        }

        private string StringFormatting(ObservableCollection<DataItem> list)
        {
            string message = "Data has been changed";
            foreach (var item in list)
            {
                message += "\n";
                message += $"{item.Address} {item.Name} {item.Value}";
            }
            return message;
        }


    }

    public class DataItem
    {
        public int Address { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
