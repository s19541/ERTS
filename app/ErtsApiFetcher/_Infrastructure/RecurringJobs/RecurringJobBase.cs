using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.ApiDataProcessors.Leagues;
using ErtsApiFetcher.ApiDataProcessors.Matches;
using ErtsApiFetcher.ApiDataProcessors.Players;
using ErtsApiFetcher.ApiDataProcessors.Series;
using ErtsApiFetcher.ApiDataProcessors.Teams;
using ErtsApiFetcher.ApiDataProcessors.Tournaments;
using ErtsApiFetcher.Configurations;
using ErtsApiFetcher.Fetchers;
using ErtsModel;
using System;

namespace ErtsApiFetcher._Infrastructure.RecurringJobs {
    public abstract class RecurringJobBase : IRecurringJob {
        protected readonly ApiDataProcessorExecutor executor;
        protected readonly ErtsContext context;
        protected readonly AppConfig appConfig;

        protected RecurringJobBase(ErtsContext context, AppConfig appConfig, ApiDataProcessorExecutor executor) {
            this.context = context;
            this.appConfig = appConfig;
            this.executor = executor;
        }

        public abstract void Job();

        public void FetchAll(DataFetcherBase dataFetcher, DateTime? fromTime) {
            executor.Execute(new TeamApiDataProcessorParameter(dataFetcher, fromTime));
            executor.Execute(new LeagueApiDataProcessorParameter(dataFetcher, fromTime));
            executor.Execute(new SerieApiDataProcessorParameter(dataFetcher, fromTime));
            executor.Execute(new TournamentApiDataProcessorParameter(dataFetcher, fromTime));
            executor.Execute(new MatchApiDataProcessorParameter(dataFetcher, fromTime));
        }

        public void FetchAll(DataFetcherBase dataFetcher) {
            executor.Execute(new PlayerApiDataProcessorParameter(dataFetcher));
            FetchAll(dataFetcher, null);
        }
    }
}
