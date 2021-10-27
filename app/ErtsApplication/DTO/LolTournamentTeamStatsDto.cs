namespace ErtsApplication.DTO {
    public class LolTournamentTeamStatsDto {
        public long TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamImageUrl { get; set; }
        public double? Kills { get; set; }
        public double? Assists { get; set; }
        public double? Deaths { get; set; }
        public double? Gold { get; set; }
        public double? Dragons { get; set; }
        public double? Heralds { get; set; }
        public double? Barons { get; set; }
        public double? Towers { get; set; }
        public string FirstRecentChampionImageUrl { get; set; }
        public string SecondRecentChampionImageUrl { get; set; }
        public string ThirdRecentChampionImageUrl { get; set; }
        public string FourthRecentChampionImageUrl { get; set; }
        public string FivethRecentChampionImageUrl { get; set; }
    }
}
