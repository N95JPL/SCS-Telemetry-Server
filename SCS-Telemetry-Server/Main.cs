using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCSSdkClient;
using SCSSdkClient.Object;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using SCSTelemetryServer.Properties;

namespace SCSTelemetryServer
{
    public partial class Main : Form
    {
        public SCSSdkTelemetry Telemetry;
        private RadioChecker Radios = new RadioChecker();
        private Coordinates Coord = new Coordinates();
        private TruckVariables Truck = new TruckVariables();
        private Game Game = new Game();
        //private Server Server = new Server();

        public SimpleHTTPServer myServer;

        public SCSTelemetry MainData;
        public string viewName = "Driving";
        public string JSONmsg;
        public string ComPort = "0";
        public string ScreenView = "Driving";
        public SerialPort _port;

        private static System.Threading.Timer RadioTimer;
        private static System.Threading.Timer LocationTimer;
        private static System.Threading.Timer UITimer;
        private static Thread PortManager;

        public int UpdateInterval { get; set; }

        public Main()
        {
            //GetAllPorts();
            //PortManager = new Thread(new ThreadStart(portManager));
            Telemetry = new SCSSdkTelemetry();
            Telemetry.Data += Telemetry_Data;
            /*            Telemetry.JobStarted += TelemetryOnJobStarted;
                        Telemetry.JobCancelled += TelemetryJobCancelled;
                        Telemetry.JobDelivered += TelemetryJobDelivered;
                        Telemetry.Fined += TelemetryFined;
                        Telemetry.Tollgate += TelemetryTollgate;
                        Telemetry.Ferry += TelemetryFerry;
                        Telemetry.Train += TelemetryTrain;*/
            //Telemetry.RefuelStart += TelemetryRefuel;
            //Telemetry.RefuelEnd += TelemetryRefuelEnd;
            //Telemetry.RefuelPayed += TelemetryRefuelPayed;
            if (Telemetry.Error != null)
            {
                MessageBox.Show("An error has occured!! OOPS!");
            }

            RadioTimer = new System.Threading.Timer(new TimerCallback(Radios.RadioCheck),
                null,
                0,
                4500);

            LocationTimer = new System.Threading.Timer(new TimerCallback(Coord.getDistance),
                null,
                3000,
                20000);
            UITimer = new System.Threading.Timer(new TimerCallback(setUIValues),
                null,
                0,
                100);
            //PortManager = new Thread(portManager);
            //PortManager.Start();
            //Directory.GetCurrentDirectory() + 
            InitializeComponent();
            myServer = new SimpleHTTPServer("/", Settings.Default.WebPort);
        }

        /*        private void TelemetryOnJobStarted(object sender, EventArgs e) =>
                    MessageBox.Show("Just started job OR loaded game with active.");

                private void TelemetryJobCancelled(object sender, EventArgs e) =>
                    MessageBox.Show("Job Cancelled");

                private void TelemetryJobDelivered(object sender, EventArgs e) =>
                    MessageBox.Show("Job Delivered");

                private void TelemetryFined(object sender, EventArgs e) =>
                    MessageBox.Show("Fined");

                private void TelemetryTollgate(object sender, EventArgs e) =>
                    MessageBox.Show("Tollgate");

                private void TelemetryFerry(object sender, EventArgs e) =>
                    MessageBox.Show("Ferry");

                private void TelemetryTrain(object sender, EventArgs e) =>
                    MessageBox.Show("Train");*/
        //private void TelemetryRefuel(object sender, EventArgs e) => rtb_fuel.Invoke((MethodInvoker)(() => rtb_fuel.BackColor = Color.Green));
        //private void TelemetryRefuelEnd(object sender, EventArgs e) => rtb_fuel.Invoke((MethodInvoker)(() => rtb_fuel.BackColor = Color.Red));

        /*        private void TelemetryRefuelPayed(object sender, EventArgs e)
                {
                    MessageBox.Show("Fuel Payed");
                }*/

