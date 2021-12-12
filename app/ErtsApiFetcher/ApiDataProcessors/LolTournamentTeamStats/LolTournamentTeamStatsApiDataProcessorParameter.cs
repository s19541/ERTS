using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsModel.Entities;
using System.Collections.Generic;

namespace ErtsApiFetcher.ApiDataProcessors.LolTournamentTeamStats {
    public class LolTournamentTeamStatsApiDataProcessorParameter : IApiDataProcessorParameter {
        public IEnumerable<Tournament> Tournaments { get; }

        public LolTournamentTeamStatsApiDataProcessorParameter(IEnumerable<Tournament> tournaments) {
            Tournaments = tournaments;
        }
    }
}
