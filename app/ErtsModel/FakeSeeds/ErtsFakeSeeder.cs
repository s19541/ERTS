﻿namespace ErtsModel.FakeSeeds
{
    public class ErtsFakeSeeder
    {

        public void SeedFakeData(ErtsContext context)
        {
            var teams = new TeamFakeSeeder(context.Teams).SeedIfNotSeeded();
            var lolChampions = new LolChampionFakeSeeder(context.LolChampions).SeedIfNotSeeded();
            var lolItems = new LolItemFakeSeeder(context.LolItems).SeedIfNotSeeded();
            var lolSpells = new LolSpellFakeSeeder(context.LolSpells).SeedIfNotSeeded();
            var leagues = new LeagueFakeSeeder(context.Leagues).SeedIfNotSeeded();
            var tournaments = new TournamentFakeSeeder(leagues, teams, lolChampions, lolSpells, lolItems,  context.Tournaments, context.TournamentTeams, context.Series, context.LolGamePlayers, context.LolGameTeam, context.LolGamePlayerItems).SeedIfNotSeeded();
            //var series = new SeriesFakeSeeder(teams, tournaments, context.Series).SeedIfNotSeeded();
            //var lolGamePlayers = new LolGamePlayerFakeSeeder(context.LolGamePlayers).SeedIfNotSeeded();
        }
    }
}
