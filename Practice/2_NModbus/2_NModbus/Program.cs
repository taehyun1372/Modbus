using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using Modbus.Device;


namespace _2_NModbus
{
    class Program
    {

        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 503);
            tcpListener.Start();
            Console.WriteLine("Modbus TCP Server started on port {0}...",tcpListener.LocalEndpoint);

            ModbusTcpSlave slave = ModbusTcpSlave.CreateTcp(1, tcpListener);

            slave.DataStore = Modbus.Data.DataStoreFactory.CreateDefaultDataStore(); // Create a data store

            slave.Listen();  // Start listening for requests
            slave.DataStore.DataStoreWrittenTo += OnDataStoreWrittenTo;
            slave.DataStore.DataStoreReadFrom += OnDataStoreReadFrom;

            //Initial value setting
            slave.DataStore.HoldingRegisters[1] = 1;
            slave.DataStore.HoldingRegisters[2] = 2;
            slave.DataStore.HoldingRegisters[3] = 3;
            slave.DataStore.HoldingRegisters[4] = 4;
            slave.DataStore.HoldingRegisters[5] = 5;
            slave.DataStore.HoldingRegisters[6] = 6;
            slave.DataStore.HoldingRegisters[7] = 7;
            slave.DataStore.HoldingRegisters[8] = 8;
            slave.DataStore.HoldingRegisters[9] = 9;
            slave.DataStore.HoldingRegisters[10] = 10;

            Console.ReadLine();
        }

        static void OnDataStoreWrittenTo(object sender, Modbus.Data.DataStoreEventArgs e)
        {
            Console.WriteLine("Write Request Received..");
            switch(e.ModbusDataType)
            {
                case Modbus.Data.ModbusDataType.HoldingRegister:
                    foreach ( var i in e.Data.B)
                    {
                        Console.WriteLine($"Value : {i}, StartAddress : {e.StartAddress}, Length : {e.Data.B.Count()}");
                    }
                    break;
                case Modbus.Data.ModbusDataType.Coil:
                    break;
                case Modbus.Data.ModbusDataType.Input:
                    break;
                case Modbus.Data.ModbusDataType.InputRegister:
                    break;
            }
        }

        static void OnDataStoreReadFrom(object sender, Modbus.Data.DataStoreEventArgs e)
        {
            Console.WriteLine("Read Request Received..");
            switch (e.ModbusDataType)
            {
                case Modbus.Data.ModbusDataType.HoldingRegister:
                    foreach (var i in e.Data.B)
                    {
                        Console.WriteLine($"Value : {i}, StartAddress : {e.StartAddress}, Length : {e.Data.B.Count()}");
                    }
                    break;
                case Modbus.Data.ModbusDataType.Coil:
                    break;
                case Modbus.Data.ModbusDataType.Input:
                    break;
                case Modbus.Data.ModbusDataType.InputRegister:
                    break;
            }
        }
    }
}
