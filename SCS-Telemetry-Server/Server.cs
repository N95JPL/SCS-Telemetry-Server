using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace SCSTelemetryServer
{
    internal class Server
    {
        public string ComPort;
        private SerialPort _port;

        private RadioChecker Radios = new RadioChecker();
        private Coordinates Coord = new Coordinates();
        private TruckVariables Truck = new TruckVariables();
        private Game Game = new Game();

        public void serverManager(Object obj)
        {
        }

        public void portManager(Object obj)
        {
            if (ComPort == null)
            {
                GetAllPorts();
                _port = new SerialPort(ComPort, 14400);
                _port.WriteTimeout = 500;
                _port.ReadTimeout = 500;
            }
            if (_port.IsOpen == false)
            {
                try
                {
                    _port.Open();
                }
                catch { }
            }
            else
            {
                //MessageBox.Show("COM OPEN!");
                //string Day = Game.Values.WeekDay;
                //string Time = Game.Values.Time;
                //string msg = Truck.Constant.Model + ";";
                //_port.Write(msg);
                //MessageBox.Show(msg);
            }
        }

        public List<string> GetAllPorts()
        {
            List<String> allPorts = new List<String>();
            foreach (String portName in SerialPort.GetPortNames())
            {
                allPorts.Add(portName);
                ComPort = portName;
            }
            return allPorts;
        }
    }
}