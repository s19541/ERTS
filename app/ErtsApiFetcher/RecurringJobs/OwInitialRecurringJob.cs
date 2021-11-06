using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(OwInitialRecurringJob), nameof(OwInitialRecurringJob), ErtsCron.Never)]
    public class OwInitialRecurringJob : InitialRecurringJobBase, IRecurringJob {
        private readonly OwDataFetcher owDataFetcher;
        public OwInitialRecurringJob(ErtsContext context) {
            this.context = context;
            owDataFetcher = new OwDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();

            FetchAndSaveMatches();
            CreateTournamentTeamStats(ErtsModel.Enums.GameType.overwatch);

            context.Database.CommitTransaction();

        }

        private void FetchAndSaveMatches() {
            var apiMatches = owDataFetcher.FetchMatches();
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId));
            context.Matches.AddRange(newMatches);

            context.SaveChanges();
        }
    }
}