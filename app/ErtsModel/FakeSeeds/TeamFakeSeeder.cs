using ErtsModel.Entities;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds {
    class TeamFakeSeeder : FakeSeederBase<Team> {
        public TeamFakeSeeder(DbSet<Team> dbSet) : base(dbSet) { }

        protected override IEnumerable<Team> Seed() {
            for (int i = 0; i < 100; i++) {
                var team = FakeTeamFactory.Create();
                dbSet.Add(team);
                yield return team;
            }
        }
    }
}