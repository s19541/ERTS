using ErtsModel;
using ErtsModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.LolTournamentTeamStats {

    public class LolTournamentTeamStatsApiDataProcessor : ApiDataProcessor<LolTournamentTeamStatsApiDataProcessorParameter> {
        public LolTournamentTeamStatsApiDataProcessor(ErtsContext context) : base(context) {

        }

        protected override void ProcessInternal(LolTournamentTeamStatsApiDataProcessorParameter parameter) {
            context.LolTournamentTeams.RemoveRange(context.LolTournamentTeams.Where(contextTournament => parameter.Tournaments.Contains(contextTournament.Tournament)));
            context.SaveChanges();
            foreach (var tournament in parameter.Tournaments) {
                foreach (var team in GetAllTeamsFromTournament(tournament)) {
                    var matches = GetAllMatchesOfTeamInTournament(team, tournament);

                    var numberOfGames = matches.Sum(match => match.Games.Count);

                    var matchesWon = matches.Count(match => match.Games.Count(game => game.Winner == team) > match.Games.Count(game => game.Winner != team && game.Winner != null));
                    var matchesLost = matches.Count - matchesWon;

                    var gamesWon = matches.Sum(match => match.Games.Count(game => game.Winner == team));
                    var gamesLost = matches.Sum(match => match.Games.Count(game => game.Winner != team && game.Winner != null));

                    var gamePlayers = context.LolGamePlayers.Where(contextGamePlayer => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGamePlayer.Game)).FirstOrDefault().Tournament == tournament && team.Players.Contains(contextGamePlayer.Player)).ToArray();

                    var kills = gamePlayers.Sum(contextGamePlayer => contextGamePlayer.Kills);
                    var deaths = gamePlayers.Sum(contextGamePlayer => contextGamePlayer.Deaths);
                    var assists = gamePlayers.Sum(contextGamePlayer => contextGamePlayer.Assists);
                    var goldEarned = gamePlayers.Sum(contextGamePlayer => contextGamePlayer.GoldEarned);

                    var gameTeams = context.LolGameTeams.Where(contextGameTeam => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGameTeam.Game)).FirstOrDefault().Tournament == tournament && team == contextGameTeam.Team).ToArray();

                    var dragonKilled = gameTeams.Sum(contextGameTeam => contextGameTeam.CloudDrakeKilled + contextGameTeam.InfernalDrakeKilled + contextGameTeam.MountainDrakeKilled + contextGameTeam.OceanDrakeKilled + contextGameTeam.ElderDrakeKilled);
                    var heraldKilled = gameTeams.Sum(contextGameTeam => contextGameTeam.HeraldKilled);
                    var baronKilled = gameTeams.Sum(contextGameTeam => contextGameTeam.BaronKilled);
                    var towerDestroyed = gameTeams.Sum(contextGameTeam => contextGameTeam.TurretDestroyed);


                    var firstRecentChampion = gamePlayers.Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var secondRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var thirdRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var fourthRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion && o.Champion != thirdRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var fivethRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion && o.Champion != thirdRecentChampion && o.Champion != fourthRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;

                    context.LolTournamentTeams.Add(new LolTournamentTeam() {
                        Tournament = tournament,
                        Team = team,
                        GamesLost = gamesLost,
                        GamesWon = gamesWon,
                        MatchesWon = matchesWon,
                        MatchesLost = matchesLost,
                        AverageKills = numberOfGames != 0 ? Math.Round((float)kills / numberOfGames, 2) : 0,
                        AverageDeaths = numberOfGames != 0 ? Math.Round((float)deaths / numberOfGames, 2) : 0,
                        AverageAssists = numberOfGames != 0 ? Math.Round((float)assists / numberOfGames, 2) : 0,
                        AverageGoldEarned = numberOfGames != 0 ? Math.Round((float)goldEarned / numberOfGames, 2) : 0,
                        AverageBaronKilled = numberOfGames != 0 ? Math.Round((float)baronKilled / numberOfGames, 2) : 0,
                        AverageDragonKilled = numberOfGames != 0 ? Math.Round((float)dragonKilled / numberOfGames, 2) : 0,
                        AverageHeraldKilled = numberOfGames != 0 ? Math.Round((float)heraldKilled / numberOfGames, 2) : 0,
                        AverageTowerDestroyed = numberOfGames != 0 ? Math.Round((float)towerDestroyed / numberOfGames, 2) : 0,
                        FavouriteChampion1 = firstRecentChampion,
                        FavouriteChampion2 = secondRecentChampion,
                        FavouriteChampion3 = thirdRecentChampion,
                        FavouriteChampion4 = fourthRecentChampion,
                        FavouriteChampion5 = fivethRecentChampion
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
