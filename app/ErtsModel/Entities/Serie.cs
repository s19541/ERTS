using System;

namespace ErtsModel.Entities {
    public class Serie : ModelBase {
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public virtual League League { get; set; }
        public int ApiId { get; set; }

        public void Update(string name, DateTime? startTime, DateTime? endTime, League league) {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            League = league;
        }
    }
}
