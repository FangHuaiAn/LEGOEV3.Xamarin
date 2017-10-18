using System;

using UIKit;
using Foundation;
using ExternalAccessory;

using Lego.Ev3.Core;

using static System.Diagnostics.Debug;


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

            NSNotificationCenter.DefaultCenter.AddObserver(new NSString("EAAccessoryDidConnect"),(NSNotification obj) =>{
                WriteLine("EAAccessoryDidConnect");
            }) ;

			NSNotificationCenter.DefaultCenter.AddObserver(new NSString("EAAccessoryDidDisconnect"), (NSNotification obj) => {
				WriteLine("EAAccessoryDidDisconnect");
			});


			EAAccessoryManager.SharedAccessoryManager.ShowBluetoothAccessoryPicker(null, (obj) => {
                WriteLine( obj.LocalizedDescription);
            });






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
