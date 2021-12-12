using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsModel.Entities;
using System.Collections.Generic;

namespace ErtsApiFetcher.ApiDataProcessors {
    public class TournamentTeamStatsApiDataProcessorParameter : IApiDataProcessorParameter {
        public IEnumerable<Tournament> Tournaments { get; }

        public TournamentTeamStatsApiDataProcessorParameter(IEnumerable<Tournament> tournaments) {
            Tournaments = tournaments;
        }
    }
}
