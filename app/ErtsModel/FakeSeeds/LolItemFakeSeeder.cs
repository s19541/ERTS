using ErtsModel.Entities.Lol;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds {
    class LolItemFakeSeeder : FakeSeederBase<LolItem> {
        public LolItemFakeSeeder(DbSet<LolItem> dbSet) : base(dbSet) { }

        protected override IEnumerable<LolItem> Seed() {
            for (int i = 0; i < 60; i++) {
                var lolItem = FakeLolItemFactory.Create();
                dbSet.Add(lolItem);
                yield return lolItem;
            }
        }
    }
}
