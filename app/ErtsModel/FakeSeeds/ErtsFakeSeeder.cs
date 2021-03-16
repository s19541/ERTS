using ErtsModel;

namespace ErtsModel.FakeSeeds
{
    public class ErtsFakeSeeder
    {

        public void SeedFakeData(ErtsContext context)
        {
            new TeamFakeSeeder(context.Teams).SeedIfNotSeeded();
            new LolGameStatsFakeSeeder(context.LolGamesStats).SeedIfNotSeeded();
        }
    }
}
