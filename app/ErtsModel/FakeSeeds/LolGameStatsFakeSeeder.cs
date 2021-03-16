using ErtsModel.Entities.Lol;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErtsModel.FakeSeeds
{
    class LolGameStatsFakeSeeder : FakeSeederBase<LolGameStats>
    {
        public LolGameStatsFakeSeeder(DbSet<LolGameStats> dbSet) : base(dbSet) { }
        protected override void Seed()
        {
            for (int i = 0; i < 10; i++)
            {
                dbSet.Add(FakeLolGameStatsFactory.Create());
            }
        }
    }
}
