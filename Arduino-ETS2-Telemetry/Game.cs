namespace SCSTelemetryServer
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
