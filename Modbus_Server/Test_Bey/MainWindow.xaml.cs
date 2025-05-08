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
using Control_Library.PopupViewModels;
using Control_Library.PopupViews;
using Control_Library.ControlViewModels;
using Control_Library.ControlViews;
using Control_Library.Core;
using AvalonDock.Layout;

namespace Test_Bey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SetupViewModel _setupViewModel;
        private SetupView _setupView;
        private SlaveHelper _slaveHelper;
        private List<LayoutAnchorable> _currentAnchorables = new List<LayoutAnchorable>();
        private List<DataTableViewModel> _allDataTableViewModels = new List<DataTableViewModel>();
        private DataTableViewModel _currentTableModel;

        public MainWindow()
        {
            InitializeComponent();
            _slaveHelper = new SlaveHelper();
            CreateDocument();
        }

        private void UpdateTextBlocks(object sender, SetupFinishedEventArg e)
        {
            tbRow.Text = e.Row.ToString();
            tbQuantity.Text = e.Quantity.ToString();
        }

        private void btnRowCounts_Click(object sender, RoutedEventArgs e)
        {
            int count;
            if (!int.TryParse(tbDataTableRowCounts.Text, out count))
            {
                return;
            }

            if (_currentTableModel != null)
            {
                _currentTableModel.RowCounts = count;
            }
        }

        private void btnDataTableQuantity_Click(object sender, RoutedEventArgs e)
        {
            int count;
            if (!int.TryParse(tbDataTableQuantity.Text, out count))
            {
                return;
            }

            if (_currentTableModel != null)
            {
                _currentTableModel.Quantity = count;
            }
        }

        private void btnStartAddress_Click(object sender, RoutedEventArgs e)
        {
            int count;

            if (!int.TryParse(tbStartAddress.Text, out count))
            {
                return;
            }

            if (_currentTableModel != null)
            {
                _currentTableModel.StartAddress = count;
            }
        }

        private void btnSetup_Click(object sender, RoutedEventArgs e)
        {
            _setupViewModel = new SetupViewModel();
            _setupView = new SetupView(_setupViewModel);

            _setupViewModel.SetupFinished += UpdateTextBlocks;

            _setupView.ShowDialog();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateDocument();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteDocument();
        }
        public void CreateDocument()
        {
            var dataTableViewModel = new DataTableViewModel(_slaveHelper);
            var dataTableView = new DataTableView(dataTableViewModel);

            ContentControl contenControl = new ContentControl();
            contenControl.Content = dataTableView;
            contenControl.Tag = dataTableViewModel;

            LayoutAnchorable anchorable = new LayoutAnchorable()
            {
                Title = $"Table {mainAnchorablePane.Children.Count + 1}",
                Content = contenControl
            };

            anchorable.IsActiveChanged += AnchorableIsActiveChangedHandler;
            anchorable.IsSelected = true;
            anchorable.IsActive = true;

            if (mainAnchorablePane.Parent == null)
            {
                //putting the mainAnchorablePane into the root layout again
                layoutRoot.RootPanel.Children.Add(mainAnchorablePane);
            }
            mainAnchorablePane.Children.Add(anchorable);
            _allDataTableViewModels.Add(dataTableViewModel);
        }
        public void AnchorableIsActiveChangedHandler(object sender, EventArgs e)
        {
            if (sender is LayoutAnchorable)
            {
                LayoutAnchorable anchorable = (LayoutAnchorable)sender;
                if (anchorable.IsActive)
                {
                    _currentAnchorables.Add(anchorable);
                }
            }
        }

        public DataTableViewModel GetDataTableModelFromAnchorable(LayoutAnchorable anchorable)
        {
            DataTableViewModel model = null;

            if (anchorable.Content is ContentControl)
            {
                ContentControl content = (ContentControl)anchorable.Content;
                if (content.Content is DataTableView)
                {
                    DataTableView view = (DataTableView)content.Content;
                    model = view.Model;
                }
            }
            return model;
        }

        public void DeleteDocument()
        {
            if (_currentAnchorables.Count > 0)
            {
                LayoutAnchorable currentAnchorable = _currentAnchorables.Last();

                //Deleting from the visual tree
                var parent = currentAnchorable.Parent; 
                parent?.RemoveChild(currentAnchorable);

                //Deleting also from the current anchorables list
                _currentAnchorables.RemoveAll(item => item == currentAnchorable);

                //Make sure the previous anchorable is selected before exit the method
                if (_currentAnchorables.Count > 0)
                {
                    LayoutAnchorable previousAnchorable = _currentAnchorables.Last();
                    previousAnchorable.IsActive = true;
                }

                //Make sure we delete the corresponding view model from the list
                var content = currentAnchorable.Content;
                if (content is ContentControl)
                {
                    ContentControl contentControl = (ContentControl)content;
                    if (contentControl.Tag is DataTableViewModel)
                    {
                        DataTableViewModel viewModel = (DataTableViewModel)contentControl.Tag;
                        _allDataTableViewModels.Remove(viewModel);
                    }
                }
            }
        }

        private void dockingManager_ActiveContentChanged(object sender, EventArgs e)
        {
            var active = dockingManager.ActiveContent;
            if (active is ContentControl)
            {
                ContentControl contentControl = (ContentControl)active;
                var content = contentControl.Content;
                if (content is DataTableView)
                {
                    DataTableView view = (DataTableView)content;
                    _currentTableModel = view.Model;

                    foreach(DataTableViewModel model in _allDataTableViewModels)
                    {
                        model.BorderColor = DataTableViewModel.DEFUALT_BORDER_COLOR;
                    }
                    _currentTableModel.BorderColor = Brushes.SteelBlue;
                }
            }
        }
    }
}
