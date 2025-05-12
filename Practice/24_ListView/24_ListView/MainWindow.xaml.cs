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
using System.Collections.Specialized;

namespace _24_ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly object _collectionLock = new object();

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
            }
        }

        private List<string> _tempPackets = new List<string>();
        public List<string> TempPackets
        { 
            get
            {
                return _tempPackets;
            }
            set
            {
                _tempPackets = value;
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
            ClearUI();
        }

        private void ClearUI()
        {
            Packets.Clear();
            ResumeUIUpdate();
        }

        private void SuppressUIUpdate()
        {
            TempPackets = Packets.ToList();
            lbPackets.ItemsSource = TempPackets;
        }

        private void ResumeUIUpdate()
        {
            lbPackets.ItemsSource = Packets;
            MoveFocusToTheLastItem();
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

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            SuppressUIUpdate();
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            ResumeUIUpdate();
        }
    }

    public class SuppressibleObservableCollection<T> : ObservableCollection<T>
    {
        private bool _suppressNotification = false;

        public void SuppressNotification()
        {
            _suppressNotification = true;
        }

        public void ResumeNotification()
        {
            _suppressNotification = false;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressNotification)
                base.OnCollectionChanged(e);
        }
    }
}
