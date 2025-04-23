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
    /// Interaction logic for ValueEnterView.xaml
    /// </summary>
    public partial class ValueEnterView : Window 
    {
        private ValueEnterViewModel _model;
        public ValueEnterView(ValueEnterViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }

        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            _model.OkayClickHandler();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tbValue_Loaded(object sender, RoutedEventArgs e)
        {
            tbValue.Focus();
            tbValue.SelectAll();
        }
    }
}
