using ErtsModel.Entities;
using System;

namespace ErtsModel.FakeSeeds.Factories {
    class FakeSerieFactory {
        public static Serie Create(League league) {
            var startTime = DateTime.Now - TimeSpan.FromDays(Faker.RandomNumber.Next(1, 50));
            var endTime = startTime + TimeSpan.FromMinutes(Faker.RandomNumber.Next(15, 80));

            return new Serie {
                Name = Faker.Company.Name(),
                StartTime = startTime,
                EndTime = endTime,
                League = league
            };
        }
    }
}

