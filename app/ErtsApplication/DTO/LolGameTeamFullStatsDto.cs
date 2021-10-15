namespace ErtsApplication.DTO {
    public class LolGameTeamFullStatsDto : LolGameTeamShortStatsDto {
        public bool FirstBaron { get; set; }
        public bool FirstDragon { get; set; }
        public bool FirstBlood { get; set; }
        public bool FirstInhibitor { get; set; }
        public bool FirstTurret { get; set; }
    }
}
