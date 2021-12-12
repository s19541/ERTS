using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsApiFetcher.ApiDataProcessors.LolExampleGameStats;
using ErtsApiFetcher.ApiDataProcessors.LolTournamentPlayerStats;
using ErtsApiFetcher.ApiDataProcessors.LolTournamentTeamStats;
using ErtsModel;
using ErtsModel.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.LolMatches {
    public class LolMatchApiDataProcessor : ApiDataProcessor<LolMatchApiDataProcessorParameter> {
        private readonly ApiDataProcessorExecutor executor;
        public LolMatchApiDataProcessor(ErtsContext context, ApiDataProcessorExecutor executor) : base(context) {
            this.executor = executor;
        }

        protected override void ProcessInternal(LolMatchApiDataProcessorParameter parameter) {
            var apiMatches = parameter.DataFetcher.FetchMatches(parameter.FromTime);
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId)).ToArray();
            context.Matches.AddRange(newMatches);

            context.SaveChanges();
            executor.Execute(new LolExampleGameStatsApiDataProcessorParameter(newMatches));
            executor.Execute(new LolTournamentTeamStatsApiDataProcessorParameter(GetTournamentsFromMatches(newMatches)));
            executor.Execute(new LolTournamentPlayerStatsApiDataProcessorParameter(GetTournamentsFromMatches(newMatches)));
        }

        private IEnumerable<Tournament> GetTournamentsFromMatches(IEnumerable<Match> matches) {
            return matches.Select(match => match.Tournament).Distinct();
        }
    }
}
