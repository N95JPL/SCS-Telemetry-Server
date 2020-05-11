using Newtonsoft.Json.Linq;

namespace SCSTelemetryServer
{
    public class TruckVariables
    {
        private Game Game = new Game();
        private Main Main = new Main();
        private RadioChecker Radios = new RadioChecker();
        private Coordinates Coord = new Coordinates();
        private Server Server = new Server();

        public JObject truckJSON;
        public LightValues Lights { get; set; }
        public WarningValues Warnings { get; set; }
        public CurrentValues Current { get; set; }
        public DamageValues Damage { get; set; }
        public ConstantValues Constant { get; set; }
        public TruckVariables()
        {
            Lights = new LightValues();
            Warnings = new WarningValues();
            Current = new CurrentValues();
            Damage = new DamageValues();
            Constant = new ConstantValues();
        }
        public void TruckJSON()
        {
            truckJSON = new JObject
            {
                {"TruckValues", new JObject
                {
                    {"Constant", new JObject
                    {
                        {"RegPlate", Main.MainData.TruckValues.ConstantsValues.LicensePlate},
                        {"RegPlateCountryID",Main.MainData.TruckValues.ConstantsValues.LicensePlateCountryId},
                        {"RegPlateCountry",Main.MainData.TruckValues.ConstantsValues.LicensePlateCountry},
                        {"Manufacture",Main.MainData.TruckValues.ConstantsValues.Brand},
                        {"Model",Main.MainData.TruckValues.ConstantsValues.Name},
                        {"FuelCapacity",(int)Main.MainData.TruckValues.ConstantsValues.CapacityValues.Fuel},
                        {"Transmission",Main.MainData.TruckValues.ConstantsValues.MotorValues.ShifterTypeValue.ToString()}
                    }
                    },
                    {"Current", new JObject
                    {
                        {"Mileage",(int)(Main.MainData.TruckValues.CurrentValues.DashboardValues.Odometer* 0.62137)},
                        {"Speed",(int) Main.MainData.TruckValues.CurrentValues.DashboardValues.Speed.Mph}
                    }
                    }
                }
                }
            };
        }
        
       
                //Truck.OnJob = Main.MainData.SpecialEventsValues.OnJob.ToString();

