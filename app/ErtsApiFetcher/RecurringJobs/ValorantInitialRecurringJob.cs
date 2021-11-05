using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(ValorantInitialRecurringJob), nameof(ValorantInitialRecurringJob), ErtsCron.Never)]
    public class ValorantInitialRecurringJob : InitialRecurringJobBase, IRecurringJob {
        private readonly ValorantDataFetcher valorantDataFetcher;
        public ValorantInitialRecurringJob(ErtsContext context) {
            this.context = context;
            valorantDataFetcher = new ValorantDataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();

            FetchAndSaveMatches();

            CreateTournamentTeamStats(ErtsModel.Enums.GameType.valorant);

            context.Database.CommitTransaction();
        }

        private void FetchAndSaveMatches() {
            var apiMatches = valorantDataFetcher.FetchMatches();
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId));
            context.Matches.AddRange(newMatches);

            context.SaveChanges();
        }
    }
}
