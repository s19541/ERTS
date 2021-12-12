using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(CsgoInitialRecurringJob), nameof(CsgoInitialRecurringJob), ErtsCron.Never)]
    public class CsgoInitialRecurringJob : RecurringJobBase {

        public CsgoInitialRecurringJob(ErtsContext context, AppConfig appConfig, ApiDataProcessorExecutor executor) : base(context, appConfig, executor) { }

        public override void Job() {
            context.Database.BeginTransaction();
            FetchAll(new CsgoDataFetcher(appConfig.PandaScoreApiToken, context));
            context.Database.CommitTransaction();
        }
    }
}
