using ErtsModel.Enums;
using System.Collections.Generic;

namespace ErtsApplication.DTO {
    public class LolGamePlayerShortStatsDto {
        public long TeamId { get; set; }
        public string PlayerNick { get; set; }
        public LolRole Role { get; set; }
        public string ChampionImageUrl { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int GoldEarned { get; set; }
        public int Cs { get; set; }
        public string Spell1ImageUrl { get; set; }
        public string Spell2ImageUrl { get; set; }
        public ICollection<string> ItemImages { get; set; }

    }
}
