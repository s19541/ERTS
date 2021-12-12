using System;

namespace ErtsModel.Entities {
    public class Tournament : ModelBase {
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public virtual Serie Serie { get; set; }
        public int ApiId { get; set; }

        public void Update(string name, DateTime? startTime, DateTime? endTime, Serie serie) {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Serie = serie;
        }
    }
}
