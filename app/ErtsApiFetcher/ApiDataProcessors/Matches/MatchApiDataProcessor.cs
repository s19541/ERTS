﻿using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
using ErtsModel;
using ErtsModel.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.Matches {
    public class MatchApiDataProcessor : ApiDataProcessor<MatchApiDataProcessorParameter> {
        private readonly ApiDataProcessorExecutor executor;

        public MatchApiDataProcessor(ErtsContext context, ApiDataProcessorExecutor executor) : base(context) {
            this.executor = executor;
        }

        protected override void ProcessInternal(MatchApiDataProcessorParameter parameter) {
            var apiMatches = parameter.DataFetcher.FetchMatches(parameter.FromTime);
            var newMatches = apiMatches.Where(apiMatches => !context.Matches.Any(contextMatche => contextMatche.ApiId == apiMatches.ApiId)).ToArray();
            context.Matches.AddRange(newMatches);

            context.SaveChanges();
            executor.Execute(new TournamentTeamStatsApiDataProcessorParameter(GetTournamentsFromMatches(newMatches)));
        }

        private IEnumerable<Tournament> GetTournamentsFromMatches(IEnumerable<Match> matches) {
            return matches.Select(match => match.Tournament).Distinct();
        }
    }
}
