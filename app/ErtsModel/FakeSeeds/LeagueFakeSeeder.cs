using ErtsModel.Entities;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds {
    class LeagueFakeSeeder : FakeSeederBase<League> {
        public LeagueFakeSeeder(DbSet<League> dbSet) : base(dbSet) { }

        protected override IEnumerable<League> Seed() {
            for (int i = 0; i < 20; i++) {
                var league = FakeLeagueFactory.Create();
                dbSet.Add(league);
                yield return league;
            }
        }
    }
}
