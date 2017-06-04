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
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            var bluetoothWorker = new BluetoothWorker();
            var devices = bluetoothWorker.GetBluetoothDevicesList();

            foreach(var device in devices){
                if( device == @"[EV3 的名稱]" ){
                    // 開始連結
                }
            }

            var communication = new BluetoothCommunication(@"[EV3 的名稱]");
            var brick = new Brick(communication);
            var command = new DirectCommand(brick);

            brick.ConnectAsync();

            communication.ReportReceived += async (object sender, ReportReceivedEventArgs e) => {
                

				await command.TurnMotorAtSpeedAsync(OutputPort.B, 50);
				await command.StartMotorAsync(OutputPort.B);

                await Task.Delay(2000);

				await command.StopMotorAsync(OutputPort.B, true);


            };


            brick.Ports[InputPort.One].SetMode(ColorMode.ReflectiveRgb);
            brick.Ports[InputPort.One].PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => {
                
                WriteLine(brick.Ports[InputPort.One].SIValue);
            };


        }
    }
}

