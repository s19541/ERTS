using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.Fetchers;
using System;

namespace ErtsApiFetcher.ApiDataProcessors.Leagues {
    public class LeagueApiDataProcessorParameter : IApiDataProcessorParameter {
        public DateTime? FromTime { get; }
        public DataFetcherBase DataFetcher { get; }

        public LeagueApiDataProcessorParameter(DataFetcherBase dataFetcher, DateTime? fromTime) {
            FromTime = fromTime;
            DataFetcher = dataFetcher;
        }

        public LeagueApiDataProcessorParameter(DataFetcherBase dataFetcher) {
            DataFetcher = dataFetcher;
        }
    }
}
