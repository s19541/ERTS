using ErtsModel.Entities;

namespace ErtsModel.FakeSeeds.Factories
{
    static class FakePlayerFactory
    {
        public static Player Create() => new Player
        {
            Name = Faker.Name.First(),
            Surname = Faker.Name.Last(),
            Nick = Faker.Name.Middle(),
            Nationality = Faker.Country.Name()
        };
    }
}
