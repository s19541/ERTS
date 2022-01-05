using ErtsModel.Entities;

namespace ErtsModel.FakeSeeds.Factories {
    static class FakePlayerFactory {
        public static Player Create() => new Player {
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            Nick = Faker.Name.Middle(),
            Nationality = Faker.Country.Name()
        };
    }
}
