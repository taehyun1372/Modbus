using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using System.Net.Sockets;
using System.Net;

namespace Control_Library.Core
{

    public class SlaveHelper
    {
        public const string DEFAULT_IP_ADDRESS = "127.0.0.1";
        public const int DEFAULT_PORT = 502;
        public const byte DEFAULT_SLAVE_ID = 1;

        private TcpListener _listener;
        private ModbusTcpSlave _slave;
        public ModbusTcpSlave Slave
        {
            get { return _slave; }
            set { _slave = value; }
        }

        public Modbus.Data.DataStore DataStore
        {
            get { return _slave.DataStore; }
        }

        public Modbus.Data.ModbusDataCollection<ushort> HoldingRegisters
        {
            get { return _slave.DataStore.HoldingRegisters; }
        }

        public Modbus.Data.ModbusDataCollection<ushort> InputRegisters
        {
            get { return _slave.DataStore.InputRegisters; }
        }

        public Modbus.Data.ModbusDataCollection<bool> Coils
        {
            get { return _slave.DataStore.CoilDiscretes; }
        }

        public Modbus.Data.ModbusDataCollection<bool> InputDiscretes
        {
            get { return _slave.DataStore.InputDiscretes; }
        }

        public byte SlaveId
        {
            get
            {
                return _slave.UnitId;
            }
            set
            {
                _slave.UnitId = value;
            }
        }

        public SlaveHelper()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(DEFAULT_IP_ADDRESS), DEFAULT_PORT);
            _listener = new TcpListener(ep);
            _listener.Start();

            Slave = ModbusTcpSlave.CreateTcp(DEFAULT_SLAVE_ID, _listener);
            Slave.DataStore = Modbus.Data.DataStoreFactory.CreateDefaultDataStore();

            Slave.Listen();
        }

        public ushort[] GetHoldingRegisters(int start, int quantity)
        {
            return _slave.DataStore.HoldingRegisters.Skip(start).Take(quantity).ToArray();
        }


    }
}
