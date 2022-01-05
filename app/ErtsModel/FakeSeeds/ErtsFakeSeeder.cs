namespace ErtsModel.FakeSeeds {
    public class ErtsFakeSeeder {

        public void SeedFakeData(ErtsContext context) {
            var teams = new TeamFakeSeeder(context.Teams).SeedIfNotSeeded();
            var lolChampions = new LolChampionFakeSeeder(context.LolChampions).SeedIfNotSeeded();
            var lolItems = new LolItemFakeSeeder(context.LolItems).SeedIfNotSeeded();
            var lolSpells = new LolSpellFakeSeeder(context.LolSpells).SeedIfNotSeeded();
            var leagues = new LeagueFakeSeeder(context.Leagues).SeedIfNotSeeded();
            var series = new SerieFakeSeeder(context.Series, leagues).SeedIfNotSeeded();
            var tournaments = new TournamentFakeSeeder(series, teams, lolChampions, lolSpells, lolItems, context.Tournaments, context.LolTournamentTeams, context.LolTournamentPlayers, context.Matches, context.LolGamePlayers, context.LolGameTeams, context.LolGamePlayerItems).SeedIfNotSeeded();
        }
    }
}
