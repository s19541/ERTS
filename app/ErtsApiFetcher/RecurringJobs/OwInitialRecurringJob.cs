using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(OwInitialRecurringJob), nameof(OwInitialRecurringJob), ErtsCron.Never)]
    public class OwInitialRecurringJob : RecurringJobBase {

        public OwInitialRecurringJob(ErtsContext context, AppConfig appConfig, ApiDataProcessorExecutor executor) : base(context, appConfig, executor) {
        }

        public override void Job() {
            context.Database.BeginTransaction();
            FetchAll(new OwDataFetcher(appConfig.PandaScoreApiToken, context));
            context.Database.CommitTransaction();

        }
    }
}