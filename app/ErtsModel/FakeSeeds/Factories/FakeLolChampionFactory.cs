using ErtsModel.Entities.Lol;

namespace ErtsModel.FakeSeeds.Factories {
    static class FakeLolChampionFactory {
        public static LolChampion Create() => new LolChampion {
            Name = Faker.Name.First(),
            ImageUrl = "https://cdn.dev.pandascore.co/images/lol/champion/image/5b5006046d300b532887aa8c26e1df0c.png"
        };
    }
}
