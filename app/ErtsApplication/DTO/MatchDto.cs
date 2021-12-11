using System.Collections.Generic;

namespace ErtsApplication.DTO {
    public class MatchDto {

        public long Team1Id { get; set; }
        public long Team2Id { get; set; }
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public string StreamUrl { get; set; }
        public virtual MatchShortDto MatchShortDto { get; set; }
        public virtual ICollection<LolGameShortStatsDto> Games { get; set; }
    }
}
