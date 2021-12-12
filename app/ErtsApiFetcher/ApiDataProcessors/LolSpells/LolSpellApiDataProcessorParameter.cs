using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.Fetchers;

namespace ErtsApiFetcher.ApiDataProcessors.LolSpells {
    public class LolSpellApiDataProcessorParameter : IApiDataProcessorParameter {
        public LolDataFetcher DataFetcher { get; }

        public LolSpellApiDataProcessorParameter(LolDataFetcher dataFetcher) {
            DataFetcher = dataFetcher;
        }
    }
}
