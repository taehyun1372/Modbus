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
using AvalonDock.Controls;
using AvalonDock.Layout;
using System.ComponentModel;

namespace _15_Dock_Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            DocumentTitle = "Document";
            for (int i = 0; i < 5; i++)
            {
                ContentControl contentControl = new ContentControl();
                MainWindowView view = new MainWindowView();
                contentControl.Content = view;
                LayoutDocument document = new LayoutDocument()
                {
                    Content = contentControl
                };
                Binding binding = new Binding("DocumentTitle") { Mode = BindingMode.TwoWay };
                BindingOperations.SetBinding(document, LayoutDocument.TitleProperty, binding);
                mainDocumentPane.Children.Add(document);
            }
        }

        private string _documentTitle;
        public string DocumentTitle
        {
            get
            {
                return _documentTitle;
            }
            set
            {
                _documentTitle = value;
                OnPropertyChanged(nameof(DocumentTitle));
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
    }
}
