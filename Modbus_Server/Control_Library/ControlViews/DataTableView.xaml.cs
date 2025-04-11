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
using Control_Library.ControlViewModels;

namespace Control_Library.ControlViews
{
    /// <summary>
    /// Interaction logic for DataTableView.xaml
    /// </summary>
    public partial class DataTableView : UserControl
    {
        private DataTableViewModel _model;
        public DataTableView(DataTableViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }
    }
}
