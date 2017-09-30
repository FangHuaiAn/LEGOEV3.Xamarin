using System;

using UIKit;
using CoreBluetooth;

using Lego.Ev3.Core;


namespace EV3Controller.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CBCentralManager manager = new CBCentralManager();
            CBPeripheral peripheral =
            //manager.ConnectPeripheral(new CBPeripheral())

			//var communication = new BluetoothCommunication(@"PPAP09");
			//var brick = new Brick(communication);
			//var command = new DirectCommand(brick);

			//brick.ConnectAsync();

			communication.ReportReceived += async (object sender, ReportReceivedEventArgs e) => {


				await command.TurnMotorAtSpeedAsync(OutputPort.B, 50);
				await command.StartMotorAsync(OutputPort.B);

				await Task.Delay(2000);




			};

            btnForward.TouchUpInside += (sender, e) => {
                
            };

			btnBackward.TouchUpInside += (sender, e) => {

			};

            btnLeft.TouchUpInside += (sender, e) => {

			};

            btnRight.TouchUpInside += (sender, e) => {

			};


            btnGo.TouchUpInside += (sender, e) => {

			};

            btnStop.TouchUpInside += (sender, e) => {

			};

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();	
        }
    }
}
