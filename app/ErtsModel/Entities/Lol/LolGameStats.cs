using System;

namespace ErtsModel.Entities.Lol
{
    public class LolGameStats : ModelBase
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Team BlueTeam { get; set; }
        public virtual Team RedTeam { get; set; }
    }
}
