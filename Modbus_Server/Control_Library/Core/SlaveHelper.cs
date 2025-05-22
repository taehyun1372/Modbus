using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using System.Net.Sockets;
using System.Net;
using Control_Library.PopupViewModels;
using Control_Library.PopupViews;
using System.Windows;

namespace Control_Library.Core
{

    public class SlaveHelper
    {
        public const string DEFAULT_IP_ADDRESS = "127.0.0.1";
        public const int DEFAULT_PORT = 1500;
        public const byte DEFAULT_SLAVE_ID = 1;
        public event Action<object, EventArgs> Connected;
        public event Action<object, EventArgs> Disconnected;
        public event Action<object, HoldingRegisterChangeEventArg> HoldingRegisterChanged;

        private bool _isConnected;
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
            }
        }

        private TcpListener _listener;
        public TcpListener Listener
        {
            get
            {
                return _listener;
            }
            set
            {
                _listener = value;
            }
        }

        private IPEndPoint _endPoint = new IPEndPoint(IPAddress.Parse(DEFAULT_IP_ADDRESS), DEFAULT_PORT);
        public IPEndPoint EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                _endPoint = value;
            }
        }
        private byte _unitId;
        public byte UnitId
        {
            get
            {
                return _unitId;
            }
            set
            {
                _unitId = value;
            }
        }

        private ModbusTcpSlave _slave;
        public ModbusTcpSlave Slave
        {
            get { return _slave; }
            set { _slave = value; }
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        private int _port;
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        public Modbus.Data.DataStore DataStore
        {
            get { return _slave.DataStore; }
        }

        public SlaveHelper()
        {
            Address = DEFAULT_IP_ADDRESS;
            Port = DEFAULT_PORT;
            UnitId = DEFAULT_SLAVE_ID;
        }

        public ushort[] GetHoldingRegisters(int start, int quantity)
        {
            return _slave.DataStore.HoldingRegisters.Skip(start).Take(quantity).ToArray();
        }

        public void SetHoldingRegister(int index, ushort value)
        {
            if (_slave.DataStore.HoldingRegisters.Count() > index)
            {
                _slave.DataStore.HoldingRegisters[index] = value;
                HoldingRegisterChanged?.Invoke(this, new HoldingRegisterChangeEventArg(index, value));
            }
        }
        public void Connect(string address, int port, byte unitId)
        {
            if (Slave != null)
            {
                Console.WriteLine("A Server is already opened");
                return; //Slave is already opened
            }
            try
            {
                EndPoint.Address = IPAddress.Parse(address);
                EndPoint.Port = port;
                Listener = new TcpListener(EndPoint);
                _listener.Start();

                Slave = ModbusTcpSlave.CreateTcp(unitId, Listener);
                Slave.DataStore = Modbus.Data.DataStoreFactory.CreateDefaultDataStore();

                Slave.Listen();

                IsConnected = true;
                Connected?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                var message = $"Fail to open a server with IP address {address} and Port number {port}";
                MessageBox.Show(message, "Connection Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void Connect()
        {
            this.Connect(Address, Port, UnitId);
        }


        public void Disconnect()
        {
            if (Slave == null)
            {
                Console.WriteLine("A Server has already been disposed");
                return;
            }
            try
            {
                Slave.Dispose();
                Slave = null;
                Listener = null;

                IsConnected = false;
                Disconnected?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                var message = "Failed to close the server";
                MessageBox.Show(message, "Disconnection Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    public class HoldingRegisterChangeEventArg
    {
        public int Index { get; set; }
        public ushort Value { get; set; }

        public HoldingRegisterChangeEventArg(int index, ushort value)
        {
            Index = index;
            Value = value;
        }
    }
}
