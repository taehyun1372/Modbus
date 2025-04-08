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
using System.Collections.Specialized;

namespace _10_DataGrid_Dynamic_Ordering
{
    /// <summary>
    /// Interaction logic for MainDataGridView.xaml
    /// </summary>
    public partial class MainDataGridView : UserControl
    {
        private MainDataGridViewModel _model;
        public MainDataGridView(MainDataGridViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
            _model.DataItemsChanged += DataItems_CollectionChanged;
        }
        
        private void DataItems_CollectionChanged(object sender, EventArgs e)
        {
            GenerateColumnsFromDictionaryKeys();
        }

        public void GenerateColumnsFromDictionaryKeys()
        {
            myDataGrid.Columns.Clear();
            if (_model.DataItems[0] == null)
            {
                return;
            }

            var keys = _model.DataItems[0].Keys;

            foreach (var key in keys)
            {
                var column = new DataGridTextColumn
                {
                    Header = key,
                    Binding = new Binding($"[{key}]")
                };

                myDataGrid.Columns.Add(column);
            }
        }
    }
}
