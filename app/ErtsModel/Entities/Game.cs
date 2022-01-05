using System;

namespace ErtsModel.Entities {
    public class Game : ModelBase {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Team Winner { get; set; }
        public int ApiId { get; set; }
    }
}
