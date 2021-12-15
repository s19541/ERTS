using ErtsModel;
using ErtsModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.TournamentTeamStats {

    public class TournamentTeamStatsApiDataProcessor : ApiDataProcessor<TournamentTeamStatsApiDataProcessorParameter> {
        public TournamentTeamStatsApiDataProcessor(ErtsContext context) : base(context) {

        }

        protected override void ProcessInternal(TournamentTeamStatsApiDataProcessorParameter parameter) {
            context.TournamentTeams.RemoveRange(context.TournamentTeams.Where(o => parameter.Tournaments.Contains(o.Tournament)));

            foreach (var tournament in parameter.Tournaments) {
                foreach (var team in GetAllTeamsFromTournament(tournament)) {

                    var matches = GetAllMatchesOfTeamInTournament(team, tournament);
                    var matchesWon = matches.Count(match => match.Games.Count(game => game.Winner == team) > match.Games.Count(game => game.Winner != team && game.Winner != null));
                    var matchesLost = matches.Count - matchesWon;

                    var gamesWon = matches.Sum(match => match.Games.Count(game => game.Winner == team));
                    var gamesLost = matches.Sum(match => match.Games.Count(game => game.Winner != team && game.Winner != null));

                    context.TournamentTeams.Add(new TournamentTeam() {
                        Tournament = tournament,
                        Team = team,
                        GamesLost = gamesLost,
                        GamesWon = gamesWon,
                        MatchesWon = matchesWon,
                        MatchesLost = matchesLost,
                    });
                }
            }
        }

        private List<Team> GetAllTeamsFromTournament(Tournament tournament) {
            return context.Matches
                 .Where(contextMatch => contextMatch.Tournament == tournament)
                 .Select(contextMatch => contextMatch.Team1).ToList()
                 .Union(context.Matches
                 .Where(contextMatch => contextMatch.Tournament == tournament)
                 .Select(contextMatch => contextMatch.Team2)).ToList();
        }

        private List<Match> GetAllMatchesOfTeamInTournament(Team team, Tournament tournament) {
            return context.Matches
                .Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToList();
        }
    }
}
