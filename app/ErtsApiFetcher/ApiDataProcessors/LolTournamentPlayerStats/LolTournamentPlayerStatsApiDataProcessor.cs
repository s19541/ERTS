using ErtsModel;
using ErtsModel.Entities;
using ErtsModel.Entities.Lol;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErtsApiFetcher.ApiDataProcessors.LolTournamentPlayerStats {

    public class LolTournamentPlayerStatsApiDataProcessor : ApiDataProcessor<LolTournamentPlayerStatsApiDataProcessorParameter> {
        public LolTournamentPlayerStatsApiDataProcessor(ErtsContext context) : base(context) {

        }

        protected override void ProcessInternal(LolTournamentPlayerStatsApiDataProcessorParameter parameter) {
            context.LolTournamentPlayers.RemoveRange(context.LolTournamentPlayers.Where(contextTournament => parameter.Tournaments.Contains(contextTournament.Tournament)));
            context.SaveChanges();

            foreach (var tournament in parameter.Tournaments) {
                var teams = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team1).ToArray().Union(context.Matches.Where(contextMatch => contextMatch.Tournament == tournament).Select(contextMatch => contextMatch.Team2).ToArray()).Distinct();
                foreach (var team in teams) {
                    foreach (var player in team.Players) {
                        var assists = 0;
                        var kills = 0;
                        var teamKills = 0;
                        var deaths = 0;
                        var minionsKilled = 0;
                        var goldEarned = 0;
                        var numberOfGames = 0;
                        var totalTimeInMInutes = 0.0;
                        var damage = 0;
                        var teamDamage = 0;
                        var matches = context.Matches.Where(contextMatch => contextMatch.Tournament == tournament && contextMatch.EndTime != null && (contextMatch.Team1 == team || contextMatch.Team2 == team)).ToArray();
                        foreach (var match in matches) {
                            foreach (var game in match.Games) {
                                teamKills += context.LolGamePlayers.Where(o => o.Game == game).Where(o => team.Players.Contains(o.Player)).Select(o => o.Kills).Sum();
                                teamDamage += context.LolGamePlayers.Where(o => o.Game == game).Where(o => team.Players.Contains(o.Player)).Select(o => o.DamageDealtToChamps).Sum();
                                numberOfGames++;
                                var gamePlayers = context.LolGamePlayers.Where(gamePlayerContext => gamePlayerContext.Game == game && gamePlayerContext.Player == player).ToArray();
                                totalTimeInMInutes += (game.EndTime - game.StartTime).TotalMinutes;
                                foreach (var gamePlayer in gamePlayers) {
                                    assists += gamePlayer.Assists;
                                    kills += gamePlayer.Kills;
                                    deaths += gamePlayer.Deaths;
                                    damage += gamePlayer.DamageDealtToChamps;
                                    minionsKilled += gamePlayer.MinionsKilled;
                                    goldEarned += gamePlayer.GoldEarned;
                                }
                            }
                        }

                        var gameStats = context.LolGamePlayers.Where(contextGamePlayer => context.Matches.Where(contextMatch => contextMatch.Games.Contains(contextGamePlayer.Game)).FirstOrDefault().Tournament == tournament && contextGamePlayer.Player == player).ToArray();
                        int championsPlayed = gameStats.Select(o => o.Champion).Distinct().Count();
                        var firstRecentChampion = gameStats.Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                        var secondRecentChampion = gameStats.Where(o => o.Champion != firstRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                        var thirdRecentChampion = gameStats.Where(o => o.Champion != firstRecentChampion && o.Champion != secondRecentChampion).Select(o => o.Champion).GroupBy(o => o).Select(o => new { Champion = o.Key, Count = o.Count() }).OrderByDescending(o => o.Count).FirstOrDefault()?.Champion;
                        context.LolTournamentPlayers.Add(new LolTournamentPlayer() {
                            Tournament = tournament,
                            Player = player,
                            AverageAssists = numberOfGames != 0 ? assists / numberOfGames : default(double?),
                            AverageDeaths = numberOfGames != 0 ? deaths / numberOfGames : default(double?),
                            AverageKills = numberOfGames != 0 ? kills / numberOfGames : default(double?),
                            AverageGoldEarned = numberOfGames != 0 ? goldEarned / numberOfGames : default(double?),
                            AverageMinionsKilled = numberOfGames != 0 ? minionsKilled / numberOfGames : default(double?),
                            FavouriteChampion1 = firstRecentChampion,
                            FavouriteChampion2 = secondRecentChampion,
                            FavouriteChampion3 = thirdRecentChampion,
                            ChampionsPlayed = championsPlayed,
                            GoldPerMinute = totalTimeInMInutes != 0 ? goldEarned / totalTimeInMInutes : default(double?),
                            MinionsPerMinute = totalTimeInMInutes != 0 ? minionsKilled / totalTimeInMInutes : default(double?),
                            KillParticipation = teamKills != 0 ? kills / teamKills : default(double?),
                            DamageShare = teamDamage != 0 ? damage / teamDamage : default(double?)

                        });
                    }
                }

            }
        }
    }
}
