using ErtsModel.Enums;

namespace ErtsModel.Entities {
    public class League : ModelBase {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public GameType GameType { get; set; }
        public string Url { get; set; }
        public int ApiId { get; set; }

        public void Update(string name, string imageUrl, GameType gameType, string url) {
            Name = name;
            ImageUrl = imageUrl;
            GameType = gameType;
            Url = url;
        }
    }
}
