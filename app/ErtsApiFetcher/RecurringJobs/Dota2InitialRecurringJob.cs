using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using Hangfire;
using System.Linq;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(Dota2InitialRecurringJob), nameof(Dota2InitialRecurringJob), ErtsCron.Never)]
    public class Dota2InitialRecurringJob : InitialRecurringJobBase, IRecurringJob {
        private readonly Dota2DataFetcher dota2DataFetcher;
        public Dota2InitialRecurringJob(ErtsContext context) {
            this.context = context;
            this.dota2DataFetcher = new Dota2DataFetcher("YCqH-LZuSLFrILAk1bDq2KlXdG85FuTlE4grbo-eqyqZcRVflcM", context);
        }

        [AutomaticRetry(Attempts = 0)]
        public void Job() {
            context.Database.BeginTransaction();

            FetchAndSaveMatches();
            CreateTournamentTeamStats(ErtsModel.Enums.GameType.dota2);

            context.Database.CommitTransaction();

        }

        private void FetchAndSaveMatches() {
            var apiMatches = dota2DataFetcher.FetchMatches();
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId));
            context.Matches.AddRange(newMatches);

            context.SaveChanges();
        }
    }
}