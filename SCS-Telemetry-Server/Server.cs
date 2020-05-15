using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        /*public void portManager(object obj)
        {
            while (true)
            {
                 if (ComPort == "0")
                 {
                     GetAllPorts();
                     _port = new SerialPort(ComPort, 57600);
                     _port.WriteTimeout = 300;
                     _port.ReadTimeout = 50;
                 }
                 if (_port.IsOpen == false)
                 {
                     try
                     {
                         _port.Open();
                     }
                     catch (Exception ex) { Console.WriteLine("Exception: " + ex); ComPort = "0"; }
                 }
                 else
                 {
                     try
                     {
                         string Message = _port.ReadLine();
                         Console.WriteLine("Message: " + Message);
                         if (Message == "A\r")
                         {
                             String Gear = "N";
                             decimal FuelP = (decimal)Truck.Current.Fuel / (decimal)Truck.Constant.FuelCap;
                             FuelP = decimal.Round(FuelP, 3, MidpointRounding.AwayFromZero);

                             if (int.Parse(Truck.Current.Gear) > 0)
                             {
                                 Gear = Truck.Constant.Transmission.Substring(0, 1) + Truck.Current.Gear;
                             }
                             else if (int.Parse(Truck.Current.Gear) > 0)
                             {
                                 Gear = "N";
                             }
                             else if (int.Parse(Truck.Current.Gear) < 0)
                             {
                                 Gear = "R" + Truck.Current.Gear.Remove(0, 1);
                             }
                             String CruiseSpeed = "--";
                             if (Truck.Current.CruiseControlSpeed > 0)
                             {
                                 CruiseSpeed = Truck.Current.CruiseControlSpeed.ToString();
                             }
                             else { CruiseSpeed = "--"; }
                             String airPressureWarn;
                             if (Truck.Warnings.AirPressureEmergency)
                             {
                                 airPressureWarn = "Emergency";
                             }
                             else if (Truck.Warnings.AirPressure)
                             {
                                 airPressureWarn = "Warning";
                             }
                             else
                             {
                                 airPressureWarn = "Normal";
                             }
                             JObject mainJSON = new JObject
                             {
                             {"GameTime",(Game.Values.WeekDay+"-"+Game.Values.Time)},
                             {"ScreenView", ScreenView },
                             {"GameRadio", Radios.RadioStation },
                             {"CurrentCity",Coord.currentCity },
                             {"CurrentCountry",Coord.currentCountry },
                                 {
                                     "truck", new JObject
                                     {
                                         {"Gear",Gear},
                                         {"AirPressure", Truck.Current.AirPressure },
                                         {"BrakeTemperature", Truck.Current.BrakeTemperature},
                                         {"Speed", Truck.Current.Speed.ToString() },
                                         {"Fuel", FuelP},
                                         {"Range", Truck.Current.Range.ToString()},
                                         {"CruiseSpeed", CruiseSpeed},
                                         {"ParkingB", Truck.Current.ParkingBrake },
                                         {"Cruise",Truck.Current.CruiseControl },
                                         {"EngineB", Truck.Current.EngineBrake },
                                         {"Retarder", Truck.Current.RetarderLevel }
                                     }
                                 },
                                 {
                                     "warning", new JObject
                                     {
                                         {"AirPressure", airPressureWarn }
                                     }
                                 }
                             };
                             JSONmsg = mainJSON.ToString(Formatting.None);
                             Console.WriteLine(JSONmsg);
                             try
                             {
                                 _port.WriteLine(JSONmsg);
                             }
                             catch
                             {
                                 _port.Close();
                                 Console.WriteLine("Exception: ");
                                 ComPort = "0";
                             }
                         }
                         else if (Message == "LEFT\r")
                         {
                             ScreenView = "Brakes";
                         }
                         else if (Message == "RIGHT\r")
                         {
                             ScreenView = "Driving";
                         }
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine("Exception: " + ex);
                     }
                 }
             }
        }*/
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
