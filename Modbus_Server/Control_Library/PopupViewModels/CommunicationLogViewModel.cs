using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Control_Library.Core;

namespace Control_Library.PopupViewModels
{
    public class CommunicationLogViewModel
    {
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
            //disassemble packet from master
            byte fc = e.Message.FunctionCode;
            byte[] data = e.Message.MessageFrame;
            byte[] byteStartAddress = new byte[] { data[3], data[2] };
            byte[] byteNum = new byte[] { data[5], data[4] };
            Int16 StartAddress = BitConverter.ToInt16(byteStartAddress, 0);
            Int16 NumOfPoint = BitConverter.ToInt16(byteNum, 0);
            Console.WriteLine(fc.ToString() + "," + StartAddress.ToString() + "," +
            NumOfPoint.ToString());

            PacketLogs.Add(fc.ToString());
        }

    }
}
