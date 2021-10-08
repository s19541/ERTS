namespace ErtsModel.Entities.Lol {
    public class LolTournamentPlayer : ModelBase {
        public virtual Player Player { get; set; }
        public virtual Tournament Tournament { get; set; }
        public double? AverageAssists { get; set; }
        public double? AverageDeaths { get; set; }
        public double? AverageKills { get; set; }
        public double? AverageMinionsKilled { get; set; }
        public double? AverageGoldEarned { get; set; }
        public double? MinionsPerMinute { get; set; }
        public double? GoldPerMinute { get; set; }
        public double? DamageShare { get; set; }
        public double? KillParticipation { get; set; }
        public int ChampionsPlayed { get; set; }
        public virtual LolChampion FavouriteChampion1 { get; set; }
        public virtual LolChampion FavouriteChampion2 { get; set; }
        public virtual LolChampion FavouriteChampion3 { get; set; }
    }
}
