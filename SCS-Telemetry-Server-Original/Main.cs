using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCSSdkClient;
using SCSSdkClient.Object;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace SCSTelemetryServer
{
    public partial class Main : Form
    {
        public SCSSdkTelemetry Telemetry;
        RadioChecker Radios = new RadioChecker();
        Coordinates Coord = new Coordinates();
        TruckVariables Truck = new TruckVariables();
        Game Game = new Game();
        Server Server = new Server();

        public string viewName = "Driving";
        public string JSONmsg;
        public string ComPort = "0";
        string ScreenView = "Driving";
        SerialPort _port;

        static System.Threading.Timer RadioTimer;
        static System.Threading.Timer LocationTimer;
        static System.Threading.Timer UITimer;
        static Thread PortManager;

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
            PortManager = new Thread(portManager);
            PortManager.Start();
            InitializeComponent();
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
                UpdateInterval = Telemetry.UpdateInterval;
                Truck.Constant.RegPlate = data.TruckValues.ConstantsValues.LicensePlate;
                Truck.Constant.RegPlateCountryID = data.TruckValues.ConstantsValues.LicensePlateCountryId;
                Truck.Constant.Manufacture = data.TruckValues.ConstantsValues.Brand;
                Truck.Constant.Model = data.TruckValues.ConstantsValues.Name;
                Truck.Constant.FuelCap = (int)data.TruckValues.ConstantsValues.CapacityValues.Fuel;
                Truck.Constant.Transmission = data.TruckValues.ConstantsValues.MotorValues.ShifterTypeValue.ToString();
                //Truck.OnJob = data.SpecialEventsValues.OnJob.ToString();

                //Truck Warnings
                Truck.Warnings.AirPressure = data.TruckValues.CurrentValues.DashboardValues.WarningValues.AirPressure;
                Truck.Warnings.AirPressureEmergency = data.TruckValues.CurrentValues.DashboardValues.WarningValues.AirPressureEmergency;
                Truck.Warnings.Adblue = data.TruckValues.CurrentValues.DashboardValues.WarningValues.AdBlue;
                Truck.Warnings.BatteryVoltage = data.TruckValues.CurrentValues.DashboardValues.WarningValues.BatteryVoltage;
                Truck.Warnings.Fuel = data.TruckValues.CurrentValues.DashboardValues.WarningValues.FuelW;
                Truck.Warnings.OilPressure = data.TruckValues.CurrentValues.DashboardValues.WarningValues.OilPressure;
                Truck.Warnings.WaterTemperature = data.TruckValues.CurrentValues.DashboardValues.WarningValues.WaterTemperature;

                //Set Variable Values
                Truck.Current.Mileage = (int)(data.TruckValues.CurrentValues.DashboardValues.Odometer * 0.62137); //In miles
                Truck.Current.Speed = (int)data.TruckValues.CurrentValues.DashboardValues.Speed.Mph;
                Truck.Current.Gear = data.TruckValues.CurrentValues.DashboardValues.GearDashboards.ToString();
                Truck.Current.Fuel = (int)data.TruckValues.CurrentValues.DashboardValues.FuelValue.Amount;
                Truck.Current.Range = (int)(data.TruckValues.CurrentValues.DashboardValues.FuelValue.Range * 0.62137); //In Miles
                Truck.Current.CruiseControl = data.TruckValues.CurrentValues.DashboardValues.CruiseControl;
                Truck.Current.CruiseControlSpeed = (int)data.TruckValues.CurrentValues.DashboardValues.CruiseControlSpeed.Mph;
                Truck.Current.AirPressure = (int)data.TruckValues.CurrentValues.MotorValues.BrakeValues.AirPressure;
                Truck.Current.BrakeTemperature = (int)data.TruckValues.CurrentValues.MotorValues.BrakeValues.Temperature;
                Truck.Current.ParkingBrake = data.TruckValues.CurrentValues.MotorValues.BrakeValues.ParkingBrake;
                Truck.Current.EngineBrake = data.TruckValues.CurrentValues.MotorValues.BrakeValues.MotorBrake;
                Truck.Current.RetarderLevel = data.TruckValues.CurrentValues.MotorValues.BrakeValues.RetarderLevel;
                Coord.X = data.TruckValues.CurrentValues.PositionValue.Position.X;
                Coord.Y = data.TruckValues.CurrentValues.PositionValue.Position.Y;
                Coord.Z = data.TruckValues.CurrentValues.PositionValue.Position.Z;

                //Truck Lights
                Truck.Lights.AuxFront = data.TruckValues.CurrentValues.LightsValues.AuxFront.ToString();
                Truck.Lights.AuxRoof = data.TruckValues.CurrentValues.LightsValues.AuxRoof.ToString();
                Truck.Lights.Beacon = data.TruckValues.CurrentValues.LightsValues.Beacon;
                Truck.Lights.BeamHigh = data.TruckValues.CurrentValues.LightsValues.BeamHigh;
                Truck.Lights.BeamLow = data.TruckValues.CurrentValues.LightsValues.BeamLow;
                Truck.Lights.BlinkerLeftOn = data.TruckValues.CurrentValues.LightsValues.BlinkerLeftOn;
                Truck.Lights.BlinkerLeftActive = data.TruckValues.CurrentValues.LightsValues.BlinkerLeftActive;
                Truck.Lights.BlinkerRightOn = data.TruckValues.CurrentValues.LightsValues.BlinkerRightOn;
                Truck.Lights.BlinkerRightActive = data.TruckValues.CurrentValues.LightsValues.BlinkerRightActive;
                Truck.Lights.Brake = data.TruckValues.CurrentValues.LightsValues.Brake;
                Truck.Lights.Parking = data.TruckValues.CurrentValues.LightsValues.Parking;
                Truck.Lights.Reverse = data.TruckValues.CurrentValues.LightsValues.Reverse;

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
                truckRegPlate.Text = "Registration: " + Truck.Constant.RegPlate + " (" + Truck.Constant.RegPlateCountryID + ")";
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
                truckWaterTempWarn.Text = "Water Temp.: " + Truck.Warnings.WaterTemperature;
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
                PortManager.Abort();
            }
        }
        public void portManager(object obj)
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
