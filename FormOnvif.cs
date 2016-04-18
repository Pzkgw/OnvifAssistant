
using Ozeki.Camera;
using Ozeki.Media;

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Drawing;
using System.Windows;
using OnvifAssistant.Cam;
using OnvifAssistant.Gui;
using System.Text;

namespace OnvifAssistant
{
    public partial class FormOnvif : Form
    {
        private IIPCamera _camera;
        private ImgHandler _imgHandler;
        private MediaConnector _connector;
        private VideoView _videoView;

        private OnDiscover _discoverCameras;

        private readonly  Dispatcher _logDispatch;

        private bool videoIsOn, recordStarted;

        private MPEG4Recorder _recorder;//VideoFileWriter writer;

        private readonly string
            recordTxtStart = "Recording" + Environment.NewLine + "Start",
            recordTxtStop = "Stop" + Environment.NewLine + "Recording",
            snapshotTxt = "Save" + Environment.NewLine + "Snapshot";

        int tt = 0;

        public FormOnvif()
        {
            InitializeComponent();
            this.Icon = Icon.FromHandle(Properties.Resources.img_play1.GetHicon());
            btnRecord.Text = recordTxtStart;
            btnSnapshot.Text = snapshotTxt;

            _connector = new MediaConnector();
            _imgHandler = new ImgHandler();
            _videoView = new VideoView("_videoViewerWf");
            panelVideo.Controls.Add(_videoView);
            

            _discoverCameras = new OnDiscover();
            _logDispatch = Dispatcher.CurrentDispatcher;


            
            Connect();
            

            _imgHandler.ImageReady += _imgHandler_ImageReady;
            
            //_camDispatch.BeginInvoke(new delegatePrintText(PrintText), "Connection start");  
            
        }

        private void _imgHandler_ImageReady(object sender, Ozeki.Common.GenericEventArgs<Image> e)
        {
            if (btnPlay.Image == null)
            {
                btnPlay_Click(null, null);

                InvokeGuiThread(new delegatePrintText(PrintText), "VVVVVVVVVVIDEOOOOOOOO");
            }

            if (tt == 8)
            {
                Discover();//InvokeGuiThread( new delegateToGUI(Discover));
            }

            if(tt<512) ++tt;

        }

        private void Connect()
        {
            //http://10.10.10.202/onvif/device_service
            //rtsp://10.10.10.78/axis-media/media.amp
            _camera = IPCameraFactory.GetCamera("rtsp://10.10.10.78/axis-media/media.amp", "root", "cavi123,.");// , CameraTransportType.TCP
            _camera.CameraStateChanged += camera_CameraStateChanged;


            //_camera.CameraStateChanged += _camera_CameraStateChanged;
            _connector.Connect(_camera.VideoChannel, _imgHandler);

            _videoView.SetImageProvider(_imgHandler);
            
            
            _camera.Start();
            _videoView.Start();

            //ICameraNetworkManager camIp = _camera.NetworkManager;

        }

        #region GUI Events

        void InvokeGuiThread(Delegate method, params object[] args)
        {
            _logDispatch.BeginInvoke(method, args);//Invoke(method, args)  DispatcherPriority priority
            //BeginInvoke(method, args);
        }
        private delegate void delegateToGUI();

        private delegate void delegatePrintText(string sir);
        private void PrintText(string sir)
        {
            DateTime dt = DateTime.Now;
            textLog.AppendText(string.Format("{0:00}:{1:00}:{2:00}.{3:000} ", dt.Hour, dt.Minute, dt.Second, dt.Millisecond) + sir + Environment.NewLine);
        }

        private delegate void delegateEnableControl(Control ctrl, bool enabled);
        private void ControlEnable(Control ctrl, bool enabled)
        {
            ctrl.Enabled = enabled;
            ctrl.Visible = enabled;
        }

        #endregion GUI Events


        #region ONVIF Events

        void camera_CameraStateChanged(object sender, CameraStateEventArgs e)
        {
            InvokeGuiThread(new delegatePrintText(PrintText), e.State.ToString());

            if (e.State == CameraState.Streaming)
            {
                //var messages = _camera.CurrentRtspUri.ToString();//.RtspLog.GetHead();
                InvokeGuiThread(new delegatePrintText(PrintText), _camera.CurrentRtspUri.ToString());
                
                //foreach (var message in messages)
                //{
                //    Console.WriteLine(message);
                //}
            }



        }

        #endregion ONVIF Events



