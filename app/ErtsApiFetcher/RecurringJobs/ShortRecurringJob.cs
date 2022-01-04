using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.ApiDataProcessors.LolMatches;
using ErtsApiFetcher.ApiDataProcessors.Matches;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using System;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(ShortRecurringJob),
        nameof(ShortRecurringJob), ErtsCron.Minutely)]
    public class ShortRecurringJob : RecurringJobBase {
        private readonly DateTime from = DateTime.Now.AddMinutes(-2);

        public ShortRecurringJob(ErtsContext context, AppConfig appConfig, ApiDataProcessorExecutor executor) : base(context, appConfig, executor) {
        }

        public override void Job() {
            context.Database.BeginTransaction();

            executor.Execute(new MatchApiDataProcessorParameter(new CsgoDataFetcher(appConfig.PandaScoreApiToken, context), from));
            executor.Execute(new MatchApiDataProcessorParameter(new Dota2DataFetcher(appConfig.PandaScoreApiToken, context), from));
            executor.Execute(new MatchApiDataProcessorParameter(new ValorantDataFetcher(appConfig.PandaScoreApiToken, context), from));
            executor.Execute(new MatchApiDataProcessorParameter(new OwDataFetcher(appConfig.PandaScoreApiToken, context), from));
            executor.Execute(new LolMatchApiDataProcessorParameter(new LolDataFetcher(appConfig.PandaScoreApiToken, context), from));

            context.Database.CommitTransaction();
        }
    }
}