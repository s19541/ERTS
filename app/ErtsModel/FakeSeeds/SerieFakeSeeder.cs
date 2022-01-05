using ErtsModel.Entities;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds {
    class SerieFakeSeeder : FakeSeederBase<Serie> {
        private readonly List<League> leagues;
        private readonly Random random;
        public SerieFakeSeeder(DbSet<Serie> dbSet, List<League> leagues) : base(dbSet) {
            this.leagues = leagues;
            random = new Random();
        }

        protected override IEnumerable<Serie> Seed() {
            for (int i = 0; i < 100; i++) {
                var serie = FakeSerieFactory.Create(leagues[random.Next(1, leagues.Count)]);
                dbSet.Add(serie);
                yield return serie;
            }
        }
    }
}