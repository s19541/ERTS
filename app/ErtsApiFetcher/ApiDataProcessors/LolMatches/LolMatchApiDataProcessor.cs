﻿using ErtsApiFetcher._Infrastructure.ApiDataProcessors;
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

            var updatedMatches = apiMatches.Where(apiMatch => context.Matches.Any(contextMatch => contextMatch.ApiId == apiMatch.ApiId));
            foreach (var updatedMatch in updatedMatches) {
                var contextMatch = context.Matches.Where(contextMatch => contextMatch.ApiId == updatedMatch.ApiId).FirstOrDefault();
                contextMatch.Update(updatedMatch.StartTime, updatedMatch.EndTime, updatedMatch.Team1, updatedMatch.Team2, updatedMatch.Tournament, updatedMatch.StreamUrl, updatedMatch.Games, updatedMatch.NumberOfGames);
            }

            context.SaveChanges();
            executor.Execute(new LolExampleGameStatsApiDataProcessorParameter(apiMatches));
            executor.Execute(new LolTournamentTeamStatsApiDataProcessorParameter(GetTournamentsFromMatches(apiMatches)));
            executor.Execute(new LolTournamentPlayerStatsApiDataProcessorParameter(GetTournamentsFromMatches(apiMatches)));
        }

        private IEnumerable<Tournament> GetTournamentsFromMatches(IEnumerable<Match> matches) {
            return matches.Select(match => match.Tournament).Distinct();
        }
    }
}
