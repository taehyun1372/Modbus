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
            _model.Quantity = DataTableViewModel.DEFAULT_QUANTITY;
        }


        private void DataItemsChangedEentHandler(object sender, DataItemsChangedEventArg e)
        {
            GenerateColumnsFromDictionaryKeys(e.ColCounts);
        }

        public void GenerateColumnsFromDictionaryKeys(int colCount)
        {
            dgMainTable.Columns.Clear();

            //Column Index
            var indexColumn = new DataGridTextColumn();
            indexColumn.Header = "";
            indexColumn.Binding = new Binding("RowIndex");
            indexColumn.IsReadOnly = true;
            indexColumn.Width = _model.IndexColumnWidth;

            Style cellStyle = new Style(typeof(DataGridCell));
            cellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, _model.IndexColumnColor));
            indexColumn.CellStyle = cellStyle;

            dgMainTable.Columns.Add(indexColumn);

            var customCellStyle = new Style(typeof(DataGridCell));

            // Default setters
            cellStyle.Setters.Add(new Setter(DataGridCell.IsTabStopProperty, true));
            cellStyle.Setters.Add(new Setter(DataGridCell.FocusableProperty, true));
            cellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, Brushes.Transparent));
            // Trigger for IsReadOnly == true
            var trigger = new DataTrigger
            {
                Binding = new Binding("IsReadOnly"),
                Value = true
            };
            trigger.Setters.Add(new Setter(DataGridCell.IsTabStopProperty, false));
            trigger.Setters.Add(new Setter(DataGridCell.FocusableProperty, false));
            trigger.Setters.Add(new Setter(DataGridCell.BackgroundProperty, Brushes.LightGray));

            customCellStyle.Triggers.Add(trigger);

            for (int colIndex = 0; colIndex < colCount; colIndex++)
            {
                var nameColumn = new DataGridTextColumn()
                {
                    Header = "Name",
                    Binding = new Binding($"Name{colIndex}.Content")
                    {
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    },
                    Width = _model.NameColumnWidth,
                    CanUserSort = false
                };

                if (colIndex == colCount - 1)
                {
                    nameColumn.CellStyle = customCellStyle;
                }

                dgMainTable.Columns.Add(nameColumn);

                var valueColumn = new DataGridTextColumn()
                {
                    Header = colIndex.ToString("D4"),
                    Binding = new Binding($"Value{colIndex}.Content")
                    {
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    },
                    Width = _model.ValueColumnWidth,
                    CanUserSort = false
                };

                if (colIndex == colCount - 1)
                {
                    valueColumn.CellStyle = customCellStyle;
                }

                dgMainTable.Columns.Add(valueColumn);

            }
        }
    }
}
