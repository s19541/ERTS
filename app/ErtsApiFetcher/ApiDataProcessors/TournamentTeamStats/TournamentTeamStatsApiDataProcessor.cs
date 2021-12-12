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
            context.SaveChanges();

            foreach (var tournament in parameter.Tournaments) {
                var teams = GetAllTeamsFromTournament(tournament);

                foreach (var team in teams) {

                    var matches = GetAllMatchesOfTeamInTournament(team, tournament);
                    var matchesWon = matches.Where(match => match.Games.Where(game => game.Winner == team).Count() > match.Games.Where(game => game.Winner != team && game.Winner != null).Count()).Count();
                    var matchesLost = matches.Count() - matchesWon;

                    var gamesWon = matches.Sum(match => match.Games.Where(game => game.Winner == team).Count());
                    var gamesLost = matches.Sum(match => match.Games.Where(game => game.Winner != team && game.Winner != null).Count());

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


            context.SaveChanges();
        }

        private IEnumerable<Team> GetAllTeamsFromTournament(Tournament tournament) {
            return context.Matches
                 .Where(contextMatch => contextMatch.Tournament == tournament)
                 .Select(contextMatch => contextMatch.Team1).ToArray()
                 .Union(context.Matches
                 .Where(contextMatch => contextMatch.Tournament == tournament)
                 .Select(contextMatch => contextMatch.Team2).ToArray()).Distinct();
        }

        private IEnumerable<Match> GetAllMatchesOfTeamInTournament(Team team, Tournament tournament) {
            return context.Matches
                .Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToArray();
        }
    }
}
