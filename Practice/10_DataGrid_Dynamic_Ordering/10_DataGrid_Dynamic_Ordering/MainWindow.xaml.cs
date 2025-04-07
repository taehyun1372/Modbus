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

namespace _10_DataGrid_Dynamic_Ordering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainDataGridViewModel _model;
        public MainWindow()
        {
            InitializeComponent();

            MainDataGridViewModel model = new MainDataGridViewModel();
            _model = model;
            MainDataGridView view = new MainDataGridView(model);
            fmMain.Content = view;
        }
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            int quantity;
            if(!int.TryParse(tbQuantity.Text, out quantity))
            {
                return;
            }

            _model.Apply_Clicked_Handler(sender, e, quantity);
        }
    }
}
