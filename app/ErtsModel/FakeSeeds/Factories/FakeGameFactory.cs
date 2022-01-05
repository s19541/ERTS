using ErtsModel.Entities;
using System;

namespace ErtsModel.FakeSeeds.Factories {
    static class FakeGameFactory {
        public static Game Create(Team winner) {
            var startTime = DateTime.Now - TimeSpan.FromDays(Faker.RandomNumber.Next(1, 50));
            var endTime = startTime + TimeSpan.FromMinutes(Faker.RandomNumber.Next(15, 80));

            return new Game {
                StartTime = startTime,
                EndTime = endTime,
                Winner = winner
            };
        }
    }
}