using System;

namespace ErtsApplication.DTO
{
    public class TournamentShortDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
