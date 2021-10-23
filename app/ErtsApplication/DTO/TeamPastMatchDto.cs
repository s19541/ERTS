using System;

namespace ErtsApplication.DTO {
    public class TeamPastMatchDto {
        public long MatchId { get; set; }
        public string Team1ImageUrl { get; set; }
        public string Team2ImageUrl { get; set; }
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public int Team1GamesWon { get; set; }
        public int Team2GamesWon { get; set; }
        public DateTime? StartTime { get; set; }
        public string LeagueImageUrl { get; set; }
    }
}
