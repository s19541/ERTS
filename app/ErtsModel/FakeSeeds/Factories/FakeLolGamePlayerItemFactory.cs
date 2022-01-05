using ErtsModel.Entities.Lol;

namespace ErtsModel.FakeSeeds.Factories {
    static class FakeGamePlayerItemFactory {
        public static LolGamePlayerItem Create(LolGamePlayer gamePlayer, LolItem item) {

            return new LolGamePlayerItem {

                GamePlayer = gamePlayer,
                Item = item
            };
        }
    }
}
