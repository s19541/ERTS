using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.Fetchers;

namespace ErtsApiFetcher.ApiDataProcessors.LolChampions {
    public class LolChampionApiDataProcessorParameter : IApiDataProcessorParameter {
        public LolDataFetcher DataFetcher { get; }

        public LolChampionApiDataProcessorParameter(LolDataFetcher dataFetcher) {
            DataFetcher = dataFetcher;
        }
    }
}
