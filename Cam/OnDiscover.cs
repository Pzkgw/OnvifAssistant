using Ozeki.Camera;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Network_Video_Recorder01.Cam
{
    class OnDiscover
    {
        private List<string> _devices;

        public bool IPDevicesDiscovered;

        public OnDiscover()
        {
            _devices = new List<string>();

        }

        /*
        private void FillDevicesWithUsbCameras()
        {
            var usbList = WebCameraFactory.GetDevices();
            foreach (var device in usbList)
            {
                _devices.Add("[USB] Name: " + device.Name);
                //USBDevicesDiscovered = true;
            }
        }*/

        private void FillDevicesWithIpCameras()
        {
            IPCameraFactory.DeviceDiscovered += IPCameraFactory_DeviceDiscovered;
            IPCameraFactory.DiscoverDevices();
            IPCameraFactory.DeviceDiscovered -= IPCameraFactory_DeviceDiscovered;
        }

        private void IPCameraFactory_DeviceDiscovered(object sender, DiscoveryEventArgs e)
        {
            _devices.Add("[IPCamera] Host: " + e.Device.Host + " Uri: " + e.Device.Uri);
            IPDevicesDiscovered = true;

        }

        public List<string> GetDevices()
        {
            //lock (_devices)
            {
                _devices.Clear();
                IPDevicesDiscovered = false;

                FillDevicesWithIpCameras();
            }
            return _devices;
        }

    }
}
