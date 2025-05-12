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
            lbCommunicationLog.Loaded += (sender, e) =>
            {
                if (VisualTreeHelper.GetChildrenCount(lbCommunicationLog) > 0)
                {
                    Border border = (Border)VisualTreeHelper.GetChild(lbCommunicationLog, 0);
                    _scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                }
            };
        }

        private void OnModelNewMessageGenerated(object sender, NewMessageGeneratedEventArgs e)
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

            for (int i = 0; i < 10; i++)
            {
                Model.PacketLogs.Add(e.Message);
            }

            if (scrollMoveRequired) ScrollDownToTheBottom();
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            lbCommunicationLog.ItemsSource = Model.PacketLogs;
            ScrollDownToTheBottom();
        }


        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Model.TempPacketLogs = Model.PacketLogs.ToList();
            lbCommunicationLog.ItemsSource = Model.TempPacketLogs;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Model.PacketLogs.Clear();
            Model.TempPacketLogs.Clear();
        }

        private void ScrollDownToTheBottom()
        {
            if (_scrollViewer != null)
            {
                _scrollViewer.ScrollToBottom();
            }
                
        }
    }
}