                //Truck Warnings
               /* Truck.Warnings.AirPressure = Main.MainData.TruckValues.CurrentValues.DashboardValues.WarningValues.AirPressure;
                Truck.Warnings.AirPressureEmergency = Main.MainData.TruckValues.CurrentValues.DashboardValues.WarningValues.AirPressureEmergency;
                Truck.Warnings.Adblue = Main.MainData.TruckValues.CurrentValues.DashboardValues.WarningValues.AdBlue;
                Truck.Warnings.BatteryVoltage = Main.MainData.TruckValues.CurrentValues.DashboardValues.WarningValues.BatteryVoltage;
                Truck.Warnings.Fuel = Main.MainData.TruckValues.CurrentValues.DashboardValues.WarningValues.FuelW;
                Truck.Warnings.OilPressure = Main.MainData.TruckValues.CurrentValues.DashboardValues.WarningValues.OilPressure;
                Truck.Warnings.WaterTemperature = Main.MainData.TruckValues.CurrentValues.DashboardValues.WarningValues.WaterTemperature;

                //Set Variable Values
                Truck.Current.Mileage = (int) (Main.MainData.TruckValues.CurrentValues.DashboardValues.Odometer* 0.62137); //In miles
                Truck.Current.Speed = (int) Main.MainData.TruckValues.CurrentValues.DashboardValues.Speed.Mph;
        Truck.Current.Gear = 
                Truck.Current.Fuel = (int) Main.MainData.TruckValues.CurrentValues.DashboardValues.FuelValue.Amount;
        Truck.Current.Range = (int) (Main.MainData.TruckValues.CurrentValues.DashboardValues.FuelValue.Range* 0.62137); //In Miles
                Truck.Current.CruiseControl = Main.MainData.TruckValues.CurrentValues.DashboardValues.CruiseControl;
                Truck.Current.CruiseControlSpeed = (int) Main.MainData.TruckValues.CurrentValues.DashboardValues.CruiseControlSpeed.Mph;
        Truck.Current.AirPressure = (int) Main.MainData.TruckValues.CurrentValues.MotorValues.BrakeValues.AirPressure;
        Truck.Current.BrakeTemperature = (int) Main.MainData.TruckValues.CurrentValues.MotorValues.BrakeValues.Temperature;
        Truck.Current.ParkingBrake = Main.MainData.TruckValues.CurrentValues.MotorValues.BrakeValues.ParkingBrake;
                Truck.Current.EngineBrake = Main.MainData.TruckValues.CurrentValues.MotorValues.BrakeValues.MotorBrake;
                Truck.Current.RetarderLevel = Main.MainData.TruckValues.CurrentValues.MotorValues.BrakeValues.RetarderLevel;
                Coord.X = Main.MainData.TruckValues.CurrentValues.PositionValue.Position.X;
                Coord.Y = Main.MainData.TruckValues.CurrentValues.PositionValue.Position.Y;
                Coord.Z = Main.MainData.TruckValues.CurrentValues.PositionValue.Position.Z;

                //Truck Lights
                Truck.Lights.AuxFront = Main.MainData.TruckValues.CurrentValues.LightsValues.AuxFront.ToString();
                Truck.Lights.AuxRoof = Main.MainData.TruckValues.CurrentValues.LightsValues.AuxRoof.ToString();
                Truck.Lights.Beacon = Main.MainData.TruckValues.CurrentValues.LightsValues.Beacon;
                Truck.Lights.BeamHigh = Main.MainData.TruckValues.CurrentValues.LightsValues.BeamHigh;
                Truck.Lights.BeamLow = Main.MainData.TruckValues.CurrentValues.LightsValues.BeamLow;
                Truck.Lights.BlinkerLeftOn = Main.MainData.TruckValues.CurrentValues.LightsValues.BlinkerLeftOn;
                Truck.Lights.BlinkerLeftActive = Main.MainData.TruckValues.CurrentValues.LightsValues.BlinkerLeftActive;
                Truck.Lights.BlinkerRightOn = Main.MainData.TruckValues.CurrentValues.LightsValues.BlinkerRightOn;
                Truck.Lights.BlinkerRightActive = Main.MainData.TruckValues.CurrentValues.LightsValues.BlinkerRightActive;
                Truck.Lights.Brake = Main.MainData.TruckValues.CurrentValues.LightsValues.Brake;
                Truck.Lights.Parking = Main.MainData.TruckValues.CurrentValues.LightsValues.Parking;
                Truck.Lights.Reverse = Main.MainData.TruckValues.CurrentValues.LightsValues.Reverse;*/

        public class ConstantValues
        {
            public string RegPlate { get; set; }
            public string RegPlateCountryID { get; set; }
            public string Manufacture { get; set; }
            public string Model { get; set; }
            public int FuelCap { get; set; }
            public string Transmission { get; set; }
            public string ForwardGearCount { get; set; }
            public string ReverseGearCount { get; set; }
            public string RetarderStepCount { get; set; }
        }

        public class CurrentValues
        {
            public int Mileage { get; set; }
            public int Speed { get; set; }
            public string Gear { get; set; }
            public int Fuel { get; set; }
            public int Range { get; set; }
            public bool CruiseControl { get; set; }
            public int CruiseControlSpeed { get; set; }
            public bool ElectricEnabled { get; set; }
            public bool EngineEnabled { get; set; }
            public int AirPressure { get; set; }
            public int BrakeTemperature { get; set; }
            public bool ParkingBrake { get; set; }
            public bool EngineBrake { get; set; }
            public uint RetarderLevel { get; set; }
        }

        public class WarningValues
        {
            public bool AirPressure { get; set; }
            public bool AirPressureEmergency { get; set; }
            public bool Fuel { get; set; }
            public bool Adblue { get; set; }
            public bool OilPressure { get; set; }
            public bool WaterTemperature { get; set; }
            public bool BatteryVoltage { get; set; }
        }

        public class LightValues
        {
            public string AuxFront { get; set; }
            public string AuxRoof { get; set; }
            public bool BlinkerLeftActive { get; set; }
            public bool BlinkerRightActive { get; set; }
            public bool BlinkerLeftOn { get; set; }
            public bool BlinkerRightOn { get; set; }
            public bool Parking { get; set; }
            public bool BeamLow { get; set; }
            public bool BeamHigh { get; set; }
            public bool Beacon { get; set; }
            public bool Brake { get; set; }
            public bool Reverse { get; set; }
        }

        public class DamageValues
        {
            public int Engine { get; set; }
            public int Transmission { get; set; }
            public int Cabin { get; set; }
            public int Chassis { get; set; }
            public int Wheels { get; set; }
        }
    }
}