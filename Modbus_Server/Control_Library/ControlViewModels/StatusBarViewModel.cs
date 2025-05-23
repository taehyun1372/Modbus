using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Control_Library.Core;

namespace Control_Library.ControlViewModels
{
    public class StatusBarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private SlaveHelper _slave;
        public SlaveHelper Slave
        {
            get
            {
                return _slave;
            }
            set
            {
                _slave = value;
            }
        }

        public string Address
        {
            get
            {
                return (Slave == null)? "" : Slave.Address;
            }
        }

        public int Port
        {
            get
            {
                return (Slave == null) ? 0 : Slave.Port;
            }
        }

        public int ConnectionCounts
        {
            get
            {
                return (Slave == null) ? 0 : Slave.ConnectionCounts;
            }
        }

        public int TxCounts
        {
            get
            {
                return (Slave == null) ? 0 : Slave.TxCounts;
            }
        }

        public int RxCounts
        {
            get
            {
                return (Slave == null) ? 0 : Slave.RxCounts;
            }
        }

        public bool IsConnected
        {
            get
            {
                return (Slave == null) ? false : Slave.IsConnected;
            }
        }


        public StatusBarViewModel(SlaveHelper slaveHelper)
        {
            Slave = slaveHelper;
            Slave.PropertyChanged += OnSlavePropertyChanged;
        }

        private void OnSlavePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.Address))
            {
                OnPropertyChanged(nameof(this.Address));
            }
            else if (e.PropertyName == nameof(this.Port))
            {
                OnPropertyChanged(nameof(this.Port));
            }
            else if (e.PropertyName == nameof(this.ConnectionCounts))
            {
                OnPropertyChanged(nameof(this.ConnectionCounts));
            }
            else if (e.PropertyName == nameof(this.TxCounts))
            {
                OnPropertyChanged(nameof(this.TxCounts));
            }
            else if (e.PropertyName == nameof(this.RxCounts))
            {
                OnPropertyChanged(nameof(this.RxCounts));
            }
            else if (e.PropertyName == nameof(this.IsConnected))
            {
                OnPropertyChanged(nameof(this.IsConnected));
            }
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
