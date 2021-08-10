using System;
using System.Collections.Generic;

namespace ErtsApplication.DTO
{
    public class LolGameStatsDto
    {
        public virtual LolGameTeamStatsDto BlueTeamStats { get; set; }
        public virtual LolGameTeamStatsDto RedTeamStats { get; set; }
        public DateTime StartTime { get; set; }
        public double GameLength { get; set; }
        public long WinnerTeamId { get; set; }
        public virtual ICollection<LolGamePlayerShortStatsDto> PlayersStats { get; set; }
    }
}
