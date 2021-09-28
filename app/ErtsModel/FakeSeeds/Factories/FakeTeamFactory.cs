using ErtsModel.Entities;
using ErtsModel.Enums;
using System.Linq;

namespace ErtsModel.FakeSeeds.Factories {
    public static class FakeTeamFactory {

        public static Team Create() => new Team {
            GameType = GameType.lol,
            Name = Faker.Company.Name(),
            Acronym = Faker.Generators.Strings.GenerateAlphaNumericString(2, 4),
            ImageUrl = "https://cdn.dev.pandascore.co/images/team/image/389/download.png",
            Players = Enumerable.Range(0, 5).Select(i => FakePlayerFactory.Create()).ToArray()
        };
    }
}
