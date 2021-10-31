using ErtsModel;
using ErtsModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErtsApiFetcher.RecurringJobs {
    public abstract class RecurringJobBase {
        protected ErtsContext context;
        public GameType gameType;

        protected void CreateTournamentTeamStats() {
            context.TournamentTeams.RemoveRange(context.TournamentTeams.Where(o => o.Tournament.Serie.League.GameType == gameType));
            context.SaveChanges();

            foreach (var tournament in context.Tournaments.ToArray()) {

                var teams = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team1).ToArray().Union(context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team2).ToArray()).Distinct();

                foreach (var team in teams) {
                    var gamesLost = 0;
                    var gamesWon = 0;
                    var matchesWon = 0;
                    var matchesLost = 0;

                    var matches = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToArray();
                    foreach (var match in matches) {
                        var matchGamesWon = 0;
                        var matchGamesLost = 0;
                        foreach (var game in match.Games) {
                            if (game.Winner == team)
                                matchGamesWon++;
                            else
                                matchGamesLost++;

                            gamesLost += matchGamesLost;
                            gamesWon += matchGamesWon;
                            if (matchGamesWon > matchGamesLost)
                                matchesWon++;
                            else if (matchGamesLost > matchGamesWon)
                                matchesLost++;
                        }
                    }

                    context.TournamentTeams.Add(new ErtsModel.Entities.LolTournamentTeam() {
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
    }
}
