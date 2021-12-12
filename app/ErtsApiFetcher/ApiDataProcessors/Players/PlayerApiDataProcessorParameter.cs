using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.Fetchers;

namespace ErtsApiFetcher.ApiDataProcessors.Players {
    public class PlayerApiDataProcessorParameter : IApiDataProcessorParameter {
        public DataFetcherBase DataFetcher { get; }

        public PlayerApiDataProcessorParameter(DataFetcherBase dataFetcher) {
            DataFetcher = dataFetcher;
        }
    }
}
