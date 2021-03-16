using ErtsModel.Entities.Lol;
using System;

namespace ErtsModel.FakeSeeds.Factories
{
    static class FakeLolGameStatsFactory
    {
        public static LolGameStats Create()
        {
            var startTime = DateTime.Now - TimeSpan.FromDays(Faker.RandomNumber.Next(1, 50));
            var endTime = startTime + TimeSpan.FromMinutes(Faker.RandomNumber.Next(15, 80));

            return new LolGameStats
            {
                StartTime = startTime,
                EndTime = endTime,
                BlueTeam = FakeTeamFactory.Create(),
                RedTeam = FakeTeamFactory.Create()
            };
        }
    }
}
