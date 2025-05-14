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

namespace _27_Dispose
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Popup _popup;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPopup_Click(object sender, RoutedEventArgs e)
        {
            if(_popup == null)
            {
                _popup = new Popup();
                _popup.Closed += (s, arg) => {
                    _popup.Dispose();
                    _popup = null;
                };
                _popup.Show();
            }
            else
            {
                _popup.Activate();
            }
        }
    }
}
