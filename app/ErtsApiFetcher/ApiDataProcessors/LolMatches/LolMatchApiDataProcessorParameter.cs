using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.Fetchers;
using System;

namespace ErtsApiFetcher.ApiDataProcessors.LolMatches {
    public class LolMatchApiDataProcessorParameter : IApiDataProcessorParameter {
        public DateTime? FromTime { get; }
        public DataFetcherBase DataFetcher { get; }

        public LolMatchApiDataProcessorParameter(DataFetcherBase dataFetcher, DateTime? fromTime) {
            FromTime = fromTime;
            DataFetcher = dataFetcher;
        }

        public LolMatchApiDataProcessorParameter(DataFetcherBase dataFetcher) {
            DataFetcher = dataFetcher;
        }
    }
}
