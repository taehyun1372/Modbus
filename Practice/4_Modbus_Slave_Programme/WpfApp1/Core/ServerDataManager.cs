using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels;
using Modbus.Device;
using System.Net;
using System.Net.Sockets;

namespace WpfApp1.Core
{
    public class ServerDataManager
    {
        private ModbusTcpSlave _slave;
        public ServerDataManager()
        {
            TcpListener listener = new TcpListener(IPAddress.Parse("192.168.1.101"), 1200);
            listener.Start();
            _slave = ModbusTcpSlave.CreateTcp(1, listener);
            _slave.DataStore = Modbus.Data.DataStoreFactory.CreateDefaultDataStore();

            _slave.Listen();
        }

        public void DataChangeHandler(object sender, DataChangedEventArgs e)
        {
            _slave.DataStore.HoldingRegisters[e.Address] = e.Value;
        }
    }
}
