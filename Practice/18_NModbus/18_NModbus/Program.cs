using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _18_NModbus
{
    class Program
    {
        public static int port = 1500;
        public static byte slaveId = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Slave API
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            TcpListener tcpListener = new TcpListener(ep);
            tcpListener.Start();

            ModbusSlave slave = ModbusTcpSlave.CreateTcp(slaveId, tcpListener);
            

            //Data Store Creation
            slave.DataStore = Modbus.Data.DataStoreFactory.CreateDefaultDataStore();

            slave.ModbusSlaveRequestReceived += ModbusSlaveRequestReceivedHandler;
            slave.DataStore.DataStoreWrittenTo += DataStoreWriteToHanlder;

            slave.Listen();
            StringBuilder currentData = new StringBuilder();
            while (true)
            {
                currentData.Clear();
                for ( int i= 0; i < 20; i++)
                {
                    currentData.Append(slave.DataStore.HoldingRegisters[i] + " ");
                }
                Console.WriteLine($"Current Data : {currentData}");
                Thread.Sleep(10000);
            }

            Console.WriteLine("Goodbye World!");
            Console.ReadLine();
        }

        static public void ModbusSlaveRequestReceivedHandler(object sender, ModbusSlaveRequestEventArgs e)
        {
            byte fc = e.Message.FunctionCode;
            byte[] dataFrame = e.Message.MessageFrame;
            Console.WriteLine(e.Message.ToString());
            string message = DateTime.Now.ToString() + " : ";
            message += BitConverter.ToString(dataFrame).Replace("-", " ");
            Console.WriteLine(message);
        }

        static public void DataStoreWriteToHanlder(object sender, Modbus.Data.DataStoreEventArgs e)
        {
        }
    }
}
