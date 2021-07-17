using System;
using System.Collections.Generic;

namespace ErtsModel.Entities
{
    public class Series : ModelBase
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Team BlueTeam { get; set; }
        public virtual Team RedTeam { get; set; }
        public virtual Tournament Tournament { get; set; }
        public string StreamUrl { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
