namespace ErtsModel.Entities
{
    public class TournamentTeam : ModelBase
    {
        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesLost { get; set; }
        public int GamesWon { get; set; }
        public int SeriesPlayed { get; set; }
        public int SeriesWon { get; set; }
        public int SeriesLost { get; set; }
    }
}
