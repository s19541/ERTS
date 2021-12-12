using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(Dota2InitialRecurringJob), nameof(Dota2InitialRecurringJob), ErtsCron.Never)]
    public class Dota2InitialRecurringJob : RecurringJobBase {

        public Dota2InitialRecurringJob(ErtsContext context, AppConfig appConfig, ApiDataProcessorExecutor executor) : base(context, appConfig, executor) {
        }

        public override void Job() {
            context.Database.BeginTransaction();
            FetchAll(new Dota2DataFetcher(appConfig.PandaScoreApiToken, context));
            context.Database.CommitTransaction();

        }
    }
}