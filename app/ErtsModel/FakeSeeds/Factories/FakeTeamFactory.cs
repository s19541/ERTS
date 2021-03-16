using ErtsModel.Entities;
using ErtsModel.Enums;
using System.Linq;

namespace ErtsModel.FakeSeeds.Factories
{
    public static class FakeTeamFactory
    {
        public static Team Create() => new Team
        {
            GameType = GameType.Lol,
            Name = Faker.Company.Name(),
            Players = Enumerable.Range(0, Faker.RandomNumber.Next(4, 8)).Select(i => FakePlayerFactory.Create()).ToArray()
        };
    }
}
