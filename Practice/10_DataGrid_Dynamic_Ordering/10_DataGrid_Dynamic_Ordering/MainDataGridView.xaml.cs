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
    /// Interaction logic for MainDataGridView.xaml
    /// </summary>
    public partial class MainDataGridView : UserControl
    {
        public MainDataGridView(MainDataGridViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
        }
    }
}
