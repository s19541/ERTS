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

                var teams = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team1).ToArray().Union(context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team2).ToArray()).Distinct();

                foreach (var team in teams) {
                    var gamesLost = 0;
                    var gamesWon = 0;
                    var matchesWon = 0;
                    var matchesLost = 0;
                    var numberOfGames = 0;
                    var kills = 0;
                    var deaths = 0;
                    var assists = 0;
                    var goldEarned = 0;
                    var dragonKilled = 0;
                    var heraldKilled = 0;
                    var baronKilled = 0;
                    var towerDestroyed = 0;
                    var matches = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToArray();
                    foreach (var match in matches) {
                        var matchGamesWon = 0;
                        var matchGamesLost = 0;
                        foreach (var game in match.Games) {
                            numberOfGames++;
                            if (game.Winner == team)
                                matchGamesWon++;
                            else
                                matchGamesLost++;

                            foreach (var gameTeam in context.LolGameTeams.Where(contextGameTeam => contextGameTeam.Game == game && contextGameTeam.Team == team)) {
                                goldEarned += gameTeam.GoldEarned;
                                dragonKilled += gameTeam.CloudDrakeKilled;
                                dragonKilled += gameTeam.MountainDrakeKilled;
                                dragonKilled += gameTeam.InfernalDrakeKilled;
                                dragonKilled += gameTeam.OceanDrakeKilled;
                                dragonKilled += gameTeam.ElderDrakeKilled;
                                heraldKilled += gameTeam.HeraldKilled;
                                baronKilled += gameTeam.HeraldKilled;
                                towerDestroyed += gameTeam.TurretDestroyed;
                            }

                            foreach (var gamePlayer in context.LolGamePlayers.Where(contextGamePlayer => contextGamePlayer.Game == game && team.Players.Contains(contextGamePlayer.Player))) {
                                kills += gamePlayer.Kills;
                                assists += gamePlayer.Assists;
                                deaths += gamePlayer.Deaths;
                            }
                        }
                        gamesLost += matchGamesLost;
                        gamesWon += matchGamesWon;
                        if (matchGamesWon > matchGamesLost)
                            matchesWon++;
                        else if (matchGamesLost > matchGamesWon)
                            matchesLost++;
                    }
                    var gamePlayers = context.LolGamePlayers.Where(contextGamePlayer => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGamePlayer.Game)).FirstOrDefault().Tournament == tournament && team.Players.Contains(contextGamePlayer.Player)).ToArray();
                    var firstRecentChampion = gamePlayers.Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var secondRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var thirdRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var fourthRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion && o.Champion != thirdRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                    var fivethRecentChampion = gamePlayers.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion && o.Champion != thirdRecentChampion && o.Champion != fourthRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;

                    context.LolTournamentTeams.Add(new ErtsModel.Entities.LolTournamentTeam() {
                        Tournament = tournament,
                        Team = team,
                        GamesLost = gamesLost,
                        GamesWon = gamesWon,
                        MatchesWon = matchesWon,
                        MatchesLost = matchesLost,
                        AverageKills = numberOfGames != 0 ? kills / numberOfGames : 0,
                        AverageDeaths = numberOfGames != 0 ? deaths / numberOfGames : 0,
                        AverageAssists = numberOfGames != 0 ? assists / numberOfGames : 0,
                        AverageGoldEarned = numberOfGames != 0 ? goldEarned / numberOfGames : 0,
                        AverageBaronKilled = numberOfGames != 0 ? baronKilled / numberOfGames : 0,
                        AverageDragonKilled = numberOfGames != 0 ? dragonKilled / numberOfGames : 0,
                        AverageHeraldKilled = numberOfGames != 0 ? heraldKilled / numberOfGames : 0,
                        AverageTowerDestroyed = numberOfGames != 0 ? towerDestroyed / numberOfGames : 0,
                        FavouriteChampion1 = firstRecentChampion,
                        FavouriteChampion2 = secondRecentChampion,
                        FavouriteChampion3 = thirdRecentChampion,
                        FavouriteChampion4 = fourthRecentChampion,
                        FavouriteChampion5 = fivethRecentChampion
                    });
                }
            }
        }
        }
}
