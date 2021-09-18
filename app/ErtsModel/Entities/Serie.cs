using System;

namespace ErtsModel.Entities
{
    public class Serie : ModelBase
    {
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public virtual League League { get; set; }
        public int ApiId { get; set; }
    }
}
