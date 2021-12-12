using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsModel.Entities;
using System.Collections.Generic;

namespace ErtsApiFetcher.ApiDataProcessors.LolTournamentPlayerStats {
    public class LolTournamentPlayerStatsApiDataProcessorParameter : IApiDataProcessorParameter {
        public IEnumerable<Tournament> Tournaments { get; }

        public LolTournamentPlayerStatsApiDataProcessorParameter(IEnumerable<Tournament> tournaments) {
            Tournaments = tournaments;
        }
    }
}
