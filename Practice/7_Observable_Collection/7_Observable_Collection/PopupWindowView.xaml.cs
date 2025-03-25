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
using System.Windows.Shapes;
using System.Windows;

namespace _7_Observable_Collection
{
    /// <summary>
    /// Interaction logic for PopupWindowView.xaml
    /// </summary>
    public partial class PopupWindowView : Window
    {
        private ViewModel _model;
        public PopupWindowView(ViewModel model)
        {
            InitializeComponent();
            _model = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _model.DataItems[0].Name = "Test 99"; //Changing sub instance property doesn't invoke UI Update. 
            _model.DataItems[1].Name = "Test 99"; //Need to implement INotifyPropertyChanged in sub instance's setter. 
            _model.DataItems[2].Name = "Test 99";
            _model.DataItems[3].Name = "Test 99";
            _model.DataItems[4].Name = "Test 99";
            MessageBox.Show("Mouse down");
        }
    }
}
