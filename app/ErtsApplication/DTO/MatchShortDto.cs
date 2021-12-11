using System;

namespace ErtsApplication.DTO {
    public class MatchShortDto {
        public long Id { get; set; }
        public string Team1ImageUrl { get; set; }
        public string Team2ImageUrl { get; set; }
        public string Team1Acronym { get; set; }
        public string Team2Acronym { get; set; }
        public int Team1GamesWon { get; set; }
        public int Team2GamesWon { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int NumberOfGames { get; set; }
    }
}
