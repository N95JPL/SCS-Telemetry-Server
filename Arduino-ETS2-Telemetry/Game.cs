using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoSCSTelemetry
{
    public class Game
    {

        public GameValues Values { get; set; }

        public Game()
        {
            Values = new GameValues();
        }

        public class GameValues
        {
            public string Time { get; set; }
            public int Day { get; set; }
            public string WeekDay { get; set; }
        }
    }
}
