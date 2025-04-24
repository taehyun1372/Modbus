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

namespace _15_Dock_Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                ContentControl contentControl = new ContentControl();
                MainWindowView view = new MainWindowView();
                contentControl.Content = view;
                LayoutDocument document = new LayoutDocument()
                {
                    Title = $"Document {i}",
                    Content = contentControl
                };
                mainDocumentPane.Children.Add(document);
            }
        }
    }
}
