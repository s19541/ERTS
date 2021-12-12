using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.Fetchers;
using System;

namespace ErtsApiFetcher.ApiDataProcessors.Tournaments {
    public class TournamentApiDataProcessorParameter : IApiDataProcessorParameter {
        public DateTime? FromTime { get; }
        public DataFetcherBase DataFetcher { get; }

        public TournamentApiDataProcessorParameter(DataFetcherBase dataFetcher, DateTime? fromTime) {
            FromTime = fromTime;
            DataFetcher = dataFetcher;
        }

        public TournamentApiDataProcessorParameter(DataFetcherBase dataFetcher) {
            DataFetcher = dataFetcher;
        }
    }
}
