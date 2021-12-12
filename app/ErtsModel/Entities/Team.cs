using ErtsModel.Enums;
using System.Collections.Generic;

namespace ErtsModel.Entities {
    public class Team : ModelBase {
        public string Name { get; set; }
        public GameType GameType { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public string ImageUrl { get; set; }
        public string Acronym { get; set; }
        public int ApiId { get; set; }

        public void Update(string acronym, GameType gameType, string imageUrl, string name, ICollection<Player> players) {
            Acronym = acronym;
            GameType = gameType;
            ImageUrl = imageUrl;
            Name = name;
            Players = players;
        }
    }
}
