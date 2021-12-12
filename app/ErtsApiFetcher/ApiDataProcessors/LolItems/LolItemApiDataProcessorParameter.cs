using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.Fetchers;

namespace ErtsApiFetcher.ApiDataProcessors.LolItems {
    public class LolItemApiDataProcessorParameter : IApiDataProcessorParameter {
        public LolDataFetcher DataFetcher { get; }

        public LolItemApiDataProcessorParameter(LolDataFetcher dataFetcher) {
            DataFetcher = dataFetcher;
        }
    }
}
