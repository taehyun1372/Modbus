using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Windows.Shapes;
using Control_Library.PopupViewModels;

namespace Control_Library.PopupViews
{
    /// <summary>
    /// Interaction logic for CommunicationLogView.xaml
    /// </summary>
    public partial class CommunicationLogView : Window
    {
        private ScrollViewer _scrollViewer;

        private CommunicationLogViewModel _model;
        public CommunicationLogViewModel Model
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
        public CommunicationLogView(CommunicationLogViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            Model = model;
            Model.NewMessageGenerated += OnModelNewMessageGenerated;
            Model.IsDateTimeChanged += OnModelIsDateTimeChanged;
            Model.IsByteTextMessageChanged += OnModelIsByteTextMessageChanged;
            Model.IsRunning = true;

            lvCommunicationLog.Loaded += (sender, e) =>
            {
                _scrollViewer = FindVisualChild<ScrollViewer>(lvCommunicationLog);
                UpdateGridViewColumns();
            };
        }

        public void OnModelIsDateTimeChanged(object sender, EventArgs e)
        {
            UpdateGridViewColumns();
        }

        public void OnModelIsByteTextMessageChanged(object sender, EventArgs e)
        {
            UpdateGridViewColumns();
        }

        public void UpdateGridViewColumns()
        {
            myGridView.Columns.Clear();

            var indexColumn = new GridViewColumn()
            {
                Header = "",
                Width = 32,
                DisplayMemberBinding = new Binding("Index")
            };
            myGridView.Columns.Add(indexColumn);

            if (Model.IsDate)
            {
                var dateColumn = new GridViewColumn()
                {
                    Header = "Date",
                    Width = 80,
                    DisplayMemberBinding = new Binding("DateStamp")
                };
                myGridView.Columns.Add(dateColumn);
            }
           
            if (Model.IsTime)
            {
                var timeColumn = new GridViewColumn()
                {
                    Header = "Time",
                    Width = 90,
                    DisplayMemberBinding = new Binding("TimeStamp")
                };
                myGridView.Columns.Add(timeColumn);
            }

            if (Model.IsByteMessage)
            {
                var messageColumn = new GridViewColumn()
                {
                    Header = "Message",
                    Width = 300,
                    DisplayMemberBinding = new Binding("ByteMessage")
                };
                myGridView.Columns.Add(messageColumn);
            }

            if (Model.IsTextMessage)
            {
                var messageColumn = new GridViewColumn()
                {
                    Header = "Message",
                    Width = 300,
                    DisplayMemberBinding = new Binding("TextMessage")
                };
                myGridView.Columns.Add(messageColumn);
            }
        }

        private void OnModelNewMessageGenerated(object sender, EventArgs e)
        {
            var scrollMoveRequired = false;

            double extentHeight = 0;
            double viewportHeight = 0;
            double verticalOffset = 0;

            if (_scrollViewer != null)
            {
                extentHeight = _scrollViewer.ExtentHeight;
                viewportHeight = _scrollViewer.ViewportHeight;
                verticalOffset = _scrollViewer.VerticalOffset;
            }

            //If a user was watching the last screen of scroll view, move scroll to the new end screen.
            scrollMoveRequired = (verticalOffset + viewportHeight == extentHeight) ? true : false;

            if (scrollMoveRequired) ScrollDownToTheBottom();
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            Model.IsRunning = !Model.IsRunning;
            if (Model.IsRunning)
            {
                SetOriginalPacketLogs();
            }
            else
            {
                SetFrozenPacketLogs();
            }

        }

        private void SetOriginalPacketLogs()
        {
            Binding binding = new Binding("OriginalPacketLogs");
            lvCommunicationLog.SetBinding(ListView.ItemsSourceProperty, binding);
            ScrollDownToTheBottom();
        }

        private void SetFrozenPacketLogs()
        {
            Model.CopyPacketLogs();
            Binding binding = new Binding("FrozenPacketLogs");
            lvCommunicationLog.SetBinding(ListView.ItemsSourceProperty, binding);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Model.OriginalPacketLogs.Clear();
            Model.FrozenPacketLogs.Clear();
        }

        private void ScrollDownToTheBottom()
        {
            if (_scrollViewer != null)
            {
                _scrollViewer.ScrollToBottom();
            }
                
        }
        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T t)
                    return t;

                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
            return null;
        }
    }
}
