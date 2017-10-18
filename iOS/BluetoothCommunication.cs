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
        private CBCentralManager CentralBTManager { get; set; }
        CBPeripheral peripheral;

        public BluetoothCommunication()
        {
            CentralBTManager = new CBCentralManager();
        }

        public event EventHandler<ReportReceivedEventArgs> ReportReceived;

        public async Task ConnectAsync()
        {
            CentralBTManager.ScanForPeripherals(peripheralUuids: null);

            await Task.Delay( 3000);

            CentralBTManager.StopScan();
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
