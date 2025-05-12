using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Control_Library.Core;
using System.Windows.Threading;
using System.Windows;

namespace Control_Library.PopupViewModels
{
    public class CommunicationLogViewModel
    {
        public event Action<object, NewMessageGeneratedEventArgs> NewMessageGenerated;
        private ObservableCollection<string> _packetLogs = new ObservableCollection<string>();
        public ObservableCollection<string> PacketLogs
        {
            get
            {
                return _packetLogs;
            }
            set
            {
                _packetLogs = value;
            }
        }

        private List<string> _tempPacketLogs = new List<string>();
        public List<string>  TempPacketLogs
        {
            get
            {
                return _tempPacketLogs;
            }
            set
            {
                _tempPacketLogs = value;
            }
        }

        private SlaveHelper _slave;
        public SlaveHelper Slave
        {
            get { return _slave; }
            set { _slave = value; }
        }

        public CommunicationLogViewModel(SlaveHelper slaveHelper)
        {
            Slave = slaveHelper;
            Slave.Slave.ModbusSlaveRequestReceived += OnModbusSlaveRequestReceived;
        }

        private void OnModbusSlaveRequestReceived(object sender,Modbus.Device.ModbusSlaveRequestEventArgs e)
        {
            Dispatcher dispatcher = Application.Current.Dispatcher;
            dispatcher.BeginInvoke(new Action<object, Modbus.Device.ModbusSlaveRequestEventArgs>(GenerateNewMessage), sender, e);
        }

        private void GenerateNewMessage(object sender, Modbus.Device.ModbusSlaveRequestEventArgs e)
        {
            var timeStamp = DateTime.Now.ToString("HH:mm:ss:fff");
            var messageFrame = BitConverter.ToString(e.Message.MessageFrame);

            var message = string.Join(" - ", timeStamp, messageFrame);

            //PacketLogs.Add(e.Message.ToString());

            NewMessageGenerated?.Invoke(this, new NewMessageGeneratedEventArgs(message));
        }
    }

    public class NewMessageGeneratedEventArgs
    {
        public string Message { get; set; }

        public NewMessageGeneratedEventArgs(string message)
        {
            Message = message;
        }
    }
}
