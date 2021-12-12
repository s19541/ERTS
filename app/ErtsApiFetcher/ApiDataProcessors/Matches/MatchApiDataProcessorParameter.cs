using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.Fetchers;
using System;

namespace ErtsApiFetcher.ApiDataProcessors.Matches {
    public class MatchApiDataProcessorParameter : IApiDataProcessorParameter {
        public DateTime? FromTime { get; }
        public DataFetcherBase DataFetcher { get; }

        public MatchApiDataProcessorParameter(DataFetcherBase dataFetcher, DateTime? fromTime) {
            FromTime = fromTime;
            DataFetcher = dataFetcher;
        }
    }
}
