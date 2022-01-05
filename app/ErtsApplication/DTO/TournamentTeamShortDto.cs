namespace ErtsApplication.DTO {
    public class TournamentTeamShortDto {
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public string TeamName { get; set; }
        public string TeamImageUrl { get; set; }
        public long TeamId { get; set; }
    }
}
