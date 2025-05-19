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
    /// Interaction logic for SetupView.xaml
    /// </summary>
    public partial class TableSetupView : Window
    {
        private PopupViewModels.TableSetupViewModel _model;
        public TableSetupView(TableSetupViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }

        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            _model.OnOkayClicked(sender, e);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
            else if (e.Key == Key.Enter)
            {
                var quantityBinding = tbCustomQuantity.GetBindingExpression(TextBox.TextProperty);
                quantityBinding?.UpdateSource();

                var rowCountsBinding = tbCustomRowCounts.GetBindingExpression(TextBox.TextProperty);
                rowCountsBinding?.UpdateSource();

                _model.OnOkayClicked(sender, e);
                Close();
            }

        }
    }
}
