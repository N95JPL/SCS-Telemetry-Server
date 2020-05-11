namespace ArduinoSCSTelemetry
{
    public class TruckVariables
    {
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

        public class ConstantValues
        {
            public string RegPlate { get; set; }
            public string RegPlateCountryID { get; set; }
            public string Manufacture { get; set; }
            public string Model { get; set; }
            public int FuelCap { get; set; }
            public string Transmission { get; set; }
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
