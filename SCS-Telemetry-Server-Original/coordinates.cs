using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace SCSTelemetryServer
{
    public class Coordinates
    {
        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
        public partial class Cities
        {
            [JsonProperty("citiesList")]
            public CitiesList[] CitiesList { get; set; }
        }
        public partial class CitiesList
        {
            [JsonProperty("gameName")]
            public string GameName { get; set; }

            [JsonProperty("realName")]
            public string RealName { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("x")]
            public string X { get; set; }

            [JsonProperty("y")]
            public string Y { get; set; }

            [JsonProperty("z")]
            public string Z { get; set; }
        }
        /*public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public string GameName { get; set; }
        public string RealName { get; set; }
        public string Country { get; set; }*/
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string currentCity { get; set; }
        public string currentCountry { get; set; }


        public void getDistance(Object obj)
        {
            long lowestDistance = 10000000;
            string closestCity = "Hi";
            string closestCountry = "This didn't work out...";
            var CityList = JsonConvert.DeserializeObject<Cities>(File.ReadAllText(@".\cities_ETS2-All-DLC.json"));
            //var info = CityList.CitiesList[0];
            for (int i = 0; i < 230; i++)
            {
                var info = CityList.CitiesList[i];
                double x2;
                double y2;
                double z2;
                Double.TryParse(info.X, out x2);
                Double.TryParse(info.Y, out y2);
                Double.TryParse(info.Z, out z2);

                double distance = Math.Pow(Math.Pow(X - x2, 2) + Math.Pow((Y - y2), 2) + Math.Pow((Z - z2), 2), 0.5);
                if (distance < lowestDistance)
                {
                    lowestDistance = (int)distance;
                    closestCity = info.GameName;
                    closestCountry = info.Country;
                }
            }
            currentCity = FirstCharToUpper(closestCity);
            currentCountry = FirstCharToUpper(closestCountry);
            Thread.Sleep(5000);
        }
    }
}
