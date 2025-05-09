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
using AvalonDock.Layout;

namespace Control_Library.ControlViews
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private MainViewModel _model;
        public MainViewModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }
        public MainView(MainViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            Model = model;
            Model.NewTableCreated += OnModelNewTableCreated;
            Model.TableDeleted += OnModelTableDeleted;
        }

        private void myDockingManager_ActiveContentChanged(object sender, EventArgs e)
        {
            var activeContent = myDockingManager.ActiveContent;
            if (activeContent is ContentControl contentControl)
            {
                Model.OnDockingManagerActiveContentChanged(contentControl);
            }
        }

        private void OnModelNewTableCreated(object sender, NewTableCreatedEventArg e)
        {
            var anchorable = e.Anchorable;

            if (anchorable == null)
            {
                return;
            }

            if (myAnchorablePane.Parent == null)
            {
                //putting the mainAnchorablePane into the root layout again
                myLayoutRoot.RootPanel.Children.Add(myAnchorablePane);
            }
            myAnchorablePane.Children.Add(anchorable);

            myDockingManager.ActiveContent = anchorable.Content;
        }

        private void OnModelTableDeleted(object sender, TableDeletedEventArg e)
        {
            LayoutAnchorable currentAnchorable = e.CurrentAnchorable;
            LayoutAnchorable previousAnchorable = e.PreviousAnchorable;

            //Deleting the current anchorable from the visual tree
            if ( currentAnchorable != null)
            {
                var parent = currentAnchorable.Parent;
                parent?.RemoveChild(currentAnchorable);
            }

            //If there is a previous anchorable, We activate the previous anchorable
            if ( previousAnchorable != null)
            {
                myDockingManager.ActiveContent = previousAnchorable.Content;
            }
        }
    }
}
