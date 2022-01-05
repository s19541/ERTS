using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using System;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds.Factories {
    static class FakeLolTournamentTeamFactory {
        public static LolTournamentTeam Create(Team team, Tournament tournament, List<LolChampion> champions) {
            var random = new Random();

            return new LolTournamentTeam {
                Team = team,
                Tournament = tournament,
                MatchesWon = 0,
                MatchesLost = 0,
                GamesWon = 0,
                GamesLost = 0,
                AverageKills = Faker.RandomNumber.Next(0, 1000) / 10.0,
                AverageDeaths = Faker.RandomNumber.Next(0, 1000) / 10.0,
                AverageAssists = Faker.RandomNumber.Next(0, 5000) / 10.0,
                AverageBaronKilled = Faker.RandomNumber.Next(0, 3) / 10.0,
                AverageDragonKilled = Faker.RandomNumber.Next(0, 6) / 10.0,
                AverageHeraldKilled = Faker.RandomNumber.Next(0, 2) / 10.0,
                AverageGoldEarned = Faker.RandomNumber.Next(0, 100000),
                AverageTowerDestroyed = Faker.RandomNumber.Next(0, 11),
                FavouriteChampion1 = champions[random.Next(1, champions.Count)],
                FavouriteChampion2 = champions[random.Next(1, champions.Count)],
                FavouriteChampion3 = champions[random.Next(1, champions.Count)],
                FavouriteChampion4 = champions[random.Next(1, champions.Count)],
                FavouriteChampion5 = champions[random.Next(1, champions.Count)]
            };
        }
    }
}