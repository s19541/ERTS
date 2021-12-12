using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(ValorantInitialRecurringJob), nameof(ValorantInitialRecurringJob), ErtsCron.Never)]
    public class ValorantInitialRecurringJob : RecurringJobBase {

        public ValorantInitialRecurringJob(ErtsContext context, AppConfig appConfig, ApiDataProcessorExecutor executor) : base(context, appConfig, executor) {
        }

        public override void Job() {
            context.Database.BeginTransaction();
            FetchAll(new ValorantDataFetcher(appConfig.PandaScoreApiToken, context));
            context.Database.CommitTransaction();

        }
    }
}
