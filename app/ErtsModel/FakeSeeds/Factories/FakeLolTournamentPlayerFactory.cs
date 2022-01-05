using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using System;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds.Factories {
    static class FakeLolTournamentPlayerFactory {
        public static LolTournamentPlayer Create(Player player, Tournament tournament, List<LolChampion> champions) {
            var random = new Random();
            return new LolTournamentPlayer {
                Player = player,
                Tournament = tournament,
                AverageKills = Faker.RandomNumber.Next(0, 1000) / 10.0,
                AverageDeaths = Faker.RandomNumber.Next(0, 1000) / 10.0,
                AverageAssists = Faker.RandomNumber.Next(0, 5000) / 10.0,
                AverageMinionsKilled = Faker.RandomNumber.Next(0, 5000) / 10.0,
                FavouriteChampion1 = champions[random.Next(1, champions.Count)],
                FavouriteChampion2 = champions[random.Next(1, champions.Count)],
                FavouriteChampion3 = champions[random.Next(1, champions.Count)],
            };
        }
    }
}
