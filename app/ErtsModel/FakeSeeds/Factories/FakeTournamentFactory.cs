using ErtsModel.Entities;
using System;

namespace ErtsModel.FakeSeeds.Factories {
    static class FakeTournamentFactory {
        public static Tournament Create(Serie serie) {
            var startTime = DateTime.Now - TimeSpan.FromDays(Faker.RandomNumber.Next(1, 50));
            var endTime = startTime + TimeSpan.FromMinutes(Faker.RandomNumber.Next(15, 80));

            return new Tournament {
                Name = Faker.Company.Name(),
                StartTime = startTime,
                EndTime = endTime,
                Serie = serie
            };
        }
    }
}