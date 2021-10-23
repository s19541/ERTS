using System;

namespace ErtsApplication.DTO {
    public class TeamUpcomingMatchDto {
        public long MatchId { get; set; }
        public string Team1ImageUrl { get; set; }
        public string Team2ImageUrl { get; set; }
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public DateTime? StartTime { get; set; }
        public string LeagueImageUrl { get; set; }
    }
}