        private void Discover()
        {

            List<string> cams = new List<string>();

            //while(!_discoverCameras.IPDevicesDiscovered)
            //if (i > 0) System.Threading.Thread.Sleep(200);

            for(int i=0;i<4;i++) _discoverCameras.GetDevices();

            cams = _discoverCameras.GetDevices();

            //QueryServer.IPAddresses("10.10.10.#");


            //if(cams.Count > 0)
            {
                InvokeGuiThread(new delegatePrintText(PrintText), " --- Device list start --- ");
                foreach (string cam in cams)
                {
                    InvokeGuiThread(new delegatePrintText(PrintText), cam);
                }
                InvokeGuiThread(new delegatePrintText(PrintText), " --- Device list end --- ");
            }

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (videoIsOn)
            {
                _videoView.Stop();
                btnPlay.Image = new Bitmap(Properties.Resources.img_play1, btnPlay.Size);
                videoIsOn = false;
                
            }
            else
            {
                _videoView.Start();
                btnPlay.Image = new Bitmap(Properties.Resources.silver_pause_sign, btnPlay.Size);
                videoIsOn = true;



                labelDeviceInfo.Text = GetDeviceInfo();

            }

            Delegate pointGuiControlsEnable = new delegateEnableControl(ControlEnable);
            foreach (Control ctrl in new Control[] { btnRecord, btnSnapshot, groupBoxDeviceInfo })
                InvokeGuiThread(pointGuiControlsEnable, ctrl, videoIsOn);

        }



        #region Recorder
        private void CaptureStart()
        {

            if (_camera.VideoChannel == null) return;
            var date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" +
                        DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;

            var currentpath = "c:\\" + date + ".mpeg4"; //AppDomain.CurrentDomain.BaseDirectory + date + ".mpeg4";

            _recorder = new MPEG4Recorder(currentpath);
            _recorder.MultiplexFinished += _recorder_MultiplexFinished;

            _connector.Connect(_camera.VideoChannel, _recorder.VideoRecorder);
        }

        private void CaptureStop()
        {
            if (_camera.VideoChannel == null) return;
            _connector.Disconnect(_camera.VideoChannel, _recorder.VideoRecorder);
            _recorder.Multiplex();
        }

        void _recorder_MultiplexFinished(object sender, VoIPEventArgs<bool> e)
        {
            _recorder.MultiplexFinished -= _recorder_MultiplexFinished;
            _recorder.Dispose();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (recordStarted)
            {
                CaptureStop();
                btnRecord.Text = recordTxtStart;
                recordStarted = false;
            }
            else
            {
                CaptureStart();
                btnRecord.Text = recordTxtStop;
                recordStarted = true;
            }
        }


        #endregion










        

        private string GetDeviceInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Firmware - " + _camera.CameraInfo.DeviceInfo.Firmware + "\n");
            sb.AppendLine("Hardware ID - " + _camera.CameraInfo.DeviceInfo.HardwareId + "\n");
            sb.AppendLine("Manufacture - " + _camera.CameraInfo.DeviceInfo.Manufacturer + "\n");
            sb.AppendLine("Model - " + _camera.CameraInfo.DeviceInfo.Model + "\n");
            sb.AppendLine("Serial number - " + _camera.CameraInfo.DeviceInfo.SerialNumber + "\n");
            sb.AppendLine("Discoverable - " + _camera.CameraInfo.Discoverable + "\n");
            sb.AppendLine("Date and time - " + _camera.DateAndTime + "\n");
            sb.AppendLine("Domainhost - " + _camera.DomainHost + "\n");
            sb.AppendLine("Username - " + _camera.UserName + "\n");
            sb.AppendLine("PTZ supported - " + _camera.IsPTZSupported + "\n");
            sb.AppendLine("Back Light Compensation supported - " + _camera.ImagingSettings.IsBackLightCompensationSupported + "\n");
            sb.AppendLine("Brightness supported - " + _camera.ImagingSettings.IsBrightnessSupported + "\n");
            sb.AppendLine("Color Saturation supported - " + _camera.ImagingSettings.IsColorSaturationSupported + "\n");
            sb.AppendLine("Contrast supported - " + _camera.ImagingSettings.IsContrastSupported + "\n");
            sb.AppendLine("Sharpness supported - " + _camera.ImagingSettings.IsSharpnessSupported + "\n");
            sb.AppendLine("White Balance supported - " + _camera.ImagingSettings.IsWhiteBalanceSupported + "\n");

            return sb.ToString();
        }
 /*
        private void _camera_CameraStateChanged(object sender, CameraStateEventArgs e)
        {
            if (e.State == CameraState.Streaming)
                InvokeGuiThread(() => textBox_Info.Text = GetDeviceInfo());
        }

        private void InvokeGuiThread(Action action)
        {
            BeginInvoke(action);
        }*/


    }
}