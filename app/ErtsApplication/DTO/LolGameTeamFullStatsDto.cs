namespace ErtsApplication.DTO {
    public class LolGameTeamFullStatsDto : LolGameTeamShortStatsDto {
        public string TeamName { get; set; }
        public string TeamImageUrl { get; set; }
        public bool FirstBaron { get; set; }
        public bool FirstDragon { get; set; }
        public bool FirstBlood { get; set; }
        public bool FirstInhibitor { get; set; }
        public bool FirstTurret { get; set; }
    }
}
