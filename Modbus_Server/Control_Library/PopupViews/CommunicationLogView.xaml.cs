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
using System.Windows.Shapes;
using Control_Library.PopupViewModels;

namespace Control_Library.PopupViews
{
    /// <summary>
    /// Interaction logic for CommunicationLogView.xaml
    /// </summary>
    public partial class CommunicationLogView : Window
    {
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
        }

        private void ScrollDownToTheBottom()
        {
            if (VisualTreeHelper.GetChildrenCount(lbCommunicationLog) > 0)
            {
                Border border = (Border)VisualTreeHelper.GetChild(lbCommunicationLog, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);

                scrollViewer.ScrollToBottom();
            }
        }
    }
}
