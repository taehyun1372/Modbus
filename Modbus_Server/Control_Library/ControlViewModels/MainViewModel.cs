using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Control_Library.PopupViewModels;
using Control_Library.PopupViews;
using Control_Library.ControlViewModels;
using Control_Library.ControlViews;
using Control_Library.Core;
using AvalonDock.Layout;
using System.Windows.Controls;

namespace Control_Library.ControlViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<object, NewTableCreatedEventArg> NewTableCreated;
        public event Action<object, TableDeletedEventArg> TableDeleted;

        private List<LayoutAnchorable> _currentAnchorables = new List<LayoutAnchorable>();

        public List<LayoutAnchorable> CurrentAnchorables
        {
            get
            {
                return _currentAnchorables;
            }
            set
            {
                _currentAnchorables = value;
            }
        }

        private List<DataTableViewModel> _allDataTableViewModels = new List<DataTableViewModel>();

        public List<DataTableViewModel> AllDataTableViewModels
        {
            get
            {
                return _allDataTableViewModels;
            }
            set
            {
                _allDataTableViewModels = value;
            }
        }

        private DataTableViewModel _currentDataTableViewModel;

        public DataTableViewModel CurrentDataTableViewModel
        {
            get
            {
                return _currentDataTableViewModel;
            }
            set
            {
                _currentDataTableViewModel = value;
            }
        }

        private SlaveHelper _slave;

        public SlaveHelper Slave
        {
            get
            {
                return _slave;
            }
            set
            {
                _slave = value;
            }
        }

        public MainViewModel()
        {
            Slave = new SlaveHelper();
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public void CreateNewTable()
        {
            var dataTableViewModel = new DataTableViewModel(Slave);
            var dataTableView = new DataTableView(dataTableViewModel);

            ContentControl contenControl = new ContentControl();
            contenControl.Content = dataTableView;

            LayoutAnchorable anchorable = new LayoutAnchorable()
            {
                Title = "Default Table",
                Content = contenControl
            };

            contenControl.Tag = anchorable;

            _allDataTableViewModels.Add(dataTableViewModel);

            NewTableCreated?.Invoke(this, new NewTableCreatedEventArg(anchorable));
        }
        public void DeleteTable()
        {
            if (_currentAnchorables.Count == 0)
            {
                return;
            }

            LayoutAnchorable currentAnchorable = _currentAnchorables.Last();
            LayoutAnchorable previousAnchorable = null;

            //Deleting from the visual tree
            var parent = currentAnchorable.Parent;
            parent?.RemoveChild(currentAnchorable);

            //Deleting anchorable from the current anchorables list
            _currentAnchorables.RemoveAll(item => item == currentAnchorable);

            //Getting the previous anchorable
            if (_currentAnchorables.Count > 0)
            {
                previousAnchorable = _currentAnchorables.Last();
            }

            //Deleting the corresponding table view model from the table view model list
            var content = currentAnchorable.Content;
            if (content is ContentControl contentControl)
            {
                if (contentControl.Content is DataTableView dataTableView)
                {
                    DataTableViewModel dataTableViewModel = dataTableView.Model;
                    _allDataTableViewModels.Remove(dataTableViewModel);
                }
            }

            TableDeleted?.Invoke(this, new TableDeletedEventArg(currentAnchorable, previousAnchorable));
        }

        public void OnDockingManagerActiveContentChanged(ContentControl contentControl)
        {
            if (contentControl.Content is DataTableView dataTableView)
            {
                _currentDataTableViewModel = dataTableView.Model;

                //Border Color Change
                foreach (DataTableViewModel model in _allDataTableViewModels)
                {
                    model.BorderColor = DataTableViewModel.DEFUALT_BORDER_COLOR;
                }
                _currentDataTableViewModel.BorderColor = DataTableViewModel.ACTIVE_BORDER_COLOR;

                //Storing Current Anchorable 
                if (contentControl.Tag is LayoutAnchorable anchorable)
                {
                    _currentAnchorables.Add(anchorable);
                }
            }
        }
    }

    public class NewTableCreatedEventArg
    { 
        public LayoutAnchorable Anchorable { get; set; }

        public NewTableCreatedEventArg(LayoutAnchorable anchorable)
        {
            Anchorable = anchorable;
        }
    }

    public class TableDeletedEventArg
    {
        public LayoutAnchorable CurrentAnchorable { get; set; }

        public LayoutAnchorable PreviousAnchorable { get; set; }

        public TableDeletedEventArg(LayoutAnchorable currentAnchorable, LayoutAnchorable previousAnchorable)
        {
            CurrentAnchorable = currentAnchorable;
            PreviousAnchorable = previousAnchorable;
        }
    }
}
