using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.Fetchers;
using System;

namespace ErtsApiFetcher.ApiDataProcessors.Teams {
    public class TeamApiDataProcessorParameter : IApiDataProcessorParameter {
        public DateTime? FromTime { get; }
        public DataFetcherBase DataFetcher { get; }

        public TeamApiDataProcessorParameter(DataFetcherBase dataFetcher, DateTime? fromTime) {
            FromTime = fromTime;
            DataFetcher = dataFetcher;
        }

        public TeamApiDataProcessorParameter(DataFetcherBase dataFetcher) {
            DataFetcher = dataFetcher;
        }
    }
}
