using System;

namespace ErtsApplication.DTO
{
    public class SeriesShortDto
    {

        public int Id { get; set; }
        public string BlueTeamImageUrl { get; set; }
        public string RedTeamImageUrl { get; set; }
        public string BlueTeamAcronym { get; set; }
        public string RedTeamAcronym { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BlueTeamGamesWon { get; set; }
        public int RedTeamGamesWon { get; set; }
    }
}
