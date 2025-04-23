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
            indexColumn.CanUserResize = false;

            Style indexColumnCellStyle = new Style(typeof(DataGridCell));
            indexColumnCellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, _model.IndexColumnColor));
            indexColumnCellStyle.Setters.Add(new Setter(DataGridCell.ForegroundProperty, Brushes.Black));
            indexColumnCellStyle.Setters.Add(new Setter(DataGridCell.FocusableProperty, false));

            indexColumn.CellStyle = indexColumnCellStyle;

            dgMainTable.Columns.Add(indexColumn);

            var firstColumnCellStyle = new Style(typeof(DataGridCell));

            // Default setters
            firstColumnCellStyle.Setters.Add(new Setter(DataGridCell.IsTabStopProperty, true));
            firstColumnCellStyle.Setters.Add(new Setter(DataGridCell.FocusableProperty, true));
            firstColumnCellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, Brushes.Transparent));

            // Trigger for IsReadOnly == true
            var firstColumnTrigger = new DataTrigger
            {
                Binding = new Binding("IsFirstColumnReadOnly"),
                Value = true
            };
            firstColumnTrigger.Setters.Add(new Setter(DataGridCell.IsTabStopProperty, false));
            firstColumnTrigger.Setters.Add(new Setter(DataGridCell.FocusableProperty, false));
            firstColumnTrigger.Setters.Add(new Setter(DataGridCell.BackgroundProperty, Brushes.LightGray));

            firstColumnCellStyle.Triggers.Add(firstColumnTrigger);

            var lastColumnCellStyle = new Style(typeof(DataGridCell));

            // Default setters
            lastColumnCellStyle.Setters.Add(new Setter(DataGridCell.IsTabStopProperty, true));
            lastColumnCellStyle.Setters.Add(new Setter(DataGridCell.FocusableProperty, true));
            lastColumnCellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, Brushes.Transparent));

            // Trigger for IsReadOnly == true
            var lastColumnTrigger = new DataTrigger
            {
                Binding = new Binding("IsLastColumnReadOnly"),
                Value = true
            };
            lastColumnTrigger.Setters.Add(new Setter(DataGridCell.IsTabStopProperty, false));
            lastColumnTrigger.Setters.Add(new Setter(DataGridCell.FocusableProperty, false));
            lastColumnTrigger.Setters.Add(new Setter(DataGridCell.BackgroundProperty, Brushes.LightGray));

            lastColumnCellStyle.Triggers.Add(lastColumnTrigger);

            for (int colIndex = 1; colIndex <= colCount; colIndex++)
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
                    CanUserSort = false,
                    Foreground = Brushes.Black
                };

                if (colIndex == 1)
                {
                    nameColumn.CellStyle = firstColumnCellStyle; //First Name Column
                }

                if (colIndex == colCount)
                {
                    nameColumn.CellStyle = lastColumnCellStyle; //Last Name Column
                }

                dgMainTable.Columns.Add(nameColumn);

                var valueColumn = new DataGridTextColumn()
                {
                    Header = (((colIndex-1) + _model.StartAddress/_model.RowCounts) * _model.RowCounts).ToString("D4"),
                    Binding = new Binding($"Value{colIndex}.Content")
                    {
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    },
                    Width = _model.ValueColumnWidth,
                    CanUserSort = false,
                    Foreground = Brushes.Black
                };

                if (colIndex == 1)
                {
                    valueColumn.CellStyle = firstColumnCellStyle; //First Value Column
                }

                if (colIndex == colCount)
                {
                    valueColumn.CellStyle = lastColumnCellStyle; //Last Value Column
                }

                dgMainTable.Columns.Add(valueColumn);
            }
        }

        private void dgMainTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(dgMainTable);
            var hit = VisualTreeHelper.HitTest(dgMainTable, point);

            if (hit == null)
            {
                return;
            }

            DependencyObject obj = hit.VisualHit;

            // Walk up the visual tree to find the DataGridCell
            while (obj != null && !(obj is DataGridCell))
            {
                obj = VisualTreeHelper.GetParent(obj);
            }

            if (obj is DataGridCell)
            {
                DataGridCell cell = (DataGridCell)obj;

                var row = DataGridRow.GetRowContainingElement(cell);
                var rowIndex = row.GetIndex();

                var column = cell.Column;
                var columnIndex = dgMainTable.Columns.IndexOf(column);

                //Excluded index column
                if (_model.VerifyEnabledCellByIndex(rowIndex, columnIndex))
                {
                   _model.MainTableMouseDoubleClickHandler(rowIndex, columnIndex);
                }
            }
        }
    }
}
