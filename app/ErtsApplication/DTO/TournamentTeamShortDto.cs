namespace ErtsApplication.DTO
{
    public class TournamentTeamShortDto
    {
        public int SeriesWon { get; set; }
        public int SeriesLost { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public string TeamName { get; set; }
        public string TeamImageUrl { get; set; }
    }
}
