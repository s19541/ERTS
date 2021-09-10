namespace ErtsModel.Entities.Lol
{
    public class LolTournamentPlayer : ModelBase
    {
        public virtual Player Player { get; set; }
        public virtual Tournament Tournament { get; set; }
        public double AverageAssists { get; set; }
        public double AverageDeaths { get; set; }
        public double AverageKills { get; set; }
        public double AverageMinionsKilled { get; set; }
        public virtual LolChampion FavouriteChampion1 { get; set; }
        public virtual LolChampion FavouriteChampion2 { get; set; }
        public virtual LolChampion FavouriteChampion3 { get; set; }
    }
}
