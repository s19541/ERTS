using ErtsModel.Entities;
using ErtsModel.FakeSeeds.Factories;
using Microsoft.EntityFrameworkCore;

namespace ErtsModel.FakeSeeds
{
    class TeamFakeSeeder : FakeSeederBase<Team>
    {
        public TeamFakeSeeder(DbSet<Team> dbSet) : base(dbSet) { }

        protected override void Seed()
        {
            for (int i = 0; i < 10; i++)
            {
                dbSet.Add(FakeTeamFactory.Create());
            }
        }
    }
}