using ErtsModel.Entities.Lol;

namespace ErtsModel.Entities
{
    public class LolTournamentTeam : TournamentTeam
    {
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
