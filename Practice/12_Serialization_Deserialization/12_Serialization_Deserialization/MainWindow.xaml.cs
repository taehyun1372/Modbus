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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace _12_Serialization_Deserialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SetupViewModel _model;
        public MainWindow()
        {
            InitializeComponent();
            SetupViewModel model = new SetupViewModel();
            SetupView view = new SetupView(model);
            _model = model;
            fmMain.Content = view;
        }
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SetupViewModel));
            using (StreamWriter writer = new StreamWriter(@"C:\Users\a00533064\OneDrive - ONEVIRTUALOFFICE\Desktop\SerializationTest\Test123.xml"))
            {
                serializer.Serialize(writer, _model);
            }
            MessageBox.Show("Object Serialized Successfully");
        }

        private void btnImport_Click(object sender, RoutedEventArgs erg)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SetupViewModel));
            SetupViewModel tempModel = new SetupViewModel();
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\a00533064\OneDrive - ONEVIRTUALOFFICE\Desktop\SerializationTest\Test123.xml"))
                {
                    tempModel = (SetupViewModel)serializer.Deserialize(reader);
                }

                MessageBox.Show("Object Deserialized Successfully");

                _model.FunctionType = tempModel.FunctionType;
                _model.RowSetting = tempModel.RowSetting;
                _model.QuantitySetting = tempModel.QuantitySetting;
                _model.PLCAddress = tempModel.PLCAddress;
                _model.AddressVisible = tempModel.AddressVisible;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Object Deserialized Failed \n {e.Message}");
            }
        }
    }
}
