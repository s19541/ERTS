using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using ErtsModel.Enums;
using System;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds.Factories {
    static class FakeLolGameTeamFactory {
        public static LolGameTeam Create(Team team, Game game, LolColor color, List<LolChampion> champions) {
            var random = new Random();

            return new LolGameTeam {
                Team = team,
                Game = game,
                BaronKilled = Faker.RandomNumber.Next(0, 5),
                MountainDrakeKilled = Faker.RandomNumber.Next(0, 1),
                CloudDrakeKilled = Faker.RandomNumber.Next(0, 1),
                InfernalDrakeKilled = Faker.RandomNumber.Next(0, 1),
                OceanDrakeKilled = Faker.RandomNumber.Next(0, 1),
                ElderDrakeKilled = Faker.RandomNumber.Next(0, 4),
                HeraldKilled = Faker.RandomNumber.Next(0, 2),
                GoldEarned = Faker.RandomNumber.Next(0, 100000),
                Kills = Faker.RandomNumber.Next(0, 100),
                TurretDestroyed = Faker.RandomNumber.Next(0, 11),
                InhibitorDestroyed = Faker.RandomNumber.Next(0, 10),
                Color = color,
                Ban1 = champions[random.Next(1, champions.Count)],
                Ban2 = champions[random.Next(1, champions.Count)],
                Ban3 = champions[random.Next(1, champions.Count)],
                Ban4 = champions[random.Next(1, champions.Count)],
                Ban5 = champions[random.Next(1, champions.Count)],
                FirstBaron = Faker.Boolean.Random(),
                FirstBlood = Faker.Boolean.Random(),
                FirstDragon = Faker.Boolean.Random(),
                FirstTurret = Faker.Boolean.Random(),
                FirstInhibitor = Faker.Boolean.Random()

            };
        }
    }
}