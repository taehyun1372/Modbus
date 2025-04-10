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

namespace _11_Radio_Button_Behavior
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSetupPopup_Click(object sender, RoutedEventArgs e)
        {
            SetupPopupViewModel model = new SetupPopupViewModel();
            SetupPopupView view = new SetupPopupView(model);
            model.SettingFinished += UpdateRowText;
            view.ShowDialog();
        }

        private void UpdateRowText(object sender, SettingFinishedEventArgs e)
        {
            tbRow.Text = e.Row.ToString();
        }
    }
}
