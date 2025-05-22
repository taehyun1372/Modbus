using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using System.Net.Sockets;
using System.Net; 

namespace _31_NModbus_Connection
{
    class Program
    {
        static public IPEndPoint _ep;
        static public TcpListener _listener;
        static public ModbusTcpSlave _slave;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            while (true)
            {
                Console.WriteLine("Enter a command..");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    Connect();
                }
                else if (input == "2")
                {
                    Disconnect();
                }
                else if (input == "3")
                {
                    _slave.UnitId = 2;
                }
            }
            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }

        static public void Connect()
        {
            if (_slave != null)
            {
                Console.WriteLine("A sever connection already exists");
                return;
            }
            _ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1500);
            _listener = new TcpListener(_ep);

            _slave = ModbusTcpSlave.CreateTcp(1, _listener);
            Console.WriteLine("Server is listening..");
            _slave.Listen();
            Console.WriteLine("Connected Successfully");
        }

        static public void Disconnect()
        {
            if (_slave == null)
            {
                Console.WriteLine("Sever connection doesn't exist");
                return;
            }
            _slave?.Dispose();
            _slave = null;
            _listener = null;
            Console.WriteLine("Disconnected Successfully");
        }
    }
}
