using ErtsModel;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.Tournaments {
    public class TournamentApiDataProcessor : ApiDataProcessor<TournamentApiDataProcessorParameter> {
        public TournamentApiDataProcessor(ErtsContext context) : base(context) { }

        protected override void ProcessInternal(TournamentApiDataProcessorParameter parameter) {
            var apiTournaments = parameter.DataFetcher.FetchTournaments(parameter.FromTime);
            var newTournaments = apiTournaments.Where(apiTournament => !context.Tournaments.Any(contextTournament => contextTournament.ApiId == apiTournament.ApiId));
            context.Tournaments.AddRange(newTournaments);
        }
    }
}
