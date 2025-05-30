﻿using System;
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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Control_Library.Core
{

    public class SlaveHelper : INotifyPropertyChanged
    {
        public const string DEFAULT_IP_ADDRESS = "127.0.0.1";
        public const int DEFAULT_PORT = 502;
        public const byte DEFAULT_SLAVE_ID = 1;
        public event Action<object, EventArgs> Connected;
        public event Action<object, EventArgs> Disconnected;
        public event Action<object, RegisterChangeEventArg> RegisterChanged;
        public event Action<object, StatusChangeEventArg> StatusChanged;
        public event PropertyChangedEventHandler PropertyChanged;

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
                OnPropertyChanged(nameof(IsConnected));
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
                OnPropertyChanged(nameof(Address));
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
                OnPropertyChanged(nameof(Port));
            }
        }

        public int ConnectionCounts
        {
            get
            {
                if (Slave == null)
                {
                    return 0;
                }
                else
                {
                    return Slave.Masters.Count;
                }
            }
        }

        private int _RxCounts;
        public int RxCounts
        {
            get
            {
                return _RxCounts;
            }
            set
            {
                _RxCounts = value;
                OnPropertyChanged(nameof(RxCounts));
            }
        }

        private int _TxCounts;
        public int TxCounts
        {
            get
            {
                return _TxCounts;
            }
            set
            {
                _TxCounts = value;
                OnPropertyChanged(nameof(TxCounts));
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

        public bool[] GetCoilStatus(int start, int quantity)
        {
            return _slave.DataStore.CoilDiscretes.Skip(start).Take(quantity).ToArray();
        }

        public void SetCoilStatus(int index, bool value)
        {
            if (_slave.DataStore.CoilDiscretes.Count() > index)
            {
                _slave.DataStore.CoilDiscretes[index] = value;
                StatusChanged?.Invoke(this, new StatusChangeEventArg(index, value, EnumFunctionCodes.CoilStatus));
            }
        }

        public bool[] GetInputStatus(int start, int quantity)
        {
            return _slave.DataStore.InputDiscretes.Skip(start).Take(quantity).ToArray();
        }

        public void SetInputStatus(int index, bool value)
        {
            if (_slave.DataStore.InputDiscretes.Count() > index)
            {
                _slave.DataStore.InputDiscretes[index] = value;
                StatusChanged?.Invoke(this, new StatusChangeEventArg(index, value, EnumFunctionCodes.InputStatus));
            }
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
                RegisterChanged?.Invoke(this, new RegisterChangeEventArg(index, value, EnumFunctionCodes.HolidngRegister));
            }
        }

        public ushort[] GetInputRegisters(int start, int quantity)
        {
            return _slave.DataStore.InputRegisters.Skip(start).Take(quantity).ToArray();
        }

        public void SetInputRegister(int index, ushort value)
        {
            if (_slave.DataStore.InputRegisters.Count() > index)
            {
                _slave.DataStore.InputRegisters[index] = value;
                RegisterChanged?.Invoke(this, new RegisterChangeEventArg(index, value, EnumFunctionCodes.InputRegister));
            }
        }

        public void OnDataStoreWrittenTo(object sender, Modbus.Data.DataStoreEventArgs e)
        {
            switch (e.ModbusDataType)
            {
                case (Modbus.Data.ModbusDataType.Coil):
                    for (int i = 0; i < e.Data.A.Count; i++)
                    {
                        StatusChanged?.Invoke(this, new StatusChangeEventArg(e.StartAddress + i + 1, e.Data.A[i], EnumFunctionCodes.CoilStatus));
                    }
                    break;
                case (Modbus.Data.ModbusDataType.Input):
                    break;
                case (Modbus.Data.ModbusDataType.HoldingRegister):
                    for (int i = 0; i < e.Data.B.Count; i++)
                    {
                        RegisterChanged?.Invoke(this, new RegisterChangeEventArg(e.StartAddress + i + 1, e.Data.B[i], EnumFunctionCodes.HolidngRegister));
                    }
                    break;
                case (Modbus.Data.ModbusDataType.InputRegister):
                    break;
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
                Listener.Start();

                Slave = ModbusTcpSlave.CreateTcp(unitId, Listener);
                Slave.DataStore = Modbus.Data.DataStoreFactory.CreateDefaultDataStore();
                Slave.DataStore.DataStoreWrittenTo += OnDataStoreWrittenTo;

                Slave.Listen();
                Slave.ModbusSlaveRequestReceived += (s, e) =>
                {
                    RxCounts += 1;
                };


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

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RegisterChangeEventArg
    {
        public int Index { get; set; }
        public ushort Value { get; set; }
        public EnumFunctionCodes FunctionCode { get; set; }


        public RegisterChangeEventArg(int index, ushort value, EnumFunctionCodes functionCode)
        {
            Index = index;
            Value = value;
            FunctionCode = functionCode;
        }
    }

    public class StatusChangeEventArg
    {
        public int Index { get; set; }
        public bool Value { get; set; }
        public EnumFunctionCodes FunctionCode { get; set; }


        public StatusChangeEventArg(int index, bool value, EnumFunctionCodes functionCode)
        {
            Index = index;
            Value = value;
            FunctionCode = functionCode;
        }
    }
}
