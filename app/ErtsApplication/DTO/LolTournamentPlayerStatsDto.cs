namespace ErtsApplication.DTO {
    public class LolTournamentPlayerStatsDto {
        public string PlayerNick { get; set; }
        public long TeamId { get; set; }
        public string TeamImageUrl { get; set; }
        public double? Kills { get; set; }
        public double? Deaths { get; set; }
        public double? Assists { get; set; }
        public string? Kda { get; set; }
        public double? Cs { get; set; }
        public double? CsPerMinute { get; set; }
        public double? Gold { get; set; }
        public double? GoldPerMinute { get; set; }
        public string DamageShare { get; set; }
        public string KillParticipation { get; set; }
        public int ChampionsPlayed { get; set; }
        public string FirstRecentChampionImageUrl { get; set; }
        public string SecondRecentChampionImageUrl { get; set; }
        public string ThirdRecentChampionImageUrl { get; set; }
    }
}
