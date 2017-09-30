using System.Threading.Tasks;

using Android.App;
using Android.Widget;
using Android.OS;

using Lego.Ev3.Core;
using Lego.Ev3.Android;

using static System.Diagnostics.Debug;

namespace EV3Controller.Droid
{
    [Activity(Label = "EV3Controller", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private bool Connected { get; set; }
        private bool IsForward { get; set; }

        private int Speed { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.myview);

			var btnForward = FindViewById<Button>(Resource.Id.myview_btnforward);
            var btnBackward = FindViewById<Button>(Resource.Id.myview_btnbackward);
            var btnLeft = FindViewById<Button>(Resource.Id.myview_btnleft);
            var btnRight = FindViewById<Button>(Resource.Id.myview_btnright);

            var btnGo = FindViewById<Button>(Resource.Id.myview_btngo);
            var btnStop = FindViewById<Button>(Resource.Id.myview_btnstop);

            //
            var communication = new BluetoothCommunication(@"PPAP09");


            var brick = new Brick(communication);
            var command = new DirectCommand(brick);

            brick.ConnectAsync();

            communication.ReportReceived += (object sender, ReportReceivedEventArgs e) => {
                WriteLine("Connected");

                Connected = true;
            };


            brick.Ports[InputPort.One].SetMode(ColorMode.ReflectiveRgb);
            brick.Ports[InputPort.One].PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                
                WriteLine(brick.Ports[InputPort.One].SIValue);


            };


            btnForward.Click += async (sender, e) => { 
                WriteLine("前");
                IsForward = true;
                if(Connected){
					// 兩輪向前
					await command.TurnMotorAtSpeedAsync(OutputPort.A, Speed);
					await command.TurnMotorAtSpeedAsync(OutputPort.B, Speed);
                }
            };

            btnBackward.Click += async (sender, e) => { 
                WriteLine("後");
                IsForward = false;
                if (Connected)
                {
					// 兩輪向後
					await command.TurnMotorAtSpeedAsync(OutputPort.A, -Speed);
					await command.TurnMotorAtSpeedAsync(OutputPort.B, -Speed);
                }
				
			};

            btnLeft.Click += async (sender, e) => { 
                WriteLine("左");

				if (Connected)
				{
					// 左輪向後，右輪向前
					await command.TurnMotorAtSpeedAsync(OutputPort.A, Speed);
					await command.TurnMotorAtSpeedAsync(OutputPort.B, Speed);
				}
				
			};

            btnRight.Click += async (sender, e) => { 
                WriteLine("右");

				if (Connected)
				{
					// 左輪向前，右輪向後
					await command.TurnMotorAtSpeedAsync(OutputPort.A, Speed);
					await command.TurnMotorAtSpeedAsync(OutputPort.B, Speed);
				}
				
			};

            btnGo.Click += async (sender, e) => { 
                WriteLine("油門");

                Speed += 5;

                if( Speed >= 50){
                    Speed = 50;
                }

				if (Connected)
				{
                    if (IsForward){
						await command.TurnMotorAtSpeedAsync(OutputPort.A, Speed);
						await command.TurnMotorAtSpeedAsync(OutputPort.B, Speed);
                    }
                    else{
						await command.TurnMotorAtSpeedAsync(OutputPort.A, -Speed);
						await command.TurnMotorAtSpeedAsync(OutputPort.B, -Speed);
                    }
				}
				
			};

            btnStop.Click += async (sender, e) => { 
                WriteLine("煞車");

				if (Connected)
				{
					// 兩輪停止
					await command.StopMotorAsync(OutputPort.A, true);
					await command.StopMotorAsync(OutputPort.B, true);
				}
				
			};

            Connected = false; 
            IsForward = true;
            Speed = 20;
        }
    }
}

