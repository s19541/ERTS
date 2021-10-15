using System;
using System.Collections.Generic;

namespace ErtsApplication.DTO {
    public class LolGameFullStatsDto {
        public DateTime StartTime { get; set; }
        public string GameLength { get; set; }
        public long WinnerTeamId { get; set; }
        public long BlueTeamid { get; set; }
        public virtual LolGameTeamFullStatsDto BlueTeamStats { get; set; }
        public virtual LolGameTeamFullStatsDto RedTeamStats { get; set; }
        public virtual ICollection<LolGamePlayerFullStatsDto> BlueTeamPlayersStats { get; set; }
        public virtual ICollection<LolGamePlayerFullStatsDto> RedTeamPlayersStats { get; set; }
    }
}
