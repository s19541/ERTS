using System;
using System.Collections.Generic;

namespace ErtsModel.Entities {
    public class Match : ModelBase {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
        public virtual Tournament Tournament { get; set; }
        public string StreamUrl { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public int NumberOfGames { get; set; }
        public int ApiId { get; set; }

        public void Update(DateTime? startTime, DateTime? endTime, Team team1, Team team2, Tournament tournament, string streamUrl, ICollection<Game> games, int numberOfGames) {
            StartTime = startTime;
            EndTime = endTime;
            Team1 = team1;
            Team2 = team2;
            Tournament = tournament;
            StreamUrl = streamUrl;
            Games = games;
            NumberOfGames = numberOfGames;
        }
    }
}
