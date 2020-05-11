using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArduinoSCSTelemetry
{
    public class RadioChecker
    {
        public string RadioStation { get; set; }
        public string RadioSignalText { get; set; }
        public string RadioSignal { get; set; }

        public void RadioCheck(Object obj)
        {
            string url = "http://127.0.0.1:8330/api/radio/";
            HttpClient client = new HttpClient();
            try
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        var result = content.ReadAsStringAsync().Result;
                        JObject Radio = JObject.Parse(result);
                        RadioStation = (string)Radio["Radio"];
                        RadioSignal = (string)Radio["Signal"];
                    }
                }
                if (RadioSignal == "5")
                {
                    RadioSignalText = "Excellent (5)";
                }
                else if (RadioSignal == "4")
                {
                    RadioSignal = "Very Good (4)";
                }
                else if (RadioSignal == "3")
                {
                    RadioSignalText = "Good (3)";
                }
                else if (RadioSignal == "2")
                {
                    RadioSignalText = "Poor (2)";
                }
                else if (RadioSignal == "1")
                {
                    RadioSignalText = "Very Poor (1)";
                }
                else
                {
                    RadioSignalText = "No Connection (0)";
                }
            }
            catch
            {
                RadioStation = "Conn. Failed";
                RadioSignalText = "Conn. Failed (X)";
                RadioSignal = "X";
            }
        }
    }
}
