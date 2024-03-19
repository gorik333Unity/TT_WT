using System;

namespace Server.Data
{
    public class GameData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int ActivePlayers { get; set; }
        public int TotalPlayers { get; set; }
        public int Rating { get; set; }
        public int TotalRates { get; set; }
        public string Version { get; set; }
        public int BuildNumber { get; set; }
        public bool IsVertical { get; set; }
        public int GameConfigId { get; set; }
        public string GameState { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class GameDataContainer
    {
        public GameData[] Games;
    }
}