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
using System.Collections.ObjectModel;
using _9_DataGrid_Ordering.ViewModels;

namespace _9_DataGrid_Ordering.Views
{
    /// <summary>
    /// Interaction logic for MainGridView.xaml
    /// </summary>
    public partial class MainGridView : UserControl
    {
        private MainGridViewModel _model;
        public MainGridView(MainGridViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
            _model = model;
        }
    }
}
