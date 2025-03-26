using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;

namespace _8_ICommand
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private MainViewModel _model;

        public MainView(MainViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _model.CheckBoxEventHandler(sender, e);
        }

        
    }
}
