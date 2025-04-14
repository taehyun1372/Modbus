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
using Control_Library.ControlViewModels;

namespace Control_Library.ControlViews
{
    /// <summary>
    /// Interaction logic for DataTableView.xaml
    /// </summary>
    public partial class DataTableView : UserControl
    {
        private DataTableViewModel _model;
        public DataTableView(DataTableViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
            _model.DataItemsChanged += DataItemsChangedEentHandler;
        }


        private void DataItemsChangedEentHandler(object sender, EventArgs e)
        {
            GenerateColumnsFromDictionaryKeys();
        }

        public void GenerateColumnsFromDictionaryKeys()
        {
            dgMainTable.Columns.Clear();
            if (_model.DataItems[0] == null)
            {
                return;
            }

            var keys = _model.DataItems[0].Keys;

            foreach (var key in keys)
            {
                var nameColumn = new DataGridTextColumn //Name Column
                {
                    Header = "Name",
                    Binding = new Binding($"[{key}]")
                };

                var valueColumn = new DataGridTextColumn //Name Column
                {
                    Header = key,
                    Binding = new Binding("Value")
                };


                dgMainTable.Columns.Add(nameColumn);
                dgMainTable.Columns.Add(valueColumn);
            }
        }
    }
}
