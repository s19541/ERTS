using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(CsgoInitialRecurringJob), nameof(CsgoInitialRecurringJob), ErtsCron.Never)]
    public class CsgoInitialRecurringJob : InitialRecurringJobBase, IRecurringJob {
        private readonly CsgoDataFetcher csgoDataFetcher;
        public CsgoInitialRecurringJob(ErtsContext context) {
            this.context = context;
            this.csgoDataFetcher = new CsgoDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();

            FetchAndSaveMatches();
            CreateTournamentTeamStats(ErtsModel.Enums.GameType.csgo);

            context.Database.CommitTransaction();
        }

        private void FetchAndSaveMatches() {
            var apiMatches = csgoDataFetcher.FetchMatches();
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId));
            context.Matches.AddRange(newMatches);

            context.SaveChanges();
        }
    }
}
