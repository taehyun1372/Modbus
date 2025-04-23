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

            _model.ListCheckBox.Add(cbBit0);
            _model.ListCheckBox.Add(cbBit1);
            _model.ListCheckBox.Add(cbBit2);
            _model.ListCheckBox.Add(cbBit3);
            _model.ListCheckBox.Add(cbBit4);
            _model.ListCheckBox.Add(cbBit5);
            _model.ListCheckBox.Add(cbBit6);
            _model.ListCheckBox.Add(cbBit7);
            _model.ListCheckBox.Add(cbBit8);
            _model.ListCheckBox.Add(cbBit9);
            _model.ListCheckBox.Add(cbBit10);
            _model.ListCheckBox.Add(cbBit11);
            _model.ListCheckBox.Add(cbBit12);
            _model.ListCheckBox.Add(cbBit13);
            _model.ListCheckBox.Add(cbBit14);
            _model.ListCheckBox.Add(cbBit15);
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

        private void CheckBox_Clicked(object sender, RoutedEventArgs e)
        {
            _model.CheckBoxClickedHanlder(sender, e);
        }

        private void tbValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            _model.ValueTextChangedHandler(sender, e);
        }
    }
}
