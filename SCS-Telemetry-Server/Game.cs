namespace SCSTelemetryServer
{
    /// <summary>
    /// Holds game values
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Internal class to set Time/Day/WeekDay
        /// </summary>
        public GameValues Values { get; set; }

        /// <summary>
        /// To be accessed by other files
        /// </summary>
        public Game()
        {
            Values = new GameValues();
        }
        /// <summary>
        /// All game values
        /// </summary>
        public class GameValues
        {
            public string Time { get; set; }
            public int Day { get; set; }
            public string WeekDay { get; set; }
        }
    }
}