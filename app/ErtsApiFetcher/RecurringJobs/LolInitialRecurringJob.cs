using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher._Infrastructure.RecurringJobs;
using ErtsApiFetcher.ApiDataProcessors.Leagues;
using ErtsApiFetcher.ApiDataProcessors.LolChampions;
using ErtsApiFetcher.ApiDataProcessors.LolItems;
using ErtsApiFetcher.ApiDataProcessors.LolMatches;
using ErtsApiFetcher.ApiDataProcessors.LolSpells;
using ErtsApiFetcher.ApiDataProcessors.Series;
using ErtsApiFetcher.ApiDataProcessors.Teams;
using ErtsApiFetcher.ApiDataProcessors.Tournaments;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(LolInitialRecurringJob), nameof(LolInitialRecurringJob), ErtsCron.Never)]
    public class LolInitialRecurringJob : RecurringJobBase {

        public LolInitialRecurringJob(ErtsContext context, AppConfig appConfig, ApiDataProcessorExecutor executor) : base(context, appConfig, executor) {
        }

        public override void Job() {
            context.Database.BeginTransaction();
            var lolDataFetcher = new LolDataFetcher(appConfig.PandaScoreApiToken, context);

            executor.Execute(new LolItemApiDataProcessorParameter(lolDataFetcher));
            executor.Execute(new LolChampionApiDataProcessorParameter(lolDataFetcher));
            executor.Execute(new LolSpellApiDataProcessorParameter(lolDataFetcher));
            executor.Execute(new TeamApiDataProcessorParameter(lolDataFetcher));
            executor.Execute(new LeagueApiDataProcessorParameter(lolDataFetcher));
            executor.Execute(new SerieApiDataProcessorParameter(lolDataFetcher));
            executor.Execute(new TournamentApiDataProcessorParameter(lolDataFetcher));
            executor.Execute(new LolMatchApiDataProcessorParameter(lolDataFetcher));

            context.Database.CommitTransaction();
        }
    }
}
