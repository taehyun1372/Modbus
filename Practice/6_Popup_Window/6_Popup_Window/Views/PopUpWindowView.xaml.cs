﻿using System;
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
using _6_Popup_Window.ViewModels;

namespace _6_Popup_Window.Views
{
    /// <summary>
    /// Interaction logic for PopUpWindowView.xaml
    /// </summary>
    public partial class PopUpWindowView : Window
    {
        public PopUpWindowView(PopUpWindowViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
