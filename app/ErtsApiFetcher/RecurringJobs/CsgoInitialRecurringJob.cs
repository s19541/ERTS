using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(CsgoInitialRecurringJob), nameof(CsgoInitialRecurringJob), ErtsCron.OncePerWeek)]
    public class CsgoInitialRecurringJob : IRecurringJob {
        private readonly ErtsContext context;
        private readonly CsgoDataFetcher csgoDataFetcher;
        public CsgoInitialRecurringJob(ErtsContext context) {
            this.context = context;
            this.csgoDataFetcher = new CsgoDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();

            FetchAndSaveLeagues();
            FetchAndSaveSeries();
            FetchAndSaveTournaments();
            FetchAndSavePlayers();
            FetchAndSaveTeams();
            FetchAndSaveMatches();

            context.Database.CommitTransaction();
        }

        private void FetchAndSaveMatches() {
            var apiMatches = csgoDataFetcher.FetchMatches();
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId));
            context.Matches.AddRange(newMatches);

            context.SaveChanges();
        }

        private void FetchAndSaveTeams() {
            var apiTeams = csgoDataFetcher.FetchTeams();
            var newTeams = apiTeams.Where(apiTeam => !context.Players.Any(contextTeam => contextTeam.ApiId == apiTeam.ApiId));
            context.Teams.AddRange(newTeams);

            context.SaveChanges();
        }

        private void FetchAndSavePlayers() {
            var apiPlayers = csgoDataFetcher.FetchPlayers();
            var newPlayers = apiPlayers.Where(apiPlayer => !context.Players.Any(contextPlayer => contextPlayer.ApiId == apiPlayer.ApiId));
            context.Players.AddRange(newPlayers);

            context.SaveChanges();
        }

        private void FetchAndSaveTournaments() {
            var apiTournaments = csgoDataFetcher.FetchTournaments();
            var newTournaments = apiTournaments.Where(apiTournament => !context.Tournaments.Any(contextTournament => contextTournament.ApiId == apiTournament.ApiId));
            context.Tournaments.AddRange(newTournaments);

            context.SaveChanges();
        }

        private void FetchAndSaveSeries() {
            var apiSeries = csgoDataFetcher.FetchSeries();
            var newSeries = apiSeries.Where(apiSerie => !context.Series.Any(contextSerie => contextSerie.ApiId == apiSerie.ApiId));
            context.Series.AddRange(newSeries);

            context.SaveChanges();
        }

        private void FetchAndSaveLeagues() {
            var apiLeagues = csgoDataFetcher.FetchLeagues();
            var newLeagues = apiLeagues.Where(apiLeague => !context.Leagues.Any(contextLeague => contextLeague.ApiId == apiLeague.ApiId));
            context.Leagues.AddRange(newLeagues);

            context.SaveChanges();
        }
    }
}
