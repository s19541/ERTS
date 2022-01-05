namespace ErtsModel.Entities {
    public class TournamentTeam : ModelBase {
        public virtual Team Team { get; set; }
        public virtual Tournament Tournament { get; set; }
        public int GamesLost { get; set; }
        public int GamesWon { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
    }
}
