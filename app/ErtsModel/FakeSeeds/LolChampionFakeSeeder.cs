using ErtsModel.Entities.Lol;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds {
    class LolChampionFakeSeeder : FakeSeederBase<LolChampion> {
        public LolChampionFakeSeeder(DbSet<LolChampion> dbSet) : base(dbSet) { }

        protected override IEnumerable<LolChampion> Seed() {
            for (int i = 0; i < 160; i++) {
                var lolChampion = FakeLolChampionFactory.Create();
                dbSet.Add(lolChampion);
                yield return lolChampion;
            }
        }
    }
}
