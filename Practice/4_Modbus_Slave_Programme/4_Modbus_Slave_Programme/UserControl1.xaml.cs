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
using _4_Modbus_Slave_Programme.Views;
using _4_Modbus_Slave_Programme.ViewModels;

namespace _4_Modbus_Slave_Programme
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            DataColumnViewModel model = new DataColumnViewModel();
            DataColumnView view = new DataColumnView(model);
            fmMain.Content = view;
        }
    }
}
