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
    public partial class SetupView : Window
    {
        private PopupViewModels.SetupViewModel _model;
        public SetupView(SetupViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }

        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            _model.OkayClickedHandler(sender, e);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
