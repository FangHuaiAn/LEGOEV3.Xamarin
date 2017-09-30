// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace EV3Controller.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnBackward { get; set; }

		[Outlet]
		UIKit.UIButton btnForward { get; set; }

		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.UIButton btnLeft { get; set; }

		[Outlet]
		UIKit.UIButton btnRight { get; set; }

		[Outlet]
		UIKit.UIButton btnStop { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnForward != null) {
				btnForward.Dispose ();
				btnForward = null;
			}

			if (btnBackward != null) {
				btnBackward.Dispose ();
				btnBackward = null;
			}

			if (btnLeft != null) {
				btnLeft.Dispose ();
				btnLeft = null;
			}

			if (btnRight != null) {
				btnRight.Dispose ();
				btnRight = null;
			}

			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}

			if (btnStop != null) {
				btnStop.Dispose ();
				btnStop = null;
			}
		}
	}
}
