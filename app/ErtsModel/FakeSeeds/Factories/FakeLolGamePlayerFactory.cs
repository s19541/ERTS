using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using ErtsModel.Enums;
using System;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds.Factories {
    static class FakeLolGamePlayerFactory {
        public static LolGamePlayer Create(Player player, Game game, LolRole role, List<LolChampion> champions, List<LolSpell> spells) {
            var startTime = DateTime.Now - TimeSpan.FromDays(Faker.RandomNumber.Next(1, 50));
            var endTime = startTime + TimeSpan.FromMinutes(Faker.RandomNumber.Next(15, 80));
            var random = new Random();
            var killsNumber = Faker.RandomNumber.Next(0, 30);

            return new LolGamePlayer {
                Player = player,
                Game = game,
                Role = role,
                Champion = champions[random.Next(1, champions.Count)],
                Kills = killsNumber,
                Deaths = Faker.RandomNumber.Next(0, 30),
                Assists = Faker.RandomNumber.Next(0, 100),
                GoldEarned = Faker.RandomNumber.Next(0, 40000),
                GoldSpent = Faker.RandomNumber.Next(0, 30000),
                LargestCriticalStrike = Faker.RandomNumber.Next(0, 5000),
                LargestKillingSpree = Faker.RandomNumber.Next(0, killsNumber),
                LargestMultiKill = Faker.RandomNumber.Next(0, 5),
                Level = Faker.RandomNumber.Next(1, 18),
                MagicDamageDealt = Faker.RandomNumber.Next(0, 100000),
                MagicDamageDealtToChamps = Faker.RandomNumber.Next(0, 50000),
                PhysicalDamageDealt = Faker.RandomNumber.Next(0, 100000),
                PhysicalDamageDealtToChamps = Faker.RandomNumber.Next(0, 100000),
                TrueDamageDealt = Faker.RandomNumber.Next(0, 20000),
                TrueDamageDealtToChamps = Faker.RandomNumber.Next(0, 10000),
                DamageDealt = Faker.RandomNumber.Next(0, 200000),
                DamageDealtToChamps = Faker.RandomNumber.Next(0, 200000),
                DamageTaken = Faker.RandomNumber.Next(0, 200000),
                TotalHeal = Faker.RandomNumber.Next(0, 50000),
                TotalTimeCrowdControlDealt = Faker.RandomNumber.Next(0, 500),
                WardsPlaced = Faker.RandomNumber.Next(0, 100),
                WardsDestroyed = Faker.RandomNumber.Next(0, 100),
                TurretsDestroyed = Faker.RandomNumber.Next(0, 11),
                InhibitorsDestroyed = Faker.RandomNumber.Next(0, 10),
                MinionsKilled = Faker.RandomNumber.Next(0, 600),
                NeutralMinionsKilled = Faker.RandomNumber.Next(0, 300),
                EnemyNeutralMinionsKilled = Faker.RandomNumber.Next(0, 200),
                FirstBlood = Faker.Boolean.Random(),
                FirstBloodAssist = Faker.Boolean.Random(),
                Spell1 = spells[random.Next(1, spells.Count)],
                Spell2 = spells[random.Next(1, spells.Count)]
            };
        }
    }
}
