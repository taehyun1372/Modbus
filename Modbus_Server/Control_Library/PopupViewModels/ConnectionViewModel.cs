using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Control_Library.Core;
using System.Windows.Input;

namespace Control_Library.PopupViewModels
{
    public class ConnectionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                OnPropertyChanged(nameof(UnitId));
            }
        }

        public void OnOkayClicked()
        {
            Slave.Address = Address;
            Slave.Port = Port;
            Slave.UnitId = UnitId;
            Slave.Connect();
        }


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

        public ConnectionViewModel(SlaveHelper slave)
        {
            Slave = slave;
            Address = slave.Address;
            Port = slave.Port;
            UnitId = slave.UnitId;
        }
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
