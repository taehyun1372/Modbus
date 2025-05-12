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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace _24_ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<String> _packets = new ObservableCollection<string>();

        public ObservableCollection<string> Packets
        {
            get
            {
                return _packets;
            }
            set
            {
                _packets = value;
                OnPropertyChanged(nameof(Packets));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CreateNewPackets();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateNewPackets();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Packets.Clear();
        }

        public void CreateNewPackets()
        {
            var scrollMoveRequired = false;
            double extentHeight = 0;
            double viewportHeight = 0;
            double verticalOffset = 0;

            if (VisualTreeHelper.GetChildrenCount(lbPackets) > 0)
            {
                Border border = (Border)VisualTreeHelper.GetChild(lbPackets, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                extentHeight = scrollViewer.ExtentHeight;
                viewportHeight = scrollViewer.ViewportHeight;
                verticalOffset = scrollViewer.VerticalOffset;
            }


            //If a user was watching the last screen of scroll view, move scroll to the new end screen.
            scrollMoveRequired = (verticalOffset + viewportHeight == extentHeight) ? true: false;

            for (int i = 0; i < 10; i++)
            {
                Packets.Add($"packet received : {Packets.Count}");
            }

            if(scrollMoveRequired) MoveFocusToTheLastItem();
        }

        private void MoveFocusToTheLastItem()
        {
            

            if (VisualTreeHelper.GetChildrenCount(lbPackets) > 0)
            {
                Border border = (Border)VisualTreeHelper.GetChild(lbPackets, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);

                scrollViewer.ScrollToBottom();
            }
        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            if (VisualTreeHelper.GetChildrenCount(lbPackets) > 0)
            {
                Border border = (Border)VisualTreeHelper.GetChild(lbPackets, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);

                var message = $"ExtentHeight : {scrollViewer.ExtentHeight}" + "\n" + $"ViewportHeight : {scrollViewer.ViewportHeight}" + "\n" + $"VerticalOffset : {scrollViewer.VerticalOffset}";

                MessageBox.Show(message);
            }

        }
    }
}
