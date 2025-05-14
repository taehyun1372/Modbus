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
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;

namespace _26_ListViewExport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<DataModel> _data = new ObservableCollection<DataModel>();
        public ObservableCollection<DataModel> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            for (int i = 0; i < 100; i++)
            {
                Data.Add(new DataModel()
                {
                    Index = i,
                    Name = $"vavle {i}",
                    Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            PromptSaveAs();
        }

        public void PromptSaveAs()
        {
            var dialog = new SaveFileDialog
            {
                Title = "Export to CSV",
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                DefaultExt = "csv",
                FileName = "export.csv"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filePath = dialog.FileName;
                ExportListViewData(filePath);  // Your export method
            }
            else
            {
                MessageBox.Show("Please select the correct file path again");
            }
        }
        public void ExportListViewData(string filePath)
        {
            var lines = new List<string>() { $"{ nameof(DataModel.Index)}, {nameof(DataModel.Date)}, {nameof(DataModel.Name)}" };
            foreach (var item in Data)
            {
                string line = $"{item.Index}, {item.Date}, {item.Name}";
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
            MessageBox.Show("File Export Success");
        }
    }

    public class DataModel
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
