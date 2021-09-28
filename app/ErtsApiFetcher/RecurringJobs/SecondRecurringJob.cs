﻿using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(SecondRecurringJob), nameof(SecondRecurringJob), ErtsCron.OncePerWeek)]
    public class SecondRecurringJob : IRecurringJob {
        private readonly ErtsContext context;
        private readonly LolDataFetcher lolDataFetcher;

        public SecondRecurringJob(ErtsContext context) {
            this.context = context;
            this.lolDataFetcher = new LolDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();

            FetchAndSaveChampions();
            FetchAndSaveItems();
            FetchAndSaveSpells();
            FetchAndSaveLeagues();
            FetchAndSaveSeries();
            FetchAndSaveTournaments();
            FetchAndSavePlayers();
            FetchAndSaveTeams();
            FetchAndSaveMatches();

            context.Database.CommitTransaction();
        }

        private void FetchAndSaveMatches() {
            var apiMatches = lolDataFetcher.FetchMatches();
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId));
            context.Matches.AddRange(newMatches);

            context.SaveChanges();
        }

        private void FetchAndSaveTeams() {
            var apiTeams = lolDataFetcher.FetchTeams();
            var newTeams = apiTeams.Where(apiTeam => !context.Players.Any(contextTeam => contextTeam.ApiId == apiTeam.ApiId));
            context.Teams.AddRange(newTeams);

            context.SaveChanges();
        }

        private void FetchAndSavePlayers() {
            var apiPlayers = lolDataFetcher.FetchPlayers();
            var newPlayers = apiPlayers.Where(apiPlayer => !context.Players.Any(contextPlayer => contextPlayer.ApiId == apiPlayer.ApiId));
            context.Players.AddRange(newPlayers);

            context.SaveChanges();
        }

        private void FetchAndSaveTournaments() {
            var apiTournaments = lolDataFetcher.FetchTournaments();
            var newTournaments = apiTournaments.Where(apiTournament => !context.Tournaments.Any(contextTournament => contextTournament.ApiId == apiTournament.ApiId));
            context.Tournaments.AddRange(newTournaments);

            context.SaveChanges();
        }

        private void FetchAndSaveSeries() {
            var apiSeries = lolDataFetcher.FetchSeries();
            var newSeries = apiSeries.Where(apiSerie => !context.Series.Any(contextSerie => contextSerie.ApiId == apiSerie.ApiId));
            context.Series.AddRange(newSeries);

            context.SaveChanges();
        }

        private void FetchAndSaveLeagues() {
            var apiLeagues = lolDataFetcher.FetchLeagues();
            var newLeagues = apiLeagues.Where(apiLeague => !context.Leagues.Any(contextLeague => contextLeague.ApiId == apiLeague.ApiId));
            context.Leagues.AddRange(newLeagues);

            context.SaveChanges();
        }

        private void FetchAndSaveSpells() {
            var apiSpells = lolDataFetcher.FetchSpells();
            var newSpells = apiSpells.Where(apiSpell => !context.LolSpells.Any(contextSpell => contextSpell.Name == apiSpell.Name));
            context.AddRange(newSpells);

            context.SaveChanges();
        }

        private void FetchAndSaveItems() {
            var apiItems = lolDataFetcher.FetchItems();
            var newItems = apiItems.Where(apiItem => !context.LolItems.Any(contextItem => contextItem.Name == apiItem.Name));
            context.AddRange(newItems);

            context.SaveChanges();
        }

        private void FetchAndSaveChampions() {
            var apiChampions = lolDataFetcher.FetchChampions();
            var newChampions = apiChampions.Where(apiChampion => !context.LolChampions.Any(contextChampion => contextChampion.Name == apiChampion.Name));
            context.AddRange(newChampions);

            context.SaveChanges();
        }
    }
}
