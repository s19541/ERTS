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
using System;

namespace ErtsApiFetcher.RecurringJobs {
    [RecurringJobInfo(typeof(DailyRecurringJob), nameof(DailyRecurringJob), ErtsCron.Never)]
    public class DailyRecurringJob : RecurringJobBase {
        private readonly DateTime from = DateTime.Now.AddDays(-1);

        public DailyRecurringJob(ErtsContext context, AppConfig appConfig, ApiDataProcessorExecutor executor) : base(context, appConfig, executor) {
        }

        public override void Job() {
            context.Database.BeginTransaction();

            FetchAll(new CsgoDataFetcher(appConfig.PandaScoreApiToken, context), from);
            FetchAll(new Dota2DataFetcher(appConfig.PandaScoreApiToken, context), from);
            FetchAll(new ValorantDataFetcher(appConfig.PandaScoreApiToken, context), from);
            FetchAll(new OwDataFetcher(appConfig.PandaScoreApiToken, context), from);

            var lolDataFetcher = new LolDataFetcher(appConfig.PandaScoreApiToken, context);
            executor.Execute(new TeamApiDataProcessorParameter(lolDataFetcher, from));
            executor.Execute(new LeagueApiDataProcessorParameter(lolDataFetcher, from));
            executor.Execute(new SerieApiDataProcessorParameter(lolDataFetcher, from));
            executor.Execute(new TournamentApiDataProcessorParameter(lolDataFetcher, from));
            executor.Execute(new LolMatchApiDataProcessorParameter(lolDataFetcher, from));
            executor.Execute(new LolItemApiDataProcessorParameter(lolDataFetcher));
            executor.Execute(new LolChampionApiDataProcessorParameter(lolDataFetcher));
            executor.Execute(new LolSpellApiDataProcessorParameter(lolDataFetcher));

            context.Database.CommitTransaction();
        }
    }
}