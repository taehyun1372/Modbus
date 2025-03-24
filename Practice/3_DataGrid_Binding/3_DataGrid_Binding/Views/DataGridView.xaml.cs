using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _3_DataGrid_Binding.ViewModels;

namespace _3_DataGrid_Binding.Views
{
    /// <summary>
    /// Interaction logic for DataGridView.xaml
    /// </summary>
    public partial class DataGridView : UserControl
    {
        public DataGridView(DataGridViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
        }
    }
}
