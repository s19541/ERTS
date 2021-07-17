using ErtsModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsModel.FakeSeeds.Factories
{
    static class FakeSeriesFactory
    {
        public static Series Create(Team team1, Team team2, Tournament tournament)
        {
            var startTime = DateTime.Now - TimeSpan.FromDays(Faker.RandomNumber.Next(1, 50));
            var endTime = startTime + TimeSpan.FromMinutes(Faker.RandomNumber.Next(15, 80));
            var teams = new List<Team> { team1, team2 };
            var random = new Random();
            return new Series
            {
                StartTime = startTime,
                EndTime = endTime,
                BlueTeam = team1,
                RedTeam = team2,
                Tournament = tournament,
                StreamUrl = "https://www.twitch.tv/",
                Games = Enumerable.Range(0, Faker.RandomNumber.Next(1, 5)).Select(i => FakeGameFactory.Create(teams[random.Next(teams.Count)])).ToArray()
            };
        }
    }
}
