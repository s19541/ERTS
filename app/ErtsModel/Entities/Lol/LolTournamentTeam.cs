using ErtsModel.Entities.Lol;

namespace ErtsModel.Entities
{
    public class LolTournamentTeam : ModelBase
    {
        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
        public int GamesLost { get; set; }
        public int GamesWon { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public double AverageKills { get; set; }
        public double AverageDeaths { get; set; }
        public double AverageAssists { get; set; }
        public double AverageGoldEarned { get; set; }
        public double AverageDragonKilled { get; set; }
        public double AverageHeraldKilled { get; set; }
        public double AverageBaronKilled { get; set; }
        public double AverageTowerDestroyed { get; set; }
        public virtual LolChampion FavouriteChampion1 { get; set; }
        public virtual LolChampion FavouriteChampion2 { get; set; }
        public virtual LolChampion FavouriteChampion3 { get; set; }
        public virtual LolChampion FavouriteChampion4 { get; set; }
        public virtual LolChampion FavouriteChampion5 { get; set; }
    }
}
