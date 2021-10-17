using System;
using System.Collections.Generic;

namespace ErtsApplication.DTO {
    public class LolGameShortStatsDto {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public string GameLength { get; set; }
        public long WinnerTeamId { get; set; }
        public long BlueTeamid { get; set; }
        public virtual LolGameTeamShortStatsDto BlueTeamStats { get; set; }
        public virtual LolGameTeamShortStatsDto RedTeamStats { get; set; }
        public virtual ICollection<LolGamePlayerShortStatsDto> BlueTeamPlayersStats { get; set; }
        public virtual ICollection<LolGamePlayerShortStatsDto> RedTeamPlayersStats { get; set; }
    }
}
