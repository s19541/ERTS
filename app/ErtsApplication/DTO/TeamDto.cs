using System.Collections.Generic;

namespace ErtsApplication.DTO {
    public class TeamDto {
        public string Name { get; set; }
        public ErtsModel.Enums.GameType GameType { get; set; }
        public string ImageUrl { get; set; }
        public string Acronym { get; set; }
        public virtual ICollection<ErtsModel.Entities.Player> Players { get; set; }
        public virtual ICollection<TeamPastMatchDto> LastMatches { get; set; }
        public virtual ICollection<TeamUpcomingMatchDto> UpcomingMatches { get; set; }
    }
}
