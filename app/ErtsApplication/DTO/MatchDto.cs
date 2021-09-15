using System;
using System.Collections.Generic;

namespace ErtsApplication.DTO
{
    public class MatchDto
    {

        public int Id { get; set; }
        public long Team1Id { get; set; }
        public long Team2Id { get; set; }
        public string Team1ImageUrl { get; set; }
        public string Team2ImageUrl { get; set; }
        public string Team1Acronym { get; set; }
        public string Team2Acronym { get; set; }
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Team1GamesWon { get; set; }
        public int Team2GamesWon { get; set; }
        public string StreamUrl { get; set; }
        public virtual ICollection<LolGameShortStatsDto> Games { get; set; }
    }
}
