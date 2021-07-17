using System;

namespace ErtsModel.Entities
{
    public class Tournament : ModelBase
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual League League { get; set; }
        public double PrizePool { get; set; }
    }
}
