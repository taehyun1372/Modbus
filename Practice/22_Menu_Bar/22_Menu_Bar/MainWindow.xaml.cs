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
using System.ComponentModel;

namespace _22_Menu_Bar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            MainFontSize = 30;
            MainFontWeight = FontWeights.Light;
            IsItalic = FontStyles.Normal;
        }

        private int _mainFontSize;

        public int MainFontSize
        {
            get { return _mainFontSize; }
            set
            {
                _mainFontSize = value;
                OnPropertyChanged(nameof(MainFontSize));
            }
        }

        private FontWeight _mainFontWeight;

        public FontWeight MainFontWeight
        {
            get { return _mainFontWeight; }
            set
            {
                _mainFontWeight = value;
                OnPropertyChanged(nameof(MainFontWeight));
            }
        }

        private FontStyle _isItalic;

        public FontStyle IsItalic
        {
            get { return _isItalic; }
            set
            {
                _isItalic = value;
                OnPropertyChanged(nameof(IsItalic));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Bold_Chcked(object sender, RoutedEventArgs e)
        {
            MainFontWeight = FontWeights.Bold;
        }

        private void Bold_Unchecked(object sender, RoutedEventArgs e)
        {
            MainFontWeight = FontWeights.Light;
        }

        private void Italic_Checked(object sender, RoutedEventArgs e)
        {
            IsItalic = FontStyles.Italic;
        }

        private void Italic_Unchecked(object sender, RoutedEventArgs e)
        {
            IsItalic = FontStyles.Normal;
        }

        private void IncreaseFont_Click(object sender, RoutedEventArgs e)
        {
            MainFontSize += 1;
        }

        private void DecreaseFont_Click(object sender, RoutedEventArgs e)
        {
            MainFontSize -= 1;
        }
    }
}
