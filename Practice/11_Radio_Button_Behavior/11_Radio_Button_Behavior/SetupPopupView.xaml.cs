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

namespace _11_Radio_Button_Behavior
{
    /// <summary>
    /// Interaction logic for SetupPopupView.xaml
    /// </summary>
    public partial class SetupPopupView : Window
    {
        private SetupPopupViewModel _model;
        public SetupPopupView(SetupPopupViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }

        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            _model.OkayClickHandler(sender, e);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