        public void Telemetry_Data(SCSTelemetry data, bool updated)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new TelemetryData(Telemetry_Data), data, updated);
                    return;
                }
                MainData = data;
                UpdateInterval = Telemetry.UpdateInterval;
                
                //Truck.OnJob = data.SpecialEventsValues.OnJob.ToString();

                //Game Values
                Game.Values.Time = data.CommonValues.GameTime.Date.ToString();
                Game.Values.Day = data.CommonValues.GameTime.Date.Day;
                Game.Values.WeekDay = data.CommonValues.GameTime.Date.DayOfWeek.ToString();

                //Format Game Values
                Game.Values.Time = Game.Values.Time.Remove(0, 11);
                Game.Values.Time = Game.Values.Time.Remove(5, 3);
                Game.Values.WeekDay = Game.Values.WeekDay.Substring(0, 3);

                lbGeneral.Text = "General info: \n\n" +
                                 "SDK Running: " + $"{data.SdkActive}\n\n" +
                                 "SDK Version: " + $"{data.DllVersion}\n\n" +
                                 "Game: " + $"{data.Game}\n\n" +
                                 "Game Version: " + $"{data.GameVersion.Major}.{data.GameVersion.Minor}\n\n" +
                                 "Telemetry Version: " + $"{data.TelemetryVersion.Major}.{data.TelemetryVersion.Minor}\n\n" +
                                 "In-Game Time: " + Game.Values.WeekDay + " - " + Game.Values.Time + "\n\n" +
                                 "In-Game Day: " + Game.Values.Day + "\n\n" +
                                 "Simulation TimeStamp: " + $"{data.SimulationTimestamp}\n\n" +
                                 "Render TimeStamp: " + $"{data.RenderTimestamp}\n\n" +
                                 "Game Paused: " + $"{data.Paused}\n\n" +
                                 "Update Int.: " + UpdateInterval + "m\n\n" +
                                 "COM Port: " + ComPort;
                Truck.TruckConstant(data.TruckValues);
                Truck.truckConstantString = data.TruckValues;
            }

            catch (Exception ex)
            {
                // ignored atm i found no proper way to shut the telemetry down and down call this anymore when this or another thing is already disposed
                Console.WriteLine("Telemetry was closed: " + ex);
            }
        }

        private void setUIValues(Object obj)
        {
            try
            {
                //Show Mainly Static Truck Values
                /*truckRegPlate.Text = "Registration: " + Truck.Constant.RegPlate + " (" + Truck.Constant.RegPlateCountryID + ")";
                truckManufacture.Text = "Manufacturer: " + Truck.Constant.Manufacture;
                truckModel.Text = "Model: " + Truck.Constant.Model;
                truckFuelCap.Text = "Fuel Capacity: " + Truck.Constant.FuelCap;
                truckTransmission.Text = "Transmission: " + Truck.Constant.Transmission;
                truckCity.Text = "City: " + Coord.currentCity;
                truckCountry.Text = "Country: " + Coord.currentCountry;
                truckRadioStation.Text = "Radio Station: " + Radios.RadioStation;
                truckRadioSignal.Text = "Radio Signal: " + Radios.RadioSignalText;

                //Show Variable Truck Values
                truckMileage.Text = "Mileage: " + Truck.Current.Mileage;
                truckSpeed.Text = "Speed: " + Truck.Current.Speed + " MPH";
                truckGear.Text = "Gear: " + Truck.Current.Gear;
                truckFuel.Text = "Remaining Fuel: " + Truck.Current.Fuel + "L";
                truckFuelRange.Text = "Range: " + Truck.Current.Range + " Miles";
                truckCruiseControl.Text = "CC Active: " + Truck.Current.CruiseControl;
                truckCruiseControlSpeed.Text = "CC Speed: " + Truck.Current.CruiseControlSpeed;
                truckLocation.Text = "GPS: " + string.Format("{0:N3}", Coord.X) + ":" + string.Format("{0:N3}", Coord.Y) + ":" + string.Format("{0:N3}", Coord.Z);
                truckAirPressure.Text = "Air Pressure: " + Truck.Current.AirPressure + "psi";
                truckBrakeTemperature.Text = "Brake Temperature: " + Truck.Current.BrakeTemperature + "°C";
                truckRetarderLevel.Text = "Retarder: " + Truck.Current.RetarderLevel;
                //Show Truck Warnings
                if (Truck.Warnings.Adblue) { truckAdblueWarn.BackColor = System.Drawing.Color.Red; } else { truckAdblueWarn.BackColor = System.Drawing.Color.Green; }
                truckAdblueWarn.Text = "AdBlue: " + Truck.Warnings.Adblue;
                if (Truck.Warnings.AirPressureEmergency) { truckAirPressureEmerWarn.BackColor = System.Drawing.Color.Red; } else { truckAirPressureEmerWarn.BackColor = System.Drawing.Color.Green; }
                truckAirPressureEmerWarn.Text = "Air Pres. Emergency: " + Truck.Warnings.AirPressureEmergency;
                if (Truck.Warnings.AirPressure) { truckAirPressureWarn.BackColor = System.Drawing.Color.Red; } else { truckAirPressureWarn.BackColor = System.Drawing.Color.Green; }
                truckAirPressureWarn.Text = "Air Pressure: " + Truck.Warnings.AirPressure;
                if (Truck.Warnings.BatteryVoltage) { truckBatteryVoltageWarn.BackColor = System.Drawing.Color.Red; } else { truckBatteryVoltageWarn.BackColor = System.Drawing.Color.Green; }
                truckBatteryVoltageWarn.Text = "Battery: " + Truck.Warnings.BatteryVoltage;
                if (Truck.Warnings.Fuel) { truckFuelWarn.BackColor = System.Drawing.Color.Red; } else { truckFuelWarn.BackColor = System.Drawing.Color.Green; }
                truckFuelWarn.Text = "Fuel: " + Truck.Warnings.Fuel;
                if (Truck.Warnings.OilPressure) { truckOilPressureWarn.BackColor = System.Drawing.Color.Red; } else { truckOilPressureWarn.BackColor = System.Drawing.Color.Green; }
                truckOilPressureWarn.Text = "Oil Pressure: " + Truck.Warnings.OilPressure;
                if (Truck.Warnings.WaterTemperature) { truckWaterTempWarn.BackColor = System.Drawing.Color.Red; } else { truckWaterTempWarn.BackColor = System.Drawing.Color.Green; }
                truckWaterTempWarn.Text = "Water Temp.: " + Truck.Warnings.WaterTemperature;*/
                jsonTest.Text = JsonConvert.SerializeObject(Truck.truckConstant, Formatting.Indented);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }

        private void ScreenText_Enter(object sender, EventArgs e)
        {
            
            throw new NotImplementedException();
        }

        private void ArduinoETS2Telemetry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Telemetry.pause(); // that line make it possible, but not every application wants to ask the user to quit, need to see if i can change that, when not use the try catch and IGNORE it (nothing changed )
            if (MessageBox.Show("Are you sure you want to quit?", "Arduino-ETS2-Server", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                Telemetry.resume();
                return;
            }
            else
            {
                RadioTimer.Dispose();
                LocationTimer.Dispose();
                UITimer.Dispose();
                Telemetry.Dispose();
                //PortManager.Abort();
            }
        }

        public void portManager(object obj)
        {
           /* while (true)
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
            }*/
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

        private void screenButton_Click(object sender, EventArgs e)
        {
            ScreenView = screenText.Text;
        }
    }
}