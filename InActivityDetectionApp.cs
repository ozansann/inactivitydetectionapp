using System;
using InTheHand.Net.Sockets;
using System.Runtime.InteropServices;

namespace InActivityDetectionApp
{
    class Program
    {
        static BluetoothClient client;
        static BluetoothDeviceInfo[] devices;
        static void Main(string[] args)
        {
            client = new BluetoothClient();
            while (true)
            {
                checkDeviceConnected();
            }
        }

        public static void checkDeviceConnected()
        {
            bool isConnected = false;
            devices = client.DiscoverDevices();
            
            for (int i = 0; i < devices.Length; i++)
            {
                if (devices[i].Connected)
                {
                    Console.WriteLine(devices[i].DeviceName + " cihazınızla bağlı");
                    isConnected = true;
                }
            }
            if (!isConnected) 
            {
                Console.WriteLine("Bağlı cihaz yok!");
                LockWorkStation();
            }
        }

        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();
    }
}
