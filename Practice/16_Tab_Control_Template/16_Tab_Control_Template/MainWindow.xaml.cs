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

namespace _16_Tab_Control_Template
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        public ObservableCollection<MyTabViewModel> MyTabs { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            MyTabs = new ObservableCollection<MyTabViewModel>
            {            
                new MyTabViewModel { HeaderText = "Tab 1", Content = "This is Tab 1" },
                new MyTabViewModel { HeaderText = "Tab 2", Content = "This is Tab 2" }
            };

        }
    }
}
