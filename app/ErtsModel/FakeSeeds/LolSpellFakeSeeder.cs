using ErtsModel.Entities.Lol;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ErtsModel.FakeSeeds {
    class LolSpellFakeSeeder : FakeSeederBase<LolSpell> {
        public LolSpellFakeSeeder(DbSet<LolSpell> dbSet) : base(dbSet) { }

        protected override IEnumerable<LolSpell> Seed() {
            for (int i = 0; i < 11; i++) {
                var lolSpell = FakeLolSpellFactory.Create();
                dbSet.Add(lolSpell);
                yield return lolSpell;
            }
        }
    }
}
