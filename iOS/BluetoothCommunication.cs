using System;
using System.Threading.Tasks;

using Lego.Ev3.Core;

using Foundation;
using CoreBluetooth;
using CoreFoundation;

namespace EV3Controller.iOS
{
    public class BluetoothCommunication : ICommunication
    {
        private CBCentralManager CentralBleManager { get; set; }
        CBPeripheral peripheral;

        public BluetoothCommunication()
        {
        }

        public event EventHandler<ReportReceivedEventArgs> ReportReceived;

        public Task ConnectAsync()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public Task WriteAsync(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
