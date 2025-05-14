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
    public class CommunicationLogViewModel : INotifyPropertyChanged
    {
        public event Action<object, EventArgs> NewMessageGenerated;
        public event Action<object, EventArgs> IsDateTimeChanged;
        public event Action<object, EventArgs> IsByteTextMessageChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<PacketLog> _originalPacketLogs = new ObservableCollection<PacketLog>();
        public ObservableCollection<PacketLog> OriginalPacketLogs
        {
            get
            {
                return _originalPacketLogs;
            }
            set
            {
                _originalPacketLogs = value;
            }
        }

        private ObservableCollection<PacketLog> _frozenPacketLogs = new ObservableCollection<PacketLog>();
        public ObservableCollection<PacketLog>  FrozenPacketLogs
        {
            get
            {
                return _frozenPacketLogs;
            }
            set
            {
                _frozenPacketLogs = value;
            }
        }

        private SlaveHelper _slave;
        public SlaveHelper Slave
        {
            get { return _slave; }
            set { _slave = value; }
        }

        private bool _isTime;
        public bool IsTime
        {
            get
            {
                return _isTime;
            }
            set
            {
                _isTime = value;
                IsDateTimeChanged?.Invoke(this, EventArgs.Empty);
                OnPropertyChanged(nameof(IsTime));
            }
        }

        private bool _isDate;
        public bool IsDate
        {
            get
            {
                return _isDate;
            }
            set
            {
                _isDate = value;
                IsDateTimeChanged?.Invoke(this, EventArgs.Empty);
                OnPropertyChanged(nameof(IsDate));
            }
        }

        private bool _isByteMessage;
        public bool IsByteMessage
        {
            get
            {
                return _isByteMessage;
            }
            set
            {
                _isByteMessage = value;
                IsByteTextMessageChanged?.Invoke(this, EventArgs.Empty);
                OnPropertyChanged(nameof(IsByteMessage));
            }
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
                OnPropertyChanged(nameof(IsRunning));
            }
        }

        private bool _isTextMessage;
        public bool IsTextMessage
        {
            get
            {
                return _isTextMessage;
            }
            set
            {
                _isTextMessage = value;
                IsByteTextMessageChanged?.Invoke(this, EventArgs.Empty);
                OnPropertyChanged(nameof(IsTextMessage));
            }
        }

        public CommunicationLogViewModel(SlaveHelper slaveHelper)
        {
            Slave = slaveHelper;
            Slave.Slave.ModbusSlaveRequestReceived += OnModbusSlaveRequestReceived;
            IsTime = true;
            IsByteMessage = true;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        internal void CopyPacketLogs()
        {
            FrozenPacketLogs = new ObservableCollection<PacketLog>(
                OriginalPacketLogs.Select(item => item.DeepCopy())
                );
        }

        private void OnModbusSlaveRequestReceived(object sender,Modbus.Device.ModbusSlaveRequestEventArgs e)
        {
            Dispatcher dispatcher = Application.Current.Dispatcher;
            dispatcher.BeginInvoke(new Action<object, Modbus.Device.ModbusSlaveRequestEventArgs>(GenerateNewPacketLog), sender, e);
        }

        private void GenerateNewPacketLog(object sender, Modbus.Device.ModbusSlaveRequestEventArgs e)
        {
            var packetLog = new PacketLog()
            {
                Index = OriginalPacketLogs.Count,
                ByteMessage = BitConverter.ToString(e.Message.MessageFrame),
                TextMessage = e.Message.ToString(),
                TimeStamp = DateTime.Now.ToString("HH:mm:ss:fff"),
                DateStamp = DateTime.Now.ToString("yyyy-MM-dd")
            };


            OriginalPacketLogs.Add(packetLog);

            NewMessageGenerated?.Invoke(this, EventArgs.Empty);
        }
    }

    public class PacketLog
    {
        public int Index {get; set;}
        public string DateStamp { get; set; }
        public string TimeStamp { get; set; }
        public string ByteMessage { get; set; }
        public string TextMessage { get; set; }


        public PacketLog DeepCopy()
        {
            return new PacketLog
            {
                Index = this.Index,
                DateStamp = this.DateStamp,
                TimeStamp = this.TimeStamp,
                ByteMessage = this.ByteMessage,
                TextMessage = this.TextMessage
            };
        }

    }
}
