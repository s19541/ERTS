using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsModel.Entities;
using System.Collections.Generic;

namespace ErtsApiFetcher.ApiDataProcessors.LolExampleGameStats {
    public class LolExampleGameStatsApiDataProcessorParameter : IApiDataProcessorParameter {
        public IEnumerable<Match> Matches { get; }

        public LolExampleGameStatsApiDataProcessorParameter(IEnumerable<Match> matches) {
            Matches = matches;
        }
    }
}
